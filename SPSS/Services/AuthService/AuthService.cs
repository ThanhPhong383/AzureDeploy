using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SPSS.Data;
using SPSS.Dto;
using SPSS.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SPSS.Services.AuthService
{
    public class AuthService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<IdentityRole> _roleManager, IConfiguration _configuration) : IAuthService
    {
        public async Task<AppUser?> RegisterAsync(UserDto request)
        {
            if (await _userManager.FindByNameAsync(request.Username) != null)
                throw new Exception("Username already exists.");

            if (await _userManager.FindByEmailAsync(request.Email) != null)
                throw new Exception("Email already exists.");

            var user = new AppUser
            {
                UserName = request.Username,
                Email = request.Email,
                EmailConfirmed = false // Đảm bảo người dùng phải xác nhận email sau khi đăng ký
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new Exception($"Registration failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");

            return user;
        }

        public async Task<string> AddRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
                throw new Exception("Role already exists.");

            var role = new IdentityRole(roleName);
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
                throw new Exception($"Failed to create role: {string.Join(", ", result.Errors.Select(e => e.Description))}");

            return "Role created successfully.";
        }

        public async Task<string> AssignRoleToUserAsync(string username, string role)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                throw new Exception("User not found.");

            if (!await _roleManager.RoleExistsAsync(role))
                throw new Exception("Role does not exist.");

            await _userManager.AddToRoleAsync(user, role);
            return "Role assigned successfully.";
        }

        public async Task<TokenResponseDto?> LoginAsync(LoginDto request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                throw new Exception("Invalid username or password.");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!result.Succeeded)
                throw new Exception("Invalid username or password.");

            var tokenResponse = await CreateTokenResponse(user);
            tokenResponse.EmailConfirmed = user.EmailConfirmed; // Bao gồm trạng thái xác nhận email

            return tokenResponse;
        }

        public async Task<string> LogoutAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                throw new Exception("User not found.");

            await _signInManager.SignOutAsync();

            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            await _userManager.UpdateAsync(user);

            return "Logout successful.";
        }

        private async Task<TokenResponseDto> CreateTokenResponse(AppUser user)
        {
            return new TokenResponseDto
            {
                AccessToken = CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshToken(user),
                EmailConfirmed = user.EmailConfirmed // Thêm trạng thái xác nhận email vào token response
            };
        }

        public async Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                throw new Exception("Invalid refresh token.");

            if (user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                throw new Exception("Refresh token expired or invalid.");

            return await CreateTokenResponse(user);
        }

        private async Task<string> GenerateAndSaveRefreshToken(AppUser user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);
            return refreshToken;
        }

        private string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email), 
        new Claim("EmailConfirmed", user.EmailConfirmed.ToString()) // Thêm trạng thái xác nhận email vào JWT
    };

            var secretKey = _configuration["AppSettings:Token"];
            if (string.IsNullOrEmpty(secretKey))
                throw new Exception("JWT Secret Key is missing in appsettings.json.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["AppSettings:Issuer"],
                audience: _configuration["AppSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}

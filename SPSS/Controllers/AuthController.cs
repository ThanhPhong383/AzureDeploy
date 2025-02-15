using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPSS.Dto;
using SPSS.Services.AuthService;

namespace SPSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController (IAuthService authService   ) : ControllerBase
    {
        //private readonly IAuthService authService;

        //public AuthController(IAuthService authService)
        //{
        //    this.authService = authService;
        //}

        // 🟢 Đăng ký tài khoản
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { Error = "Username and password cannot be empty." });

            try
            {
                var user = await authService.RegisterAsync(request);
                if (user == null)
                    return Conflict(new { Error = "Registration failed. User may already exist." }); 

                return Ok(new
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    Message = "Register Successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "An unexpected error occurred.", Details = ex.Message }); 
            }
        }

        // 🟢 Đăng nhập
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { Error = "Username and password cannot be empty." });

            try
            {
                var result = await authService.LoginAsync(request);
                if (result == null)
                    return Unauthorized(new { Error = "Invalid username or password." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "An unexpected error occurred.", Details = ex.Message }); 
            }
        }

        // 🟢 Đăng xuất
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return Unauthorized(new { Error = "You need to be logged in to logout." });

            try
            {
                var result = await authService.LogoutAsync(username);
                return Ok(new { Message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "An unexpected error occurred.", Details = ex.Message }); 
            }
        }

        // 🟢 Làm mới AccessToken
        [HttpPost("refresh-tokens")]
        public async Task<IActionResult> RefreshTokens([FromBody] RefreshTokenRequestDto request)
        {
            if (string.IsNullOrEmpty(request.UserId.ToString()) || string.IsNullOrEmpty(request.RefreshToken))
                return BadRequest(new { Error = "UserId and RefreshToken cannot be empty." });

            try
            {
                var result = await authService.RefreshTokensAsync(request);
                if (result == null)
                    return Unauthorized(new { Error = "Invalid refresh token." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "An unexpected error occurred.", Details = ex.Message }); 
            }
        }

        // 🟢 Gán Role cho user (Chỉ nếu Role tồn tại trong hệ thống)
        [HttpPut("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] SetRoleRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Role))
                return BadRequest(new { Error = "Username and role cannot be empty." });

            try
            {
                var result = await authService.AssignRoleToUserAsync(request.Username, request.Role);
                return Ok(new { Message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "An unexpected error occurred.", Details = ex.Message }); 
            }
        }

        // 🟢 Thêm Role mới vào hệ thống
        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest(new { Error = "Role name cannot be empty." });

            try
            {
                var result = await authService.AddRoleAsync(roleName);
                return Ok(new { Message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "An unexpected error occurred.", Details = ex.Message }); 
            }
        }

        // 🟢 API chỉ dành cho user đã xác thực
        [Authorize]
        [HttpGet("authenticated")]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok(new { Message = "You are authenticated!" });
        }

        // 🔴 API chỉ dành cho Admin
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok(new { Message = "You are an admin!" });
        }
    }
}

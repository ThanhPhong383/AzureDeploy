using SPSS.Dto;
using SPSS.Entities;

namespace SPSS.Services.AuthService
{
    public interface IAuthService
    {
        Task<AppUser?> RegisterAsync(UserDto request);

        Task<TokenResponseDto?> LoginAsync(LoginDto request);

        Task<string> LogoutAsync(string username);

        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);

        Task<string> AssignRoleToUserAsync(string username, string role);

        Task<string> AddRoleAsync(string roleName);
    }
}

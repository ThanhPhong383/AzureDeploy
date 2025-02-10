using SPSS.Dto;
using SPSS.Entities;

namespace SPSS.Services.AuthService
{
    public interface IAuthService
    {
        Task<AppUser?> RegisterAsync(UserDto request);

        Task<TokenResponseDto?> LoginAsync(UserDto request);

        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);

        Task<string> AssignRoleToUserAsync(string username, string role);

        Task<string> AddRoleAsync(string roleName);
    }
}

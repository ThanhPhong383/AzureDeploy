using Microsoft.AspNetCore.Identity;
using SPSS.Dto;
using SPSS.Dto.Account;
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

        Task<string> ChangePasswordAsync(string username, ChangePasswordDto request);

        Task<string> ForgotPassword(ForgotPasswordDto request);

        Task<string> ResetPassword(ResetPasswordDto request);

        Task<TokenResponseDto> GoogleLoginAsync(GoogleUserLoginDTO googleLoginDTO);

        Task<TokenResponseDto> GoogleSetPasswordAsync(SetPasswordDTO request, string token);
    }
}

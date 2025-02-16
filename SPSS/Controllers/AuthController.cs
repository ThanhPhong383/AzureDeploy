using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SPSS.Dto;
using SPSS.Dto.Account;
using SPSS.Services.AuthService;
using System.Security.Claims;

namespace SPSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
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
                    EmailConfirmed = user.EmailConfirmed, 
                    Message = "Register Successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "An unexpected error occurred.", Details = ex.Message });
            }
        }

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

                return Ok(new
                {
                    result.AccessToken,
                    result.RefreshToken,
                    EmailConfirmed = result.EmailConfirmed 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "An unexpected error occurred.", Details = ex.Message });
            }
        }

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

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request)
        {
            if (string.IsNullOrEmpty(request.CurrentPassword) ||
                string.IsNullOrEmpty(request.NewPassword) ||
                string.IsNullOrEmpty(request.ConfirmNewPassword))
            {
                return BadRequest(new { Error = "All fields are required." });
            }

            try
            {
                var username = User.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(username))
                    return Unauthorized(new { Error = "User not found." });

                var result = await authService.ChangePasswordAsync(username, request);
                return Ok(new { Message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "An unexpected error occurred.", Details = ex.Message });
            }
        }

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

        [Authorize]
        [HttpGet("authenticated")]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok(new { Message = "You are authenticated!" });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok(new { Message = "You are an admin!" });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto request)
        {
            var result = await authService.ForgotPassword(request);
            return Ok(new { message = result });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
        {
            var result = await authService.ResetPassword(request);
            return Ok(new { message = result });
        }

    }
}

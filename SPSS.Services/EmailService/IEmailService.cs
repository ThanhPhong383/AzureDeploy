using MimeKit;
using System.Threading.Tasks;
using SPSS.Dto.Account;
using Microsoft.AspNetCore.Http;

namespace SPSS.Services
{
    public interface IEmailService
    {
        void SendEmail(MessageOTP message);
        Task SendEmail(string userId, string senderId, string content);
        Task<string> GenerateAndSendOTP(HttpContext httpContext);
        Task<string> VerifyOTP(OTPVerificationRequest request);
    }
}
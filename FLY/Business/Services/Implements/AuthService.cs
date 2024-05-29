using FLY.Business.Models.Account;
using Microsoft.Extensions.Caching.Memory;

namespace FLY.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IEmailService _emailService;

        public AuthService(IMemoryCache memoryCache, IEmailService emailService)
        {
            _memoryCache = memoryCache;
            _emailService = emailService;
        }
        public Task<AuthResponse> AuthenticateAccount(AuthRequest authRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AuthenticateAccountAdvanced(AuthResponse authReponse)
        {
            try
            {
                string emailReturn;
                emailReturn = authReponse.Email;
                await SendVerificationEmail(emailReturn);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task SendVerificationEmail(string email)
        {
            try
            {
                string verificationCode = await GenerateVerificationCode();
                _memoryCache.Set(email, verificationCode, TimeSpan.FromMinutes(60));
                await _emailService.SendVerificationEmailAsync(email, verificationCode);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<string> GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}

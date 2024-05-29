using FLY.Business.Models.Account;

namespace FLY.Business.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> AuthenticateAccount(AuthRequest authRequest);
        Task<bool> AuthenticateAccountAdvanced(AuthResponse authReponse);
    }
}

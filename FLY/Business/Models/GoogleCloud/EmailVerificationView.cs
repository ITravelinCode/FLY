using FLY.Business.Models.Account;

namespace FLY.Business.Models.GoogleCloud
{
    public class EmailVerificationView : AuthRequest
    {
        public string? Code { get; set; }
    }
}

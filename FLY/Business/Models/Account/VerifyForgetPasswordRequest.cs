namespace FLY.Business.Models.Account
{
    public class VerifyForgetPasswordRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}

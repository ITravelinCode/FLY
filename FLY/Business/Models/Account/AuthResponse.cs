namespace FLY.Business.Models.Account
{
    public class AuthResponse
    {
        public int AccountId { get; set; }
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }
        public int Status { get; set; }
    }
}

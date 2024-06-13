namespace FLY.Business.Models.Feedback
{
    public class FeedbackResponse
    {
        public int FeedbackId { get; set; }

        public int AccountId { get; set; }

        public int ShopId { get; set; }

        public string Content { get; set; } = null!;

        public int Status { get; set; }
    }
}

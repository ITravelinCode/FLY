namespace FLY.Business.Models.Feedback
{
    public class FeedbackRequest
    {
        public int AccountId { get; set; }
        public string Content { get; set; } = null!;
    }
}

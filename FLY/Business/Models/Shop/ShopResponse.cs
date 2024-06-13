using FLY.Business.Models.Feedback;
using FLY.Business.Models.Product;
using FLY.Business.Models.Rating;

namespace FLY.Business.Models.Shop
{
    public class ShopResponse
    {
        public int ShopId { get; set; }

        public int AccountId { get; set; }

        public string ShopName { get; set; } = null!;

        public string ShopDetail { get; set; } = null!;

        public string ShopAddress { get; set; } = null!;

        public DateTime ShopStartTime { get; set; }

        public DateTime ShopEndTime { get; set; }

        public int Status { get; set; }

        public virtual ICollection<FeedbackResponse> Feedbacks { get; set; } = new List<FeedbackResponse>();

        public virtual ICollection<ProductResponse> Products { get; set; } = new List<ProductResponse>();

        public virtual ICollection<RatingResponse> Ratings { get; set; } = new List<RatingResponse>();
    }
}

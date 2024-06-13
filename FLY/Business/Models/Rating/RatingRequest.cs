namespace FLY.Business.Models.Rating
{
    public class RatingRequest
    {
        public int AccountId { get; set; }

        public int ShopId { get; set; }

        public double RateNumber { get; set; }
    }
}

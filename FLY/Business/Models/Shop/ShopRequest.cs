namespace FLY.Business.Models.Shop
{
    public class ShopRequest
    {
        public int ShopId { get; set; }

        public string ShopName { get; set; } = null!;

        public string ShopDetail { get; set; } = null!;

        public string ShopAddress { get; set; } = null!;

        public DateTime ShopStartTime { get; set; }

        public DateTime ShopEndTime { get; set; }
    }
}

namespace FLY.Business.Models.Order
{
    public class OrderRequest
    {
        public int OrderId { get; set; }
        public int ShopId { get; set; }
        public int AccountId { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
    }
}

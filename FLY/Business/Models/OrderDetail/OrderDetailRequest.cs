namespace FLY.Business.Models.OrderDetail
{
    public class OrderDetailRequest
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int OrderQuantity { get; set; }

        public float ProductPrice { get; set; }
    }
}

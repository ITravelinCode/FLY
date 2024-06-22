using FLY.Business.Models.Product;

namespace FLY.Business.Models.VoucherOfShop
{
    public class VoucherOfShopRequest
    {
        public int VoucherId { get; set; }
        public int ShopId { get; set; }

        public string VoucherName { get; set; }

        public float VoucherValue { get; set; }

        public DateTime VoucherStart { get; set; }

        public DateTime VoucherEnd { get; set; }

        public int Status { get; set; }

        public ICollection<ProductResponse> Products { get; set; }
    }
}

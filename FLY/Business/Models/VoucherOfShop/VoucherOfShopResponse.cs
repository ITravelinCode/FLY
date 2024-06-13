using FLY.Business.Models.Product;
using System.ComponentModel.DataAnnotations;

namespace FLY.Business.Models.VoucherOfShop
{
    public class VoucherOfShopResponse
    {
        public int VoucherId { get; set; }
        
        public string VoucherName { get; set; }

        public float VoucherValue { get; set; }

        public DateTime VoucherStart { get; set; }

        public DateTime VoucherEnd { get; set; }

        public int Status { get; set; }

        public ICollection<ProductResponse> Products { get; set; }
    }
}

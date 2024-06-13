using FLY.Business.Models.Account;
using System.ComponentModel.DataAnnotations;

namespace FLY.Business.Models.Customer
{
    public class UpdateInfoRequest : RegisterRequest
    {
        [MaxLength(12)]
        public int CitizenIdentification { get; set; }
        [MaxLength(10)]
        public int TaxCode { get; set; }
    }
}

using FLY.Business.Models.Customer;

namespace FLY.Business.Services
{
    public interface ICustomerService
    {
        Task<bool> UpdateCustomerInformation(UpdateInfoRequest request);
    }
}
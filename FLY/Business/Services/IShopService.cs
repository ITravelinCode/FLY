using FLY.Business.Models.Shop;

namespace FLY.Business.Services
{
    public interface IShopService
    {
        Task<List<ShopResponse>> GetAllShopsAsync();
        Task<ShopResponse> GetShopByIdAsync(int id);
    }
}
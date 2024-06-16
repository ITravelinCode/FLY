using FLY.Business.Models.Product;

namespace FLY.Business.Services
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetAllProductsAsync();
        Task<ProductResponse> GetProductByIdAsync(int id);
        Task<List<ProductResponse>> GetProductsByCategoryAsync(string categoryName);
        Task<List<ProductResponse>> GetProductsByNameAsync(string name);
    }
}
using AutoMapper;
using FLY.Business.Models.Product;
using FLY.Business.Models.Shop;
using FLY.DataAccess.Repositories;
using FLY.DataAccess.Repositories.Implements;

namespace FLY.Business.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductResponse>> GetAllProductsAsync()
        {
            try
            {
                var productList = await _unitOfWork.ProductRepository.GetAsync(null, null, "ProductCategory,Shop");
                var result = _mapper.Map<List<ProductResponse>>(productList.ToList());
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIDAsync(id);
                var result = _mapper.Map<ProductResponse>(product);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductResponse>> GetProductsByCategoryAsync(string categoryName)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.FindAsync(p => p.ProductCategory.ProductCategoryName == categoryName);
                return _mapper.Map<List<ProductResponse>>(products.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductResponse>> GetProductsByNameAsync(string name)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.FindAsync(p => p.ProductName.Contains(name));
                return _mapper.Map<List<ProductResponse>>(products.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

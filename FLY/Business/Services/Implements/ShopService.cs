using AutoMapper;
using FLY.Business.Models.Shop;
using FLY.DataAccess.Repositories;
using FLY.DataAccess.Repositories.Implements;

namespace FLY.Business.Services.Implements
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShopService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ShopResponse>> GetAllShopsAsync()
        {
            try
            {
                var shopList = await _unitOfWork.ShopRepository.GetAsync();
                var result = _mapper.Map<List<ShopResponse>>(shopList.ToList());
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ShopResponse> GetShopByIdAsync(int id)
        {
            try
            {
                var shop = await _unitOfWork.ShopRepository.GetByIDAsync(id);
                var result = _mapper.Map<ShopResponse>(shop);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ShopResponse>> GetShopByNameAsync(string name)
        {
            try
            {
                var shops = await _unitOfWork.ShopRepository.FindAsync(s => s.ShopName.Contains(name));
                var result = _mapper.Map<List<ShopResponse>>(shops.ToList());
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

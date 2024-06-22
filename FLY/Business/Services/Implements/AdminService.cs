﻿using AutoMapper;
using FLY.Business.Exceptions;
using FLY.Business.Models.Product;
using FLY.Business.Models.Shop;
using FLY.DataAccess.Repositories;
using System.Net;

namespace FLY.Business.Services.Implements
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //ManagerShopAccount
        public async Task<bool> UpdateShopStatus(ShopRequest request)
        {
            var shops = await _unitOfWork.ShopRepository.FindAsync(a => a.ShopId == request.ShopId);
            var existedShops = shops.FirstOrDefault();
            if (existedShops == null)
            {
                throw new ApiException(HttpStatusCode.BadRequest, "Your shop is not existed");
            }

            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    _mapper.Map(existedShops, request);
                    await _unitOfWork.ShopRepository.UpdateAsync(existedShops);
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        public async Task<bool> DeleteShop(ShopRequest request)
        {
            var shops = await _unitOfWork.ShopRepository.FindAsync(a => a.ShopId == request.ShopId);
            var existedShops = shops.FirstOrDefault();
            if (existedShops == null)
            {
                throw new ApiException(HttpStatusCode.BadRequest, "Your product is not existed");
            }

            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    _mapper.Map(existedShops, request);
                    await _unitOfWork.ShopRepository.DeleteAsync(existedShops);
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}

using AutoMapper;
using FLY.Business.Exceptions;
using FLY.Business.Models.Customer;
using FLY.DataAccess.Entities;
using FLY.DataAccess.Repositories;
using System.Net;

namespace FLY.Business.Services.Implements
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> UpdateCustomerInformation(UpdateInfoRequest request)
        {
            var accounts = await _unitOfWork.AccountRepository.FindAsync(a => a.Email == request.Email);
            var existedAccount = accounts.FirstOrDefault();
            if (existedAccount == null)
            {
                throw new ApiException(HttpStatusCode.BadRequest,"Your account is not existed");
            }

            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    _mapper.Map(request, existedAccount);
                    await _unitOfWork.AccountRepository.UpdateAsync(existedAccount);
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

using AutoMapper;
using FLY.Business.Models.Account;
using FLY.DataAccess.Entities;

namespace FLY.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Account, AuthResponse>();
            CreateMap<RegisterRequest, Account>();
        }
    }
}

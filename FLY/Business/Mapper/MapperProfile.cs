using AutoMapper;
using FLY.Business.Models.Account;
using FLY.Business.Models.Customer;
using FLY.Business.Models.Feedback;
using FLY.Business.Models.Product;
using FLY.Business.Models.ProductCategory;
using FLY.Business.Models.Rating;
using FLY.Business.Models.Shop;
using FLY.DataAccess.Entities;

namespace FLY.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            ///Mapper Authentication
            CreateMap<Account, AuthResponse>();
            CreateMap<RegisterRequest, Account>();
            ///Mapper Shop
            CreateMap<Shop, ShopResponse>();
            CreateMap<ShopRequest, Shop>();
            ///Mapper Product
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductRequest, Product>();
            ///Mapper Feedback
            CreateMap<Feedback, FeedbackResponse>();
            CreateMap<FeedbackRequest, Feedback>();
            ///Mapper Rating
            CreateMap<Rating, RatingResponse>();
            CreateMap<RatingRequest, Rating>();
            ///Mapper ProductCategory
            CreateMap<ProductCategory, ProductCategoryResponse>();
            ///Mapper Customer
            CreateMap<UpdateInfoRequest, Account>();
        }
    }
}

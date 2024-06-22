﻿using AutoMapper;
using FLY.Business.Models.Account;
using FLY.Business.Models.Customer;
using FLY.Business.Models.Feedback;
using FLY.Business.Models.Order;
using FLY.Business.Models.OrderDetail;
using FLY.Business.Models.Product;
using FLY.Business.Models.ProductCategory;
using FLY.Business.Models.Rating;
using FLY.Business.Models.Shop;
using FLY.Business.Models.VoucherOfShop;
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
            ///Mapper Voucher
            CreateMap<VoucherOfshop, VoucherOfShopResponse>();
            CreateMap<VoucherOfShopRequest, VoucherOfshop>();
            ///Mapper Order
            CreateMap<Order, OrderResponse>();
            CreateMap<OrderResponse, Order>();
            ///Mapper OrderDetail
            CreateMap<OrderDetail, OrderDetailResponse>();
            CreateMap<OrderDetailRequest, OrderDetail>();
        }
    }
}

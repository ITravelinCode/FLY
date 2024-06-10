using FLY.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace FLY.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        Task SaveAsync();
        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<AccountShop> AccountShopRepository { get; }
        IGenericRepository<Blog> BlogRepository { get; }
        IGenericRepository<Cart> CartRepository { get; }
        IGenericRepository<Feedback> FeedbackRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
        IGenericRepository<Rating> RatingRepository { get; }
        IGenericRepository<RefreshToken> RefreshTokenRepository { get; }
        IGenericRepository<Shop> ShopRepository { get; }
        IGenericRepository<VoucherOfshop> VoucherOfshopRepository { get; }

    }
}

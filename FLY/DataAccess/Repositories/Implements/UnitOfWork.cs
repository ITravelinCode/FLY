using FLY.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace FLY.DataAccess.Repositories.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(FlyContext context)
        {
            this.context = context;
        }

        private readonly FlyContext context;
        private GenericRepository<Account> _accountRepository;
        private GenericRepository<AccountShop> _accountShopRepository;
        private GenericRepository<Blog> _blogRepository;
        private GenericRepository<Cart> _cartRepository;
        private GenericRepository<Feedback> _feedbackRepository;
        private GenericRepository<Order> _orderRepository;
        private GenericRepository<OrderDetail> _orderDetailRepository;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<ProductCategory> _productCategoryRepository;
        private GenericRepository<Rating> _ratingRepository;
        private GenericRepository<RefreshToken> _refreshTokenRepository;
        private GenericRepository<Shop> _shopRepository;
        private GenericRepository<VoucherOfshop> _voucherOfshopRepository;

        public IGenericRepository<Account> AccountRepository => _accountRepository ??= new GenericRepository<Account>(context);
        public IGenericRepository<AccountShop> AccountShopRepository => _accountShopRepository ??= new GenericRepository<AccountShop>(context);
        public IGenericRepository<Blog> BlogRepository => _blogRepository ??= new GenericRepository<Blog>(context);
        public IGenericRepository<Cart> CartRepository => _cartRepository ??= new GenericRepository<Cart>(context);
        public IGenericRepository<Feedback> FeedbackRepository => _feedbackRepository ??= new GenericRepository<Feedback>(context);
        public IGenericRepository<Order> OrderRepository => _orderRepository ??= new GenericRepository<Order>(context);
        public IGenericRepository<OrderDetail> OrderDetailRepository => _orderDetailRepository ??= new GenericRepository<OrderDetail>(context);
        public IGenericRepository<Product> ProductRepository => _productRepository ??= new GenericRepository<Product>(context);
        public IGenericRepository<ProductCategory> ProductCategoryRepository => _productCategoryRepository ??= new GenericRepository<ProductCategory>(context);
        public IGenericRepository<Rating> RatingRepository => _ratingRepository ??= new GenericRepository<Rating>(context);
        public IGenericRepository<RefreshToken> RefreshTokenRepository => _refreshTokenRepository ??= new GenericRepository<RefreshToken>(context);
        public IGenericRepository<Shop> ShopRepository => _shopRepository ??= new GenericRepository<Shop>(context);
        public IGenericRepository<VoucherOfshop> VoucherOfshopRepository => _voucherOfshopRepository ??= new GenericRepository<VoucherOfshop>(context);

        public IDbContextTransaction BeginTransaction()
        {
            return context.Database.BeginTransaction();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

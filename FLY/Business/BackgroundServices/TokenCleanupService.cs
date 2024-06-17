
using FLY.DataAccess.Entities;
using Microsoft.DotNet.Scaffolding.Shared;

namespace FLY.Business.BackgroundServices
{
    public class TokenCleanupService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public TokenCleanupService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(7));
            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<FlyContext>();
                var expiredToken = dbContext.RefreshTokens.Where(rt => rt.ExpiredDate < DateTime.UtcNow).ToList();
                if(expiredToken.Any())
                {
                    dbContext.RemoveRange(expiredToken);
                    dbContext.SaveChanges();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}

using System;

namespace BungBungShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BungBungShopDbContext Init();
    }
}
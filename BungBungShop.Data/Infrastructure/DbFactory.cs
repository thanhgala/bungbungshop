using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungBungShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        BungBungShopDbContext dbContext;
        public BungBungShopDbContext Init()
        {
            return dbContext ?? (dbContext = new BungBungShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}

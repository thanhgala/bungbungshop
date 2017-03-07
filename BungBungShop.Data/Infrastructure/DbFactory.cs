namespace BungBungShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BungBungShopDbContext dbContext;

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
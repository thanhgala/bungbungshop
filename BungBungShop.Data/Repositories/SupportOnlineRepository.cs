using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface ISupportOnlineRepository
    {
    }

    public class SupportOnlineRepository : RepositoryBase<Product>, ISupportOnlineRepository
    {
        public SupportOnlineRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface ISystemConfigRepository
    {
    }

    public class SystemConfigRepository : RepositoryBase<Product>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
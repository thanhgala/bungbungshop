using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IPagerRepository
    {
    }

    public class PageRepository : RepositoryBase<Product>, IPagerRepository
    {
        public PageRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
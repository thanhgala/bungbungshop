using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IMenuRepository
    {
    }

    public class MenuRepository : RepositoryBase<Product>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
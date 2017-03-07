using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IMenuGroupRepository
    {
    }

    public class MenuGroupRepository : RepositoryBase<Product>, IMenuGroupRepository
    {
        public MenuGroupRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
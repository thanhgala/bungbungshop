using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IFooterRepository
    {
    }

    public class FooterRepository : RepositoryBase<Product>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
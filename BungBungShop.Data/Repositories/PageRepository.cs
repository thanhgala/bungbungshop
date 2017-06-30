using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IPagerRepository : IRepository<Page>
    {
    }

    public class PageRepository : RepositoryBase<Page>, IPagerRepository
    {
        public PageRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
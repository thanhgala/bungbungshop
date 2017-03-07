using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IVisitorStatisticRepository
    {
    }

    public class VisitorStatisticRepository : RepositoryBase<Product>, IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
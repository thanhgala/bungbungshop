using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IOrderDetailRepository
    {
    }

    public class OrderDetailRepository : RepositoryBase<Product>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
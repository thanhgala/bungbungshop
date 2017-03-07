using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IProductTagRepository
    {
    }

    public class ProductTagRepository : RepositoryBase<Product>, IProductTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
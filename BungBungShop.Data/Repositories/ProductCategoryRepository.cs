using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace BungBungShop.Data.Repositories
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategoryRepository>, IProductCategoryRepository
    {
        public ProductCategoryRepository(DbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(n => n.Alias == alias);
        }
    }
}
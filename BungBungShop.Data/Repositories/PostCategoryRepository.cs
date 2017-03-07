using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IPostCategoryRepository
    {
    }

    public class PostCategoryRepository : RepositoryBase<Product>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
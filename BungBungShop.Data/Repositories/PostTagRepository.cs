using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IPostTagRepository
    {
    }

    public class PostTagRepository : RepositoryBase<Product>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface ITagRepository
    {
    }

    public class TagRepository : RepositoryBase<Product>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
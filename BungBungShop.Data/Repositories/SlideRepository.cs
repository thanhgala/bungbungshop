using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface ISlideTagRepository
    {
    }

    public class SlideTagRepository : RepositoryBase<Product>, ISlideTagRepository
    {
        public SlideTagRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
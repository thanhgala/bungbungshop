using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface ISlideTagRepository : IRepository<Slide>
    {
    }

    public class SlideTagRepository : RepositoryBase<Slide>, ISlideTagRepository
    {
        public SlideTagRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
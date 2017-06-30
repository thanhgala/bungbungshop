using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungBungShop.Data.Repositories
{
    public interface IFeedBackRepository : IRepository<Feedback>
    {

    }

    public class FeedBackRepository : RepositoryBase<Feedback>, IFeedBackRepository
    {
        public FeedBackRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

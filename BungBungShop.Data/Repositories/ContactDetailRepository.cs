﻿using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungBungShop.Data.Repositories
{
    public interface IContactDetailRepository : IRepository<ContactDetail>
    {

    }

    public class ContactDetailRepository : RepositoryBase<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

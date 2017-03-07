﻿using BungBungShop.Data.Infrastructure;
using BungBungShop.Model.Models;

namespace BungBungShop.Data.Repositories
{
    public interface IProductRepository
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
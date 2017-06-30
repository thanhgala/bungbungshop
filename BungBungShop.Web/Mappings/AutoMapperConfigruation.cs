using AutoMapper;
using BungBungShop.Model.Models;
using BungBungShop.Web.Models;

namespace BungBungShop.Web.Mappings
{
    public class AutoMapperConfigruation
    {
        public static void Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();

            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();
        }
    }
}
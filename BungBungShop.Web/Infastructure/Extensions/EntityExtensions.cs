﻿using BungBungShop.Model.Models;
using BungBungShop.Web.Models;

namespace BungBungShop.Web.Infastructure.Extensions
{
    //Tạo ra các phương thức mở rộng cho các class
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVM)
        {
            postCategory.ID = postCategoryVM.ID;
            postCategory.Name = postCategoryVM.Name;
            postCategory.Alias = postCategoryVM.Alias;
            postCategory.Description = postCategoryVM.Description;
            postCategory.ParentID = postCategoryVM.ParentID;
            postCategory.DisplayOrder = postCategoryVM.DisplayOrder;
            postCategory.Image = postCategoryVM.Image;
            postCategory.HomeFlag = postCategoryVM.HomeFlag;

            postCategory.CreatedDate = postCategoryVM.CreatedDate;
            postCategory.CreatedBy = postCategoryVM.CreatedBy;
            postCategory.UpdatedDate = postCategoryVM.UpdatedDate;
            postCategory.UpdateBy = postCategoryVM.UpdateBy;
            postCategory.MetaKeyword = postCategoryVM.MetaKeyword;
            postCategory.MetaDescription = postCategoryVM.MetaDescription;
            postCategory.Status = postCategoryVM.Status;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVM)
        {
            productCategory.ID = productCategoryVM.ID;
            productCategory.Name = productCategoryVM.Name;
            productCategory.Alias = productCategoryVM.Alias;
            productCategory.Description = productCategoryVM.Description;
            productCategory.ParentID = productCategoryVM.ParentID;
            productCategory.DisplayOrder = productCategoryVM.DisplayOrder;
            productCategory.Image = productCategoryVM.Image;
            productCategory.HomeFlag = productCategoryVM.HomeFlag;

            productCategory.CreatedDate = productCategoryVM.CreatedDate;
            productCategory.CreatedBy = productCategoryVM.CreatedBy;
            productCategory.UpdatedDate = productCategoryVM.UpdatedDate;
            productCategory.UpdateBy = productCategoryVM.UpdateBy;
            productCategory.MetaKeyword = productCategoryVM.MetaKeyword;
            productCategory.MetaDescription = productCategoryVM.MetaDescription;
            productCategory.Status = productCategoryVM.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postVM)
        {
            post.ID = postVM.ID;
            post.Name = postVM.Name;
            post.Alias = postVM.Alias;
            post.Description = postVM.Description;
            post.CategoryID = postVM.CategoryID;
            post.Content = postVM.Content;
            post.Image = postVM.Image;
            post.HomeFlag = postVM.HomeFlag;
            post.ViewCount = postVM.ViewCount;

            post.CreatedDate = postVM.CreatedDate;
            post.CreatedBy = postVM.CreatedBy;
            post.UpdatedDate = postVM.UpdatedDate;
            post.UpdateBy = postVM.UpdateBy;
            post.MetaKeyword = postVM.MetaKeyword;
            post.MetaDescription = postVM.MetaDescription;
            post.Status = postVM.Status;
        }


    }
}
using AutoMapper;
using BungBungShop.Model.Models;
using BungBungShop.Service;
using BungBungShop.Web.Infastructure.Core;
using BungBungShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BungBungShop.Web.Infastructure.Extensions;
using System.Web.Script.Serialization;

namespace BungBungShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        #region Initialize
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }
        #endregion

        //lấy toàn bộ danh mục sản phẩm và phân trang 
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request,string keyword, int page, int pageSize = 20)
        {
            return CreateHttpRespond(request, () =>
            {
                int totalRow = 0;
                var model = _productCategoryService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderBy(n => n.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var reponseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = reponseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        //lấy toàn bộ các danh mục sản phẩm
        [Route("getallparent")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpRespond(request, () =>
             {
                 var model = _productCategoryService.GetAll();
                 var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);

                 return request.CreateResponse(HttpStatusCode.OK, responseData);
             });
        }

        //lấy danh mục theo id từ tham số trên url
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetByID(HttpRequestMessage request,int id)
        {
            return CreateHttpRespond(request, () =>
            {
                var model = _productCategoryService.GetByID(id);
                var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);

                return request.CreateResponse(HttpStatusCode.OK, responseData);
            });
        }

        //tạo mới 1 danh mục
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryVM)
        {
            return CreateHttpRespond(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                var newProductCategory = new ProductCategory();
                newProductCategory.UpdateProductCategory(productCategoryVM);
                newProductCategory.CreatedDate = DateTime.Now;
                _productCategoryService.Add(newProductCategory);
                _productCategoryService.Save();

                var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                response = request.CreateResponse(HttpStatusCode.Created, responseData);
                return response;
            });
        }

        //update 1 danh mục
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryVM)
        {
            return CreateHttpRespond(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProductCategory = _productCategoryService.GetByID(productCategoryVM.ID);

                    dbProductCategory.UpdateProductCategory(productCategoryVM);
                    dbProductCategory.UpdatedDate = DateTime.Now;
                    _productCategoryService.Update(dbProductCategory);
                    _productCategoryService.Save();

                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(dbProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var model = _productCategoryService.Delete(id);
                _productCategoryService.Save();

                var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);
                response = request.CreateResponse(HttpStatusCode.OK, responseData);
            }
            return response;
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProductCategories)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);
                foreach (var item in listProductCategory)
                {
                    _productCategoryService.Delete(item);
                } 
                _productCategoryService.Save();

                response = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
            }
            return response;
        }
    }
}
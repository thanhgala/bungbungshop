using BungBungShop.Web.Infastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BungBungShop.Service;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Http.Results;

namespace BungBungShop.Web.Api
{
    [RoutePrefix("api/post")]
    public class PostController : ApiControllerBase
    {
        private IPostService _postService;

        public PostController(IErrorService errorService, IPostService postService) : base(errorService)
        {
            this._postService = postService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpRespond(request, () =>
            {
                var listPost = _postService.GetAll();
                //Map giá trị từ model wa viewModel
                //var listPostCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPost);
                return response;
            });
        }
    }
}

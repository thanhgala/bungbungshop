using BungBungShop.Web.Infastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BungBungShop.Service;

namespace BungBungShop.Web.Api
{
    [RoutePrefix("api/tag")]
    public class TagController : ApiControllerBase
    {
        private ITagService _tagService;

        public TagController(IErrorService errorService, ITagService tagService) : base(errorService)
        {
            this._tagService = tagService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpRespond(request, () =>
             {
                 var model = _tagService.GetAll();
                 HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);
                 return response;
             });
        }

    }
}

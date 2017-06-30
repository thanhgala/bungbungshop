using BungBungShop.Service;
using BungBungShop.Web.Infastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BungBungShop.Web.Api
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IErrorService errorService, IOrderService orderService) : base(errorService)
        {
            this._orderService = orderService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpRespond(request, () =>
            {
                var model = _orderService.GetAll();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }

    }
}

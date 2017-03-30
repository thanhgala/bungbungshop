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
    [RoutePrefix("api/orderdetail")]
    public class OrderDetailController : ApiControllerBase
    {
        private IOrderDetailService _orderDetailService;

        public OrderDetailController(IErrorService errorService, IOrderDetailService orderDetailService) : base(errorService)
        {
            this._orderDetailService = orderDetailService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpRespond(request, () =>
            {
                var model = _orderDetailService.GetAll();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }

    }
}

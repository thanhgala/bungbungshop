using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BungBungShop.Web.Models
{
    //chuyển sang nhị phân hóa để gán 1 đối tượng hay seesion
    [Serializable]
    public class ShoppingCartViewModel
    {
        public int ProductId { set; get; }

        public ProductViewModel Product { set; get; }

        public int Quantity { set; get; }
    }
}
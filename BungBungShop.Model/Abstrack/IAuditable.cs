using System;

namespace BungBungShop.Model.Abstrack
{
    public interface IAuditable
    {
        DateTime? CreatedDate { set; get; }
        string CreatedBy { set; get; }
        DateTime? UpdatedDate { set; get; }
        string UpdateBy { set; get; }

        bool Status { set; get; }

        string MetaKeyword { set; get; }
        string MetaDescription { set; get; }

    }
}
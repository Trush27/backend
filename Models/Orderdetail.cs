using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Orderdetail
{
    public int Orderdetailid { get; set; }

    public int Itemid { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public int Orderid { get; set; }

    public int Invoiceid { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Menuitem Item { get; set; } = null!;

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual Customerorder Order { get; set; } = null!;
}

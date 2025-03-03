using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Kot
{
    public int Kotid { get; set; }

    public int? Orderid { get; set; }

    public int? Tableid { get; set; }

    public int? Sectionid { get; set; }

    public int? Itemid { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Menuitem? Item { get; set; }

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual Customerorder? Order { get; set; }

    public virtual Section? Section { get; set; }

    public virtual Dinetable? Table { get; set; }
}

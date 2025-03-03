using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Menuitem
{
    public int Itemid { get; set; }

    public int Categoryid { get; set; }

    public string Itemname { get; set; } = null!;

    public string Itemtype { get; set; } = null!;

    public int Rate { get; set; }

    public int Quantity { get; set; }

    public bool Available { get; set; }

    public string? Shortcode { get; set; }

    public string? Itemimage { get; set; }

    public string? Description { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public bool? Isfavourite { get; set; }

    public bool? Isdefaulttax { get; set; }

    public int Taxid { get; set; }

    public virtual Menucategory Category { get; set; } = null!;

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual ICollection<Kot> Kots { get; } = new List<Kot>();

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; } = new List<Orderdetail>();

    public virtual Tax Tax { get; set; } = null!;
}

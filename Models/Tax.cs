using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Tax
{
    public int Taxid { get; set; }

    public string Taxname { get; set; } = null!;

    public string Taxtype { get; set; } = null!;

    public bool Isenabled { get; set; }

    public bool Isdefaulttax { get; set; }

    public int Taxamount { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual ICollection<Menuitem> Menuitems { get; } = new List<Menuitem>();

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Ordertax> Ordertaxes { get; } = new List<Ordertax>();
}

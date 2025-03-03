using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Menucategory
{
    public int Categoryid { get; set; }

    public int Modifiergroupid { get; set; }

    public string Categoryname { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual ICollection<Menuitem> Menuitems { get; } = new List<Menuitem>();

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual Modifiergroup Modifiergroup { get; set; } = null!;
}

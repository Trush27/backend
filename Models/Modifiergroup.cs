using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Modifiergroup
{
    public int Modifiergroupid { get; set; }

    public string Modifiergroupname { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public string? Description { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual ICollection<Menucategory> Menucategories { get; } = new List<Menucategory>();

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Modifier> Modifiers { get; } = new List<Modifier>();
}

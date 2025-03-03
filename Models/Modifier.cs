using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Modifier
{
    public int Modifierid { get; set; }

    public int Modifiergroupid { get; set; }

    public string Modifiername { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public int Rate { get; set; }

    public int Quantity { get; set; }

    public string? Description { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual Modifiergroup Modifiergroup { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Waitinglist
{
    public int Tokenid { get; set; }

    public int Customerid { get; set; }

    public int Numberofperson { get; set; }

    public int Sectionid { get; set; }

    public TimeOnly? Waitingtime { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public int Tableid { get; set; }

    public bool Isassigned { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual Section Section { get; set; } = null!;

    public virtual Dinetable Table { get; set; } = null!;
}

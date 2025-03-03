using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Dinetable
{
    public int Tableid { get; set; }

    public int Sectionid { get; set; }

    public string Tablename { get; set; } = null!;

    public int Capacity { get; set; }

    public bool Status { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual ICollection<Kot> Kots { get; } = new List<Kot>();

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual Section Section { get; set; } = null!;

    public virtual ICollection<Waitinglist> Waitinglists { get; } = new List<Waitinglist>();
}

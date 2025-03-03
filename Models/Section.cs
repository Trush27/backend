using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Section
{
    public int Sectionid { get; set; }

    public string Sectionname { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual ICollection<Dinetable> Dinetables { get; } = new List<Dinetable>();

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual ICollection<Kot> Kots { get; } = new List<Kot>();

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Waitinglist> Waitinglists { get; } = new List<Waitinglist>();
}

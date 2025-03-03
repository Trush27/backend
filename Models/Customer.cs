using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Customer
{
    public int Customerid { get; set; }

    public string Customername { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int Totalorder { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Userlogin CustomerNavigation { get; set; } = null!;

    public virtual ICollection<Customerorder> Customerorders { get; } = new List<Customerorder>();

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Waitinglist> Waitinglists { get; } = new List<Waitinglist>();
}

using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Customerorder
{
    public int Orderid { get; set; }

    public int Customerid { get; set; }

    public DateOnly Date { get; set; }

    public int Capacity { get; set; }

    public bool Status { get; set; }

    public string Paymentmode { get; set; } = null!;

    public int Rating { get; set; }

    public int Totalamount { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual ICollection<Kot> Kots { get; } = new List<Kot>();

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; } = new List<Orderdetail>();

    public virtual ICollection<Ordertax> Ordertaxes { get; } = new List<Ordertax>();
}

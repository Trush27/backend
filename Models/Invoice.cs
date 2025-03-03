using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Invoice
{
    public int Invoiceid { get; set; }

    public int? Orderid { get; set; }

    public int? Customerid { get; set; }

    public int? Tableid { get; set; }

    public int? Taxid { get; set; }

    public int? Sectionid { get; set; }

    public TimeOnly Waitingtime { get; set; }

    public string Paymentmode { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual Customerorder? Order { get; set; }

    public virtual Section? Section { get; set; }

    public virtual Dinetable? Table { get; set; }

    public virtual Tax? Tax { get; set; }
}

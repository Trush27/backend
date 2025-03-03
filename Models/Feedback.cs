using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Feedback
{
    public int Feedbackid { get; set; }

    public int? Orderid { get; set; }

    public int? Customerid { get; set; }

    public string? Ordercomment { get; set; }

    public string? Itemcomment { get; set; }

    public int? Food { get; set; }

    public int? Ambience { get; set; }

    public int? Service { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual Customerorder? Order { get; set; }
}

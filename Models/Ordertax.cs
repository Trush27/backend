using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Ordertax
{
    public int Ordertaxid { get; set; }

    public int? Orderid { get; set; }

    public int? Taxid { get; set; }

    public double Taxvalue { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual Customerorder? Order { get; set; }

    public virtual Tax? Tax { get; set; }
}

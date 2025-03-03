using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Userpermission
{
    public int Permissionid { get; set; }

    public string Permissionname { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Roleandpermission> Roleandpermissions { get; } = new List<Roleandpermission>();
}

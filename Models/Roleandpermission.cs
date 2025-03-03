using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Roleandpermission
{
    public int Rapid { get; set; }

    public int? Roleid { get; set; }

    public int? Permissionid { get; set; }

    public bool? Canview { get; set; }

    public bool? Canaddedit { get; set; }

    public bool? Candelete { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Userlogin? CreatedbyNavigation { get; set; }

    public virtual Userlogin? ModifiedbyNavigation { get; set; }

    public virtual Userpermission? Permission { get; set; }

    public virtual Userrole? Role { get; set; }
}

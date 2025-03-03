using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Userlogin
{
    public int Userid { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Createddate { get; set; }

    public DateTime? Modifieddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public bool Isdeleted { get; set; }

    public int? Roleid{ get; set; }

    public virtual ICollection<City> CityCreatedbyNavigations { get; } = new List<City>();

    public virtual ICollection<City> CityModifiedbyNavigations { get; } = new List<City>();

    public virtual ICollection<Country> CountryCreatedbyNavigations { get; } = new List<Country>();

    public virtual ICollection<Country> CountryModifiedbyNavigations { get; } = new List<Country>();

    public virtual ICollection<Customer> CustomerCreatedbyNavigations { get; } = new List<Customer>();

    public virtual Customer? CustomerCustomerNavigation { get; set; }

    public virtual ICollection<Customer> CustomerModifiedbyNavigations { get; } = new List<Customer>();

    public virtual ICollection<Customerorder> CustomerorderCreatedbyNavigations { get; } = new List<Customerorder>();

    public virtual ICollection<Customerorder> CustomerorderModifiedbyNavigations { get; } = new List<Customerorder>();

    public virtual ICollection<Dinetable> DinetableCreatedbyNavigations { get; } = new List<Dinetable>();

    public virtual ICollection<Dinetable> DinetableModifiedbyNavigations { get; } = new List<Dinetable>();

    public virtual ICollection<Feedback> FeedbackCreatedbyNavigations { get; } = new List<Feedback>();

    public virtual ICollection<Feedback> FeedbackModifiedbyNavigations { get; } = new List<Feedback>();

    public virtual ICollection<Invoice> InvoiceCreatedbyNavigations { get; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceModifiedbyNavigations { get; } = new List<Invoice>();

    public virtual ICollection<Kot> KotCreatedbyNavigations { get; } = new List<Kot>();

    public virtual ICollection<Kot> KotModifiedbyNavigations { get; } = new List<Kot>();

    public virtual ICollection<Menucategory> MenucategoryCreatedbyNavigations { get; } = new List<Menucategory>();

    public virtual ICollection<Menucategory> MenucategoryModifiedbyNavigations { get; } = new List<Menucategory>();

    public virtual ICollection<Menuitem> MenuitemCreatedbyNavigations { get; } = new List<Menuitem>();

    public virtual ICollection<Menuitem> MenuitemModifiedbyNavigations { get; } = new List<Menuitem>();

    public virtual ICollection<Modifier> ModifierCreatedbyNavigations { get; } = new List<Modifier>();

    public virtual ICollection<Modifier> ModifierModifiedbyNavigations { get; } = new List<Modifier>();

    public virtual ICollection<Modifiergroup> ModifiergroupCreatedbyNavigations { get; } = new List<Modifiergroup>();

    public virtual ICollection<Modifiergroup> ModifiergroupModifiedbyNavigations { get; } = new List<Modifiergroup>();

    public virtual ICollection<Orderdetail> OrderdetailCreatedbyNavigations { get; } = new List<Orderdetail>();

    public virtual ICollection<Orderdetail> OrderdetailModifiedbyNavigations { get; } = new List<Orderdetail>();

    public virtual ICollection<Ordertax> OrdertaxCreatedbyNavigations { get; } = new List<Ordertax>();

    public virtual ICollection<Ordertax> OrdertaxModifiedbyNavigations { get; } = new List<Ordertax>();

    public virtual Userrole Role { get; set; } = null!;

    public virtual ICollection<Roleandpermission> RoleandpermissionCreatedbyNavigations { get; } = new List<Roleandpermission>();

    public virtual ICollection<Roleandpermission> RoleandpermissionModifiedbyNavigations { get; } = new List<Roleandpermission>();

    public virtual ICollection<Section> SectionCreatedbyNavigations { get; } = new List<Section>();

    public virtual ICollection<Section> SectionModifiedbyNavigations { get; } = new List<Section>();

    public virtual ICollection<State> StateCreatedbyNavigations { get; } = new List<State>();

    public virtual ICollection<State> StateModifiedbyNavigations { get; } = new List<State>();

    public virtual ICollection<Tax> TaxCreatedbyNavigations { get; } = new List<Tax>();

    public virtual ICollection<Tax> TaxModifiedbyNavigations { get; } = new List<Tax>();

    public virtual ICollection<Userpermission> UserpermissionCreatedbyNavigations { get; } = new List<Userpermission>();

    public virtual ICollection<Userpermission> UserpermissionModifiedbyNavigations { get; } = new List<Userpermission>();

    public virtual ICollection<Userrole> UserroleCreatedbyNavigations { get; } = new List<Userrole>();

    public virtual ICollection<Userrole> UserroleModifiedbyNavigations { get; } = new List<Userrole>();

    public virtual ICollection<Waitinglist> WaitinglistCreatedbyNavigations { get; } = new List<Waitinglist>();

    public virtual ICollection<Waitinglist> WaitinglistModifiedbyNavigations { get; } = new List<Waitinglist>();
}
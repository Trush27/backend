using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Customerorder> Customerorders { get; set; }

    public virtual DbSet<Dinetable> Dinetables { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Kot> Kots { get; set; }

    public virtual DbSet<Menucategory> Menucategories { get; set; }

    public virtual DbSet<Menuitem> Menuitems { get; set; }

    public virtual DbSet<Modifier> Modifiers { get; set; }

    public virtual DbSet<Modifiergroup> Modifiergroups { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Ordertax> Ordertaxes { get; set; }

    public virtual DbSet<Roleandpermission> Roleandpermissions { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Tax> Taxes { get; set; }

    public virtual DbSet<Userdetail> Userdetails { get; set; }

    public virtual DbSet<Userlogin> Userlogins { get; set; }

    public virtual DbSet<Userpermission> Userpermissions { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    public virtual DbSet<Waitinglist> Waitinglists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost ;Database=postgres;Username=postgres;     password=Tatva@123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Cityid).HasName("city_pkey");

            entity.ToTable("city");

            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Stateid).HasColumnName("stateid");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CityCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("city_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.CityModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("city_modifiedby_fkey");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.Stateid)
                .HasConstraintName("city_stateid_fkey");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Countryid).HasName("country_pkey");

            entity.ToTable("country");

            entity.Property(e => e.Countryid).HasColumnName("countryid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CountryCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("country_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.CountryModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("country_modifiedby_fkey");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.HasIndex(e => e.Customerid, "uq").IsUnique();

            entity.Property(e => e.Customerid)
                .ValueGeneratedOnAdd()
                .HasColumnName("customerid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Customername)
                .HasMaxLength(50)
                .HasColumnName("customername");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(10)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Totalorder).HasColumnName("totalorder");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CustomerCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("customer_createdby_fkey");

            entity.HasOne(d => d.CustomerNavigation).WithOne(p => p.CustomerCustomerNavigation)
                .HasForeignKey<Customer>(d => d.Customerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_customerid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.CustomerModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("customer_modifiedby_fkey");
        });

        modelBuilder.Entity<Customerorder>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("customerorder_pkey");

            entity.ToTable("customerorder");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Paymentmode)
                .HasMaxLength(50)
                .HasColumnName("paymentmode");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Totalamount).HasColumnName("totalamount");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CustomerorderCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("customerorder_createdby_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Customerorders)
                .HasForeignKey(d => d.Customerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customerorder_customerid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.CustomerorderModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("customerorder_modifiedby_fkey");
        });

        modelBuilder.Entity<Dinetable>(entity =>
        {
            entity.HasKey(e => e.Tableid).HasName("dinetable_pkey");

            entity.ToTable("dinetable");

            entity.Property(e => e.Tableid).HasColumnName("tableid");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Sectionid).HasColumnName("sectionid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Tablename)
                .HasMaxLength(50)
                .HasColumnName("tablename");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.DinetableCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("dinetable_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.DinetableModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("dinetable_modifiedby_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.Dinetables)
                .HasForeignKey(d => d.Sectionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dinetable_sectionid_fkey");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Feedbackid).HasName("feedback_pkey");

            entity.ToTable("feedback");

            entity.Property(e => e.Feedbackid).HasColumnName("feedbackid");
            entity.Property(e => e.Ambience).HasColumnName("ambience");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Food).HasColumnName("food");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Itemcomment)
                .HasMaxLength(50)
                .HasColumnName("itemcomment");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Ordercomment)
                .HasMaxLength(50)
                .HasColumnName("ordercomment");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Service).HasColumnName("service");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.FeedbackCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("feedback_createdby_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("feedback_customerid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.FeedbackModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("feedback_modifiedby_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("feedback_orderid_fkey");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Invoiceid).HasName("invoice_pkey");

            entity.ToTable("invoice");

            entity.Property(e => e.Invoiceid).HasColumnName("invoiceid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Paymentmode)
                .HasMaxLength(50)
                .HasColumnName("paymentmode");
            entity.Property(e => e.Sectionid).HasColumnName("sectionid");
            entity.Property(e => e.Tableid).HasColumnName("tableid");
            entity.Property(e => e.Taxid).HasColumnName("taxid");
            entity.Property(e => e.Waitingtime).HasColumnName("waitingtime");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.InvoiceCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("invoice_createdby_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("invoice_customerid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.InvoiceModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("invoice_modifiedby_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("invoice_orderid_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Sectionid)
                .HasConstraintName("invoice_sectionid_fkey");

            entity.HasOne(d => d.Table).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Tableid)
                .HasConstraintName("invoice_tableid_fkey");

            entity.HasOne(d => d.Tax).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Taxid)
                .HasConstraintName("invoice_taxid_fkey");
        });

        modelBuilder.Entity<Kot>(entity =>
        {
            entity.HasKey(e => e.Kotid).HasName("kot_pkey");

            entity.ToTable("kot");

            entity.Property(e => e.Kotid).HasColumnName("kotid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Sectionid).HasColumnName("sectionid");
            entity.Property(e => e.Tableid).HasColumnName("tableid");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.KotCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("kot_createdby_fkey");

            entity.HasOne(d => d.Item).WithMany(p => p.Kots)
                .HasForeignKey(d => d.Itemid)
                .HasConstraintName("kot_itemid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.KotModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("kot_modifiedby_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Kots)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("kot_orderid_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.Kots)
                .HasForeignKey(d => d.Sectionid)
                .HasConstraintName("kot_sectionid_fkey");

            entity.HasOne(d => d.Table).WithMany(p => p.Kots)
                .HasForeignKey(d => d.Tableid)
                .HasConstraintName("kot_tableid_fkey");
        });

        modelBuilder.Entity<Menucategory>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("menucategory_pkey");

            entity.ToTable("menucategory");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(50)
                .HasColumnName("categoryname");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Modifiergroupid).HasColumnName("modifiergroupid");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.MenucategoryCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("menucategory_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.MenucategoryModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("menucategory_modifiedby_fkey");

            entity.HasOne(d => d.Modifiergroup).WithMany(p => p.Menucategories)
                .HasForeignKey(d => d.Modifiergroupid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menucategory_modifiergroupid_fkey");
        });

        modelBuilder.Entity<Menuitem>(entity =>
        {
            entity.HasKey(e => e.Itemid).HasName("menuitems_pkey");

            entity.ToTable("menuitems");

            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Isdefaulttax).HasColumnName("isdefaulttax");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Isfavourite).HasColumnName("isfavourite");
            entity.Property(e => e.Itemimage)
                .HasMaxLength(50)
                .HasColumnName("itemimage");
            entity.Property(e => e.Itemname)
                .HasMaxLength(50)
                .HasColumnName("itemname");
            entity.Property(e => e.Itemtype)
                .HasMaxLength(50)
                .HasColumnName("itemtype");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.Shortcode)
                .HasMaxLength(5)
                .HasColumnName("shortcode");
            entity.Property(e => e.Taxid).HasColumnName("taxid");

            entity.HasOne(d => d.Category).WithMany(p => p.Menuitems)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuitems_categoryid_fkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.MenuitemCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("menuitems_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.MenuitemModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("menuitems_modifiedby_fkey");

            entity.HasOne(d => d.Tax).WithMany(p => p.Menuitems)
                .HasForeignKey(d => d.Taxid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuitems_taxid_fkey");
        });

        modelBuilder.Entity<Modifier>(entity =>
        {
            entity.HasKey(e => e.Modifierid).HasName("modifier_pkey");

            entity.ToTable("modifier");

            entity.Property(e => e.Modifierid).HasColumnName("modifierid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Modifiergroupid).HasColumnName("modifiergroupid");
            entity.Property(e => e.Modifiername)
                .HasMaxLength(50)
                .HasColumnName("modifiername");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasColumnName("unit");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.ModifierCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("modifier_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.ModifierModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("modifier_modifiedby_fkey");

            entity.HasOne(d => d.Modifiergroup).WithMany(p => p.Modifiers)
                .HasForeignKey(d => d.Modifiergroupid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("modifier_modifiergroupid_fkey");
        });

        modelBuilder.Entity<Modifiergroup>(entity =>
        {
            entity.HasKey(e => e.Modifiergroupid).HasName("modifiergroup_pkey");

            entity.ToTable("modifiergroup");

            entity.Property(e => e.Modifiergroupid).HasColumnName("modifiergroupid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Modifiergroupname)
                .HasMaxLength(50)
                .HasColumnName("modifiergroupname");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.ModifiergroupCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("modifiergroup_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.ModifiergroupModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("modifiergroup_modifiedby_fkey");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.Orderdetailid).HasName("orderdetail_pkey");

            entity.ToTable("orderdetail");

            entity.Property(e => e.Orderdetailid)
                .HasDefaultValueSql("nextval('orderdetail_orderid_seq'::regclass)")
                .HasColumnName("orderdetailid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Invoiceid).HasColumnName("invoiceid");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Orderid).HasColumnName("orderid");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.OrderdetailCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("orderdetail_createdby_fkey");

            entity.HasOne(d => d.Item).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Itemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderdetail_itemid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.OrderdetailModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("orderdetail_modifiedby_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderdetail_orderid_fkey");
        });

        modelBuilder.Entity<Ordertax>(entity =>
        {
            entity.HasKey(e => e.Ordertaxid).HasName("ordertax_pkey");

            entity.ToTable("ordertax");

            entity.Property(e => e.Ordertaxid).HasColumnName("ordertaxid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Taxid).HasColumnName("taxid");
            entity.Property(e => e.Taxvalue).HasColumnName("taxvalue");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.OrdertaxCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("ordertax_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.OrdertaxModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("ordertax_modifiedby_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Ordertaxes)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("ordertax_orderid_fkey");

            entity.HasOne(d => d.Tax).WithMany(p => p.Ordertaxes)
                .HasForeignKey(d => d.Taxid)
                .HasConstraintName("ordertax_taxid_fkey");
        });

        modelBuilder.Entity<Roleandpermission>(entity =>
        {
            entity.HasKey(e => e.Rapid).HasName("roleandpermission_pkey");

            entity.ToTable("roleandpermission");

            entity.Property(e => e.Rapid).HasColumnName("rapid");
            entity.Property(e => e.Canaddedit).HasColumnName("canaddedit");
            entity.Property(e => e.Candelete).HasColumnName("candelete");
            entity.Property(e => e.Canview).HasColumnName("canview");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Permissionid).HasColumnName("permissionid");
            entity.Property(e => e.Roleid).HasColumnName("roleid");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.RoleandpermissionCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("roleandpermission_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.RoleandpermissionModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("roleandpermission_modifiedby_fkey");

            entity.HasOne(d => d.Permission).WithMany(p => p.Roleandpermissions)
                .HasForeignKey(d => d.Permissionid)
                .HasConstraintName("roleandpermission_permissionid_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Roleandpermissions)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("roleandpermission_roleid_fkey");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Sectionid).HasName("section_pkey");

            entity.ToTable("section");

            entity.Property(e => e.Sectionid).HasColumnName("sectionid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Sectionname)
                .HasMaxLength(50)
                .HasColumnName("sectionname");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.SectionCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("section_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.SectionModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("section_modifiedby_fkey");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Stateid).HasName("state_pkey");

            entity.ToTable("state");

            entity.Property(e => e.Stateid).HasColumnName("stateid");
            entity.Property(e => e.Countryid).HasColumnName("countryid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.Countryid)
                .HasConstraintName("state_countryid_fkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.StateCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("state_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.StateModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("state_modifiedby_fkey");
        });

        modelBuilder.Entity<Tax>(entity =>
        {
            entity.HasKey(e => e.Taxid).HasName("tax_pkey");

            entity.ToTable("tax");

            entity.Property(e => e.Taxid).HasColumnName("taxid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdefaulttax).HasColumnName("isdefaulttax");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Isenabled).HasColumnName("isenabled");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Taxamount).HasColumnName("taxamount");
            entity.Property(e => e.Taxname)
                .HasMaxLength(50)
                .HasColumnName("taxname");
            entity.Property(e => e.Taxtype)
                .HasMaxLength(50)
                .HasColumnName("taxtype");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TaxCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("tax_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.TaxModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("tax_modifiedby_fkey");
        });

        modelBuilder.Entity<Userdetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("userdetail");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.Countryid).HasColumnName("countryid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(10)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Profileimage)
                .HasMaxLength(50)
                .HasColumnName("profileimage");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Stateid).HasColumnName("stateid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(10)
                .HasColumnName("zipcode");

            entity.HasOne(d => d.City).WithMany()
                .HasForeignKey(d => d.Cityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_cityid_fkey");

            entity.HasOne(d => d.Country).WithMany()
                .HasForeignKey(d => d.Countryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_countryid_fkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany()
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("userdetail_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany()
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("userdetail_modifiedby_fkey");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_roleid_fkey");

            entity.HasOne(d => d.State).WithMany()
                .HasForeignKey(d => d.Stateid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_stateid_fkey");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_userid_fkey");
        });

        modelBuilder.Entity<Userlogin>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("userlogin_pkey");

            entity.ToTable("userlogin");

            entity.HasIndex(e => e.Email, "userlogin_email_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Roleid).HasColumnName("roleid");

            entity.HasOne(d => d.Role).WithMany(p => p.Userlogins)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userlogin_roleid_fkey");
        });

        modelBuilder.Entity<Userpermission>(entity =>
        {
            entity.HasKey(e => e.Permissionid).HasName("userpermissions_pkey");

            entity.ToTable("userpermissions");

            entity.Property(e => e.Permissionid).HasColumnName("permissionid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Permissionname)
                .HasMaxLength(50)
                .HasColumnName("permissionname");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.UserpermissionCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("userpermissions_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.UserpermissionModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("userpermissions_modifiedby_fkey");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("userrole_pkey");

            entity.ToTable("userrole");

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .HasColumnName("rolename");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.UserroleCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("userrole_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.UserroleModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("userrole_modifiedby_fkey");
        });

        modelBuilder.Entity<Waitinglist>(entity =>
        {
            entity.HasKey(e => e.Tokenid).HasName("waitinglist_pkey");

            entity.ToTable("waitinglist");

            entity.Property(e => e.Tokenid).HasColumnName("tokenid");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Isassigned).HasColumnName("isassigned");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Numberofperson).HasColumnName("numberofperson");
            entity.Property(e => e.Sectionid).HasColumnName("sectionid");
            entity.Property(e => e.Tableid).HasColumnName("tableid");
            entity.Property(e => e.Waitingtime).HasColumnName("waitingtime");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.WaitinglistCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("waitinglist_createdby_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Waitinglists)
                .HasForeignKey(d => d.Customerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("waitinglist_customerid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.WaitinglistModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("waitinglist_modifiedby_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.Waitinglists)
                .HasForeignKey(d => d.Sectionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("waitinglist_sectionid_fkey");

            entity.HasOne(d => d.Table).WithMany(p => p.Waitinglists)
                .HasForeignKey(d => d.Tableid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("waitinglist_tableid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

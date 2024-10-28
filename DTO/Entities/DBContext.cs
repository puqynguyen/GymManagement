using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DTO.Entities
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext1")
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<CustomerMembership> CustomerMemberships { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual DbSet<Supplement> Supplements { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .Property(e => e.class_type)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Customers)
                .WithMany(e => e.Classes)
                .Map(m => m.ToTable("CustomerClass").MapLeftKey("ClassID").MapRightKey("CustomerID"));

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Instructors)
                .WithMany(e => e.Classes)
                .Map(m => m.ToTable("InstructorClass").MapLeftKey("ClassID").MapRightKey("InstructorID"));

            modelBuilder.Entity<Customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.contact_info)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerMemberships)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.brand)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.condition)
                .IsUnicode(false);

            modelBuilder.Entity<Instructor>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Instructor>()
                .Property(e => e.SSN)
                .IsUnicode(false);

            modelBuilder.Entity<Instructor>()
                .Property(e => e.certifications)
                .IsUnicode(false);

            modelBuilder.Entity<Membership>()
                .Property(e => e.membership_level)
                .IsUnicode(false);

            modelBuilder.Entity<Membership>()
                .Property(e => e.membership_rate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PurchaseDetail>()
                .Property(e => e.item_type)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseDetail>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PurchaseInvoice>()
                .Property(e => e.total_amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Supplement>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplement>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Supplement>()
                .Property(e => e.brand)
                .IsUnicode(false);

            modelBuilder.Entity<Supplement>()
                .Property(e => e.price)
                .HasPrecision(10, 2);
        }
    }
}

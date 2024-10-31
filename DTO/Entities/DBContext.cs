using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DTO.Entities
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<CustomerMembership> CustomerMemberships { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual DbSet<Supplement> Supplements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.password)
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

            modelBuilder.Entity<CustomerMembership>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Customer>()
                .Property(e => e.sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Instructor>()
                .Property(e => e.sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Membership>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Membership>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PurchaseDetail>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PurchaseInvoice>()
                .Property(e => e.totalAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Supplement>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Supplement>()
                .HasMany(e => e.PurchaseDetails)
                .WithRequired(e => e.Supplement)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);
        }
    }
}

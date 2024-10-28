namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            CustomerMemberships = new HashSet<CustomerMembership>();
            PurchaseInvoices = new HashSet<PurchaseInvoice>();
            Classes = new HashSet<Class>();
        }

        public int CustomerID { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public int? age { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_joined { get; set; }

        [StringLength(255)]
        public string contact_info { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        public int? membership_points { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerMembership> CustomerMemberships { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class> Classes { get; set; }
    }
}

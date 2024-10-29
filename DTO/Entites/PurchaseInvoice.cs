namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseInvoice")]
    public partial class PurchaseInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseInvoice()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        [Key]
        public int InvoiceID { get; set; }

        public int? CustomerID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public decimal? totalAmount { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}

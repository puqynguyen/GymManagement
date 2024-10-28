namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplement()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplementID { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public int? BrandID { get; set; }

        public decimal? price { get; set; }

        public int? stock_quantity { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}

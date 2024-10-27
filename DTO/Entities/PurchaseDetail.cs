namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string item_type { get; set; }

        public int? quantity { get; set; }

        public decimal? price { get; set; }

        public virtual PurchaseInvoice PurchaseInvoice { get; set; }
    }
}

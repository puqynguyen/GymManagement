namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplement
    {
        public int SupplementID { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(100)]
        public string type { get; set; }

        [StringLength(100)]
        public string brand { get; set; }

        public decimal? price { get; set; }

        public int? stock_quantity { get; set; }
    }
}

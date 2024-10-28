namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipment")]
    public partial class Equipment
    {
        public int EquipmentID { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(100)]
        public string type { get; set; }

        [StringLength(100)]
        public string brand { get; set; }

        [StringLength(50)]
        public string condition { get; set; }

        public int? quantity { get; set; }
    }
}

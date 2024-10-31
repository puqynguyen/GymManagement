namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerMembership")]
    public partial class CustomerMembership
    {
        [Key]
        public int MembershipRecordID { get; set; }

        public int? CustomerID { get; set; }

        public int? MembershipID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }

        public decimal? price { get; set; }

        public int? cancel { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Membership Membership { get; set; }
    }
}

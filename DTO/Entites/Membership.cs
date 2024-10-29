namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Membership")]
    public partial class Membership
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Membership()
        {
            CustomerMemberships = new HashSet<CustomerMembership>();
        }

        public int MembershipID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_created { get; set; }

        public decimal? price { get; set; }

        public int? membership_length { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerMembership> CustomerMemberships { get; set; }
    }
}

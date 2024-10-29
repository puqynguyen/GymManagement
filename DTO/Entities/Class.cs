namespace DTO.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Class")]
    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            Customers = new HashSet<Customer>();
            Instructors = new HashSet<Instructor>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassID { get; set; }

        public int class_size { get; set; }

        [StringLength(50)]
        public string class_type { get; set; }

        public decimal cost { get; set; }

        public int closed { get; set; }

        [StringLength(255)]
        public string desciption { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}

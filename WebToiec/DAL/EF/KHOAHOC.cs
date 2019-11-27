namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHOAHOC")]
    public partial class KHOAHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHOAHOC()
        {
            USER_KHOAHOC = new HashSet<USER_KHOAHOC>();
        }

        [Key]
        public int ID_GIA { get; set; }

        public int? THOIGIAN { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIATIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_KHOAHOC> USER_KHOAHOC { get; set; }
    }
}

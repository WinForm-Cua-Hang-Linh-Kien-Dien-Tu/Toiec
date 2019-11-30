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
        public int ID_KH { get; set; }

        public int? THOI_GIAN { get; set; }

        public double? GIA_TIEN { get; set; }

        public string TEN_KH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_KHOAHOC> USER_KHOAHOC { get; set; }
    }
}

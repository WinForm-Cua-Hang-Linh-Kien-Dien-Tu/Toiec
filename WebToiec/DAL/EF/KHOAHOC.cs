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
            BAIGIANG = new HashSet<BAIGIANG>();
            USER_KHOAHOC = new HashSet<USER_KHOAHOC>();
        }

        [Key]
        public int ID_KH { get; set; }

        public int? THOI_GIAN { get; set; }

        public double? GIA_TIEN { get; set; }

        public string TEN_KH { get; set; }

        [Column(TypeName = "ntext")]
        public string GIOI_THIEU { get; set; }

        [StringLength(100)]
        public string VIDEO_GIOI_THIEU { get; set; }

        public int? DANH_GIA { get; set; }

        [StringLength(100)]
        public string lOAI_KH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAIGIANG> BAIGIANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_KHOAHOC> USER_KHOAHOC { get; set; }
    }
}

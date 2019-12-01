namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHUDE_TUVUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUDE_TUVUNG()
        {
            CHI_TIET_TU_VUNG = new HashSet<CHI_TIET_TU_VUNG>();
            USER_CHUDE = new HashSet<USER_CHUDE>();
        }

        [Key]
        public int MA_CHU_DE { get; set; }

        [StringLength(200)]
        public string TEN_CHU_DE { get; set; }

        public int? TONG_SO_TU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_TU_VUNG> CHI_TIET_TU_VUNG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_CHUDE> USER_CHUDE { get; set; }
    }
}

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TUVUNG")]
    public partial class TUVUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TUVUNG()
        {
            CHI_TIET_TU_VUNG = new HashSet<CHI_TIET_TU_VUNG>();
        }

        [Key]
        public int ID_TUVUNG { get; set; }

        [StringLength(50)]
        public string TU { get; set; }

        [StringLength(100)]
        public string THELOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_TU_VUNG> CHI_TIET_TU_VUNG { get; set; }
    }
}

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CAUHOI_3_4
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAUHOI_3_4()
        {
            DAP_AN = new HashSet<DAP_AN>();
        }

        [Key]
        public int ID_CAUHOI_34 { get; set; }

        public int? ID_CAU_PART_3_4 { get; set; }

        [StringLength(200)]
        public string NOIDUNG { get; set; }

        public int? STT { get; set; }

        public virtual PART_3_4 PART_3_4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DAP_AN> DAP_AN { get; set; }
    }
}

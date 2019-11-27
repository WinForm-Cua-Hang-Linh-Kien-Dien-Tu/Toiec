namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CAUHOIPART_6_7
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAUHOIPART_6_7()
        {
            DAP_AN = new HashSet<DAP_AN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDCAUHOI_567 { get; set; }

        public int? ID_CAU_PART_567 { get; set; }

        [StringLength(200)]
        public string NOIDUNG { get; set; }

        public virtual PART_5_6_7 PART_5_6_7 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DAP_AN> DAP_AN { get; set; }
    }
}

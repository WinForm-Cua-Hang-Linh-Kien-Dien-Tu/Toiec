namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAIGIANG")]
    public partial class BAIGIANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BAIGIANG()
        {
            PART_1_2 = new HashSet<PART_1_2>();
            PART_3_4 = new HashSet<PART_3_4>();
            PART_5_6_7 = new HashSet<PART_5_6_7>();
            USER_BAIGIANG = new HashSet<USER_BAIGIANG>();
        }

        [Key]
        public int ID_BAIGIANG { get; set; }

        public int? ID_DANHSACH { get; set; }

        [StringLength(100)]
        public string NOIDUNGBAIGIANG { get; set; }

        [StringLength(100)]
        public string VIDEO { get; set; }

        public int? PART { get; set; }

        public virtual DANHSACH_BAIGIANG DANHSACH_BAIGIANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PART_1_2> PART_1_2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PART_3_4> PART_3_4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PART_5_6_7> PART_5_6_7 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_BAIGIANG> USER_BAIGIANG { get; set; }
    }
}

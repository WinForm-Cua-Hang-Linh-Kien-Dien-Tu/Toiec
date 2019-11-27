namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DANHSACH_BAIGIANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANHSACH_BAIGIANG()
        {
            BAIGIANG = new HashSet<BAIGIANG>();
        }

        [Key]
        public int ID_DANHSACH { get; set; }

        [StringLength(100)]
        public string TENDANHSACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAIGIANG> BAIGIANG { get; set; }
    }
}

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERS()
        {
            USER_BAIGIANG = new HashSet<USER_BAIGIANG>();
            USER_CHUDE = new HashSet<USER_CHUDE>();
            USER_KHOAHOC = new HashSet<USER_KHOAHOC>();
        }

        [Key]
        public int USERID { get; set; }

        [StringLength(20)]
        public string TAIKHOANUSER { get; set; }

        [StringLength(20)]
        public string MATKHAUUSER { get; set; }

        public DateTime? NGAYTAO { get; set; }

        public DateTime? NGAYBATDAU { get; set; }

        public DateTime? NGAYKETTHUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_BAIGIANG> USER_BAIGIANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_CHUDE> USER_CHUDE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_KHOAHOC> USER_KHOAHOC { get; set; }

        public virtual USERS_PROFILE USERS_PROFILE { get; set; }
    }
}

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USERS_PROFILE
    {
        [StringLength(100)]
        public string HOTEN { get; set; }

        public DateTime? NGAYSINH { get; set; }

        [StringLength(10)]
        public string GIOITINH { get; set; }

        [StringLength(50)]
        public string NGHENGHIEP { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(100)]
        public string THANHPHO { get; set; }

        public int? CAPDO { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USERID { get; set; }

        public virtual USERS USERS { get; set; }
    }
}

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string TAIKHOAN { get; set; }

        [StringLength(30)]
        public string MATKHAU { get; set; }
    }
}

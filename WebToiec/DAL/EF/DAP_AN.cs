namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DAP_AN
    {
        [StringLength(200)]
        public string DAPAN_C { get; set; }

        [StringLength(200)]
        public string DAPAN_D { get; set; }

        [StringLength(200)]
        public string DAPANDUNG { get; set; }

        [StringLength(200)]
        public string DAPAN_B { get; set; }

        [StringLength(200)]
        public string DAPAN_A { get; set; }

        [Key]
        public int IDDAPAN { get; set; }

        public int? IDCAUHOI_567 { get; set; }

        public int? IDCAU_34 { get; set; }

        public virtual CAUHOI_3_4 CAUHOI_3_4 { get; set; }

        public virtual CAUHOIPART_6_7 CAUHOIPART_6_7 { get; set; }
    }
}

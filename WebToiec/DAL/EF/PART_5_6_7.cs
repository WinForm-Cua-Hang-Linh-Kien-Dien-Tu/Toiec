namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PART_5_6_7
    {
        [Key]
        public int ID_CAU_PART5_6_7 { get; set; }

        public int? ID_BAIGIANG { get; set; }

        [StringLength(100)]
        public string NOIDUNGCAUHOI { get; set; }

        public virtual BAIGIANG BAIGIANG { get; set; }

        public virtual CAUHOIPART_6_7 CAUHOIPART_6_7 { get; set; }
    }
}

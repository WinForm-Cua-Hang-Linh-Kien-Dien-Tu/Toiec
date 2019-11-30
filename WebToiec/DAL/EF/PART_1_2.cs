namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PART_1_2
    {
        [Key]
        public int ID_CAU_PART1_2 { get; set; }

        public int? ID_BAIGIANG { get; set; }

        [StringLength(100)]
        public string HINH { get; set; }

        [StringLength(100)]
        public string AM_THANH { get; set; }

        [Column(TypeName = "text")]
        public string TEXT { get; set; }

        [StringLength(10)]
        public string DAP_AN_DUNG { get; set; }

        public virtual BAIGIANG BAIGIANG { get; set; }
    }
}

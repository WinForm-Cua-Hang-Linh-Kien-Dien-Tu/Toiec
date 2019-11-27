namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PART_3_4
    {
        [Key]
        public int ID_CAU_PART3_4 { get; set; }

        public int? ID_BAIGIANG { get; set; }

        [StringLength(100)]
        public string AMTHANH { get; set; }

        [Column(TypeName = "text")]
        public string TEXT { get; set; }

        public virtual BAIGIANG BAIGIANG { get; set; }

        public virtual CAUHOI_3_4 CAUHOI_3_4 { get; set; }
    }
}

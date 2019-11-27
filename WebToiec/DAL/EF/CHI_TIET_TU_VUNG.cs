namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHI_TIET_TU_VUNG
    {
        public int ID { get; set; }

        public int ID_TUVUNG { get; set; }

        public int MACHUDE { get; set; }

        [StringLength(50)]
        public string NGHIACUATU { get; set; }

        [StringLength(200)]
        public string PHATAM { get; set; }

        [StringLength(20)]
        public string PHIENAM { get; set; }

        [Column(TypeName = "text")]
        public string VIDU { get; set; }

        [StringLength(100)]
        public string HINHANH { get; set; }

        public virtual CHUDE_TUVUNG CHUDE_TUVUNG { get; set; }

        public virtual TUVUNG TUVUNG { get; set; }
    }
}

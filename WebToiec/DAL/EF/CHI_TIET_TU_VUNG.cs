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

        public int MA_CHU_DE { get; set; }

        public string NGHIA_CUA_TU { get; set; }

        [StringLength(200)]
        public string PHAT_AM { get; set; }

        [StringLength(200)]
        public string PHIEN_AM { get; set; }

        [Column(TypeName = "text")]
        public string VI_DU { get; set; }

        [StringLength(100)]
        public string HIN_HANH { get; set; }

        public virtual CHUDE_TUVUNG CHUDE_TUVUNG { get; set; }

        public virtual TUVUNG TUVUNG { get; set; }
    }
}

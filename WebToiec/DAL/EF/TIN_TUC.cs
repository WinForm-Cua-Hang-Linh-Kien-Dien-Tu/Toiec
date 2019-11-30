namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TIN_TUC
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string TEN_TIN_TUC { get; set; }

        public DateTime? NGAY_DANG { get; set; }

        [Column(TypeName = "ntext")]
        public string NOI_DUNG { get; set; }

        [StringLength(100)]
        public string NGUON_TIN_TUC { get; set; }

        [Column(TypeName = "text")]
        public string HINH_ANH { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebToiec.Models
{
    public class Model_TinTuc
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string TEN_TIN_TUC { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/M/yyyy}")]

        [DataType(DataType.Date)]
        public DateTime? NGAY_DANG { get; set; }

        [Column(TypeName = "ntext")]
        public string NOI_DUNG { get; set; }

        [StringLength(100)]
        public string NGUON_TIN_TUC { get; set; }

        [Column(TypeName = "text")]
        public string HINH_ANH { get; set; }
    }
}
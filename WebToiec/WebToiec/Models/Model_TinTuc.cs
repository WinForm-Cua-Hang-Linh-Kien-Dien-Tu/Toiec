using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Tên Tin Tức")]
        public string TEN_TIN_TUC { get; set; }

        [DisplayName("Ngày Đăng")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? NGAY_DANG { get; set; }

        [DisplayName("Nội Dung")]
        [Column(TypeName = "ntext")]
        public string NOI_DUNG { get; set; }

        [DisplayName("Nguồn Tin")]
        [StringLength(100)]
        public string NGUON_TIN_TUC { get; set; }

        [DisplayName("Hình Ảnh")]
        [Column(TypeName = "text")]
        public string HINH_ANH { get; set; }
    }
}
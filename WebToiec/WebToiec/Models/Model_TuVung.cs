using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebToiec.Models
{
    public class Model_TuVung
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("ID Từ Vựng")]
        public int ID_TuVung { get; set; }

        [DisplayName("Từ Vựng")]
        public string Tu_Vung { get; set; }

        [DisplayName("Mã Chủ Đề")]
        public int MA_CHU_DE { get; set; }

        [DisplayName("Tên Chủ Đề")]
        public string TEN_CHU_DE { get; set; }

        [DisplayName("Nghĩa Của Từ")]
        public string NGHIA_CUA_TU { get; set; }

        [DisplayName("Phát Âm")]
        [StringLength(200)]
        public string PHAT_AM { get; set; }

        [DisplayName("Phiên Âm")]
        [StringLength(200)]
        public string PHIEN_AM { get; set; }

        [DisplayName("Ví Dụ")]
        [AllowHtml]
        [Column(TypeName = "text")]
        public string VI_DU { get; set; }

        [StringLength(100)]
        [DisplayName("Hình Ảnh")]
        public string HIN_HANH { get; set; }

        [DisplayName("Loại Từ Vựng")]
        public string TheLoai { get; set; }
    }


}
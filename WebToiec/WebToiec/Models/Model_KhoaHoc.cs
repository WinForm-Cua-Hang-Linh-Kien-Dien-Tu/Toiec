using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebToiec.Models
{
    public class Model_KhoaHoc
    {
        [DisplayName("Id")]
        public int ID_KH { get; set; }

        [DisplayName("ID User")]
        public int ID_User { get; set; }

        [DisplayName("Thời Gian")]
        public int? THOI_GIAN { get; set; }

        [DisplayName("Giá Tiền")]
        public double? GIA_TIEN { get; set; }

        [DisplayName("Tên Khóa Học")]
        public string TEN_KH { get; set; }

        [DisplayName("Giới Thiệu")]
        [AllowHtml]
        public string GIOI_THIEU { get; set; }

        [DisplayName("Video Giới Thiệu Khóa Học")]
        public string VIDEO_GIOI_THIEU { get; set; }

        [DisplayName("Đáng Giá")]
        public int? DANH_GIA { get; set; }

        [DisplayName("Loại Khóa Học")]
        public string lOAI_KH { get; set; }
    }
}
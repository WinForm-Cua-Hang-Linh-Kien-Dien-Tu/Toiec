using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebToiec.Models
{
    public class Model_BaiGiang
    {
        [DisplayName("ID")]
        public int ID_BAIGIANG { get; set; }

        [DisplayName("User")]
        public int UserID { get; set; }

        [DisplayName("ID Khóa Học")]
        public int? ID_KH { get; set; }

        [DisplayName("Nội Dung Bài Giảng")]
        public string NOI_DUNG_BAI_GIANG { get; set; }

        [DisplayName("Video")]
        public string VIDEO { get; set; }

        [DisplayName("Part")]
        public int? PART { get; set; }

        [DisplayName("Giảng Viên")]
        public string GIANG_VIEN { get; set; }

        [DisplayName("Tên Bài Giảng")]
        public string TEN_BAI_GIANG { get; set; }

        [DisplayName("Đánh Giá")]
        public int? DANH_GIA { get; set; }

    }
}
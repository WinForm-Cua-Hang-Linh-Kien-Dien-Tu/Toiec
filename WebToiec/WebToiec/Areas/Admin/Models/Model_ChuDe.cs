using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebToiec.Areas.Admin.Models
{
    public class Model_ChuDe
    {
        [DisplayName("Mã Chủ Đề")]
        public int MA_CHU_DE { get; set; }

        [DisplayName("Tên Chủ Đề")]
        public string TEN_CHU_DE { get; set; }

        [DisplayName("Tổng Số Từ")]
        public int? TONG_SO_TU { get; set; }
    }
}
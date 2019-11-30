using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebToiec.Models
{
    public class Model_KhoaHoc
    {
        [DisplayName("Tên Sinh Viên")]
        public int ID_KH { get; set; }
        [DisplayName("Tên Sinh Viên")]
        public int? THOI_GIAN { get; set; }
        [DisplayName("Tên Sinh Viên")]
        public double? GIA_TIEN { get; set; }
        [DisplayName("Tên Sinh Viên")]
        public string TEN_KH { get; set; }
    }
}
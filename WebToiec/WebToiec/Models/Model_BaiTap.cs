using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebToiec.Models
{
    public class Model_BaiTap
    {
        public int ID_CauHoi { get; set; }

        public int ID_CauHoi_Part { get; set; }

        public int? ID_BAIGIANG { get; set; }

        public int IDDAPAN { get; set; }

        public int Part { get; set; }

        public string HINH { get; set; }

        public string AM_THANH { get; set; }

        public string TEXT { get; set; }

        public string NoiDungCauHoi { get; set; }

        public string DAPAN_C { get; set; }

        public string DAPAN_D { get; set; }

        public string DAPAN_B { get; set; }

        public string DAPAN_A { get; set; }

        public string DAP_AN_DUNG { get; set; }

        public int? SO_LUONG_DAP_AN { get; set; }
    }
}
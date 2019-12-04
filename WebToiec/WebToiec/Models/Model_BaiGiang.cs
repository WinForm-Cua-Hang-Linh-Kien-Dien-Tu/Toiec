using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebToiec.Models
{
    public class Model_BaiGiang
    {
        public int ID_BAIGIANG { get; set; }

        public int UserID { get; set; }

        public int? ID_KH { get; set; }

        public string NOI_DUNG_BAI_GIANG { get; set; }

        public string VIDEO { get; set; }

        public int? PART { get; set; }

        public string GIANG_VIEN { get; set; }

        public string TEN_BAI_GIANG { get; set; }

        public int? DANH_GIA { get; set; }

    }
}
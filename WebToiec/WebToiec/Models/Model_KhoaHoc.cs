using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebToiec.Models
{
    public class Model_KhoaHoc
    {
        
        public int ID_KH { get; set; }

        public int ID_User { get; set; }

        public int? THOI_GIAN { get; set; }
        
        public double? GIA_TIEN { get; set; }
        
        public string TEN_KH { get; set; }
    }
}
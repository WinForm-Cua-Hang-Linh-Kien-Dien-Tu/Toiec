using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebToiec.Models
{
    public class Model_User
    {
        [DisplayName("User Name")]
        public string TAI_KHOAN_USER { get; set; }

        [StringLength(50)]
        [DisplayName("Mật Khẩu")]
        public string MAT_KHAU_USER { get; set; }

        public DateTime? NGAY_TAO { get; set; }

        public DateTime? NGAY_BAT_DAU { get; set; }

        public DateTime? NGAY_KET_THUC { get; set; }
    }
}
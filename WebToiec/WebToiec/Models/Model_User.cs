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
        [Required]
        [DisplayName("User Name")]
        public string TAI_KHOAN_USER { get; set; }

        [Required]
        [DataType("Password")]
        [DisplayName("PassWord")]
        [StringLength(20,MinimumLength = 6, ErrorMessage = "Mật Khẩu Không Thể Ít Hơn 6 Ký Tự")]
        public string MAT_KHAU_USER { get; set; }

        [Required]
        [DisplayName("Confirm PassWord")]
        [DataType("Password")]
        [Compare("MAT_KHAU_USER")]
        public string Confirm_MatKhau { get; set; }

        public DateTime? NGAY_TAO { get; set; }


    }
}
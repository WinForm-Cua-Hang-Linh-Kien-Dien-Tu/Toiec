using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebToiec.Areas.Admin.Models
{
    public class Admin_Model
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Tài khoản")]
        public string Username { get; set; }

        [Required]
        [DataType("Password")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }        
    }
}
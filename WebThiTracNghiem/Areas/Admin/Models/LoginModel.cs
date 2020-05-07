using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
    }
}
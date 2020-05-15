using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Data
{
    public class TaiKhoanModel
    {
        [Required(ErrorMessage ="Tài khoản không được để trống")]
        public string Taikhoan { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Matkhau { get; set; }
        public string MaQuyen { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public byte[] Anh { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThiTracNghiem.Areas.Admin.Data
{
    public class TaiKhoanModel
    {
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }
        public string MaQuyen { get; set; }
        public string HoTen { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public byte[] Anh { get; set; }
        public List<int> MaBaiThi { get; set; }
    }
}
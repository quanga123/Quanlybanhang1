using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Quanlybanhang.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public int MaNv { get; set; }
        public string HoTenNv { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}

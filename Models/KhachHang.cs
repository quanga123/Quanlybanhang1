using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Quanlybanhang.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public string MaKh { get; set; }
        public string HoTenKh { get; set; }
        public string DiachiKh { get; set; }
        public string DienThoai { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Quanlybanhang.Models
{
    public partial class ChiTietHd
    {
        public int MaHd { get; set; }
        public string MaSp { get; set; }
        public string SoLuong { get; set; }
        public int IdchitietHd { get; set; }

        public virtual HoaDon MaHdNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}

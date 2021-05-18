using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Quanlybanhang.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHd = new HashSet<ChiTietHd>();
        }

        public int MaHd { get; set; }
        public string MaKh { get; set; }
        public int MaNv { get; set; }
        public DateTime? NgayLapHd { get; set; }
        public DateTime? NganNhanHang { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual Nhanvien MaNvNavigation { get; set; }
        public virtual ICollection<ChiTietHd> ChiTietHd { get; set; }
    }
}

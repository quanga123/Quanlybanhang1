using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Quanlybanhang.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietHd = new HashSet<ChiTietHd>();
        }

        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string DonTinh { get; set; }
        public string DonGia { get; set; }

        public virtual ICollection<ChiTietHd> ChiTietHd { get; set; }
    }
}

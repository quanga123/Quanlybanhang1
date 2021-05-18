using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Quanlybanhang.Models
{
    public partial class quanlybanhangContext : DbContext
    {
        public quanlybanhangContext()
        {
        }

        public quanlybanhangContext(DbContextOptions<quanlybanhangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietHd> ChiTietHd { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3D2EL1B\\MISASME2015;Database=quanlybanhang;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHd>(entity =>
            {
                entity.HasKey(e => e.IdchitietHd)
                    .HasName("PK_ChiTietHD_1");

                entity.ToTable("ChiTietHD");

                entity.Property(e => e.IdchitietHd).HasColumnName("IdchitietHD");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.SoLuong).HasMaxLength(10);

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.ChiTietHd)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHD_HoaDon");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietHd)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_ChiTietHD_SanPham");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd);

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaKh)
                    .IsRequired()
                    .HasColumnName("MaKH")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NganNhanHang).HasColumnType("date");

                entity.Property(e => e.NgayLapHd)
                    .HasColumnName("NgayLapHD")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_KhachHang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_Nhanvien");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DiachiKh)
                    .HasColumnName("DiachiKH")
                    .HasMaxLength(100);

                entity.Property(e => e.DienThoai).HasMaxLength(50);

                entity.Property(e => e.HoTenKh)
                    .HasColumnName("HoTenKH")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.DienThoai).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(50);

                entity.Property(e => e.HoTenNv)
                    .HasColumnName("HoTenNV")
                    .HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("date");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.DonGia).HasMaxLength(50);

                entity.Property(e => e.DonTinh).HasMaxLength(50);

                entity.Property(e => e.TenSp)
                    .HasColumnName("TenSP")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

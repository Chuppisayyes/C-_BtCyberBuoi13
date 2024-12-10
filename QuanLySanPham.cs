using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace QuanLySanPham
{
    public class QuanLySanPham
    {
        private string fileSanPham = "sanPham.json";
        private string fileDonHang = "donHang.json";
        private List<SanPham> danhSachSanPham = new List<SanPham>();
        private List<DonHang> danhSachDonHang = new List<DonHang>();

        public QuanLySanPham()
        {
            DocDuLieu();
        }

        private void LuuDuLieu()
        {
            File.WriteAllText(fileSanPham, JsonConvert.SerializeObject(danhSachSanPham, Formatting.Indented));
            File.WriteAllText(fileDonHang, JsonConvert.SerializeObject(danhSachDonHang, Formatting.Indented));
        }

        private void DocDuLieu()
        {
            if (File.Exists(fileSanPham))
            {
                danhSachSanPham = JsonConvert.DeserializeObject<List<SanPham>>(File.ReadAllText(fileSanPham)) ?? new List<SanPham>();
            }

            if (File.Exists(fileDonHang))
            {
                danhSachDonHang = JsonConvert.DeserializeObject<List<DonHang>>(File.ReadAllText(fileDonHang)) ?? new List<DonHang>();
            }
        }

        public void ThemSanPham(SanPham sanPham)
        {
            danhSachSanPham.Add(sanPham);
            LuuDuLieu();
        }

        public void TimKiemSanPham(string tenSanPham)
        {
            var ketQua = danhSachSanPham.FirstOrDefault(sp => sp.TenSanPham.Equals(tenSanPham, StringComparison.OrdinalIgnoreCase));
            if (ketQua != null)
            {
                Console.WriteLine($"Mã: {ketQua.MaSanPham}, Tên: {ketQua.TenSanPham}, Giá bán: {ketQua.GiaBan}, Số lượng: {ketQua.SoLuongTonKho}");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm.");
            }
        }

        public void CapNhatSanPham(string maSanPham, double giaBanMoi, int soLuongMoi)
        {
            var sanPham = danhSachSanPham.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
            if (sanPham != null)
            {
                sanPham.GiaBan = giaBanMoi;
                sanPham.SoLuongTonKho = soLuongMoi;
                LuuDuLieu();
                Console.WriteLine("Cập nhật sản phẩm thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm.");
            }
        }

        public void TinhTongGiaTriKhoHang()
        {
            double tongGiaTri = danhSachSanPham.Sum(sp => sp.TinhTongGiaTri());
            Console.WriteLine($"Tổng giá trị kho hàng: {tongGiaTri}");
        }

        public void XoaSanPham(string maSanPham)
        {
            danhSachSanPham.RemoveAll(sp => sp.MaSanPham == maSanPham);
            LuuDuLieu();
        }

        public void HienThiDanhSachSanPham()
        {
            foreach (var sp in danhSachSanPham)
            {
                Console.WriteLine($"Mã: {sp.MaSanPham}, Tên: {sp.TenSanPham}, Giá bán: {sp.GiaBan}, Số lượng: {sp.SoLuongTonKho}, Tổng giá trị: {sp.TinhTongGiaTri()}");
            }
        }
        public void HienThiSanPhamTheoGiaTangDan()
        {
            var sanPhamSapXep = danhSachSanPham.OrderBy(sp => sp.GiaBan).ToList();
            if (sanPhamSapXep.Any())
            {
                Console.WriteLine("Danh sách sản phẩm theo giá tăng dần:");
                foreach (var sp in sanPhamSapXep)
                {
                    Console.WriteLine($"Mã: {sp.MaSanPham}, Tên: {sp.TenSanPham}, Giá: {sp.GiaBan}");
                }
            }
            else
            {
                Console.WriteLine("Danh sách sản phẩm rỗng.");
            }
        }
        public void SapXepSanPhamTheoTenCuoi()
        {
            var sanPhamSapXep = danhSachSanPham.OrderBy(sp =>
            {
                var tenParts = sp.TenSanPham.Split(' ');
                return tenParts.Last(); // Lấy từ cuối cùng trong tên sản phẩm
            }).ToList();

            if (sanPhamSapXep.Any())
            {
                Console.WriteLine("Danh sách sản phẩm sắp xếp theo từ cuối:");
                foreach (var sp in sanPhamSapXep)
                {
                    Console.WriteLine($"Mã: {sp.MaSanPham}, Tên: {sp.TenSanPham}, Giá: {sp.GiaBan}");
                }
            }
            else
            {
                Console.WriteLine("Danh sách sản phẩm rỗng.");
            }
        }
        public void TaoDonHang(DonHang donHang)
        {
            var sanPham = danhSachSanPham.FirstOrDefault(sp => sp.MaSanPham == donHang.MaSanPham);
            if (sanPham != null)
            {
                if (sanPham.SoLuongTonKho >= donHang.SoLuongBan)
                {
                    danhSachDonHang.Add(donHang);
                    LuuDuLieu();
                    Console.WriteLine("Tạo đơn hàng thành công.");
                }
                else
                {
                    Console.WriteLine("Không đủ số lượng trong kho để tạo đơn hàng.");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm.");
            }
        }

        public void CapNhatTrangThaiDonHang(string maDonHang, bool daGiao)
        {
            var donHang = danhSachDonHang.FirstOrDefault(dh => dh.MaDonHang == maDonHang);
            if (donHang != null)
            {
                donHang.DaGiao = daGiao;
                if (daGiao)
                {
                    var sanPham = danhSachSanPham.FirstOrDefault(sp => sp.MaSanPham == donHang.MaSanPham);
                    if (sanPham != null)
                    {
                        sanPham.SoLuongTonKho -= donHang.SoLuongBan;
                    }
                }
                LuuDuLieu();
                Console.WriteLine("Cập nhật trạng thái đơn hàng thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy đơn hàng.");
            }
        }

        public void HienThiDanhSachDonHang()
        {
            foreach (var dh in danhSachDonHang)
            {
                Console.WriteLine($"Mã đơn hàng: {dh.MaDonHang}, Mã sản phẩm: {dh.MaSanPham}, Số lượng bán: {dh.SoLuongBan}, Người đặt: {dh.TenNguoiDat}, Trạng thái: {dh.TrangThaiGiaoHang()}");
            }
        }

        public void XoaDonHang(string maDonHang)
        {
            danhSachDonHang.RemoveAll(dh => dh.MaDonHang == maDonHang);
            LuuDuLieu();
            Console.WriteLine("Xóa đơn hàng thành công.");
        }

    }
}

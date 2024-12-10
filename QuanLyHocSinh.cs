using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace QuanLyHocSinh
{
    public class QuanLyHocSinh
    {
        private string filePath = "danhSachHocSinh.json";
        private List<HocSinh> danhSachHocSinh = new List<HocSinh>();

        public QuanLyHocSinh()
        {
            DocDuLieuTuFile();
        }

        private void LuuDuLieuVaoFile()
        {
            string jsonData = JsonConvert.SerializeObject(danhSachHocSinh, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        private void DocDuLieuTuFile()
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                danhSachHocSinh = JsonConvert.DeserializeObject<List<HocSinh>>(jsonData) ?? new List<HocSinh>();
            }
        }

        public void ThemHocSinh(HocSinh hocSinh)
        {
            danhSachHocSinh.Add(hocSinh);
            LuuDuLieuVaoFile();
        }

        public HocSinh TimKiemHocSinhTheoTen(string ten)
        {
            return danhSachHocSinh.FirstOrDefault(hs => hs.TenHocSinh.Equals(ten, StringComparison.OrdinalIgnoreCase));
        }

        public void CapNhatDiem(string maHocSinh, double diemToan, double diemVan, double diemAnh)
        {
            var hocSinh = danhSachHocSinh.FirstOrDefault(hs => hs.MaHocSinh == maHocSinh);
            if (hocSinh != null)
            {
                hocSinh.DiemToan = diemToan;
                hocSinh.DiemVan = diemVan;
                hocSinh.DiemAnh = diemAnh;
                LuuDuLieuVaoFile();
            }
        }

        public void XoaHocSinh(string maHocSinh)
        {
            danhSachHocSinh.RemoveAll(hs => hs.MaHocSinh == maHocSinh);
            LuuDuLieuVaoFile();
        }

        public void HienThiDanhSachHocSinh()
        {
            DocDuLieuTuFile();
            foreach (var hs in danhSachHocSinh)
            {
                Console.WriteLine($"Mã: {hs.MaHocSinh}, Tên: {hs.TenHocSinh}, Điểm TB: {hs.TinhDiemTrungBinh():F2}, Xếp loại: {hs.XepLoaiHocLuc()}");
            }
        }

        public void SapXepTheoDiemTB()
        {
            var danhSachSapXep = danhSachHocSinh.OrderBy(hs => hs.TinhDiemTrungBinh()).ToList();
            Console.WriteLine("Danh sách sắp xếp theo điểm trung bình:");
            foreach (var hs in danhSachSapXep)
            {
                Console.WriteLine($"Mã: {hs.MaHocSinh}, Tên: {hs.TenHocSinh}, Điểm TB: {hs.TinhDiemTrungBinh():F2}, Xếp loại: {hs.XepLoaiHocLuc()}");
            }
        }

        public void SapXepTheoTen()
        {
            var danhSachSapXep = danhSachHocSinh.OrderBy(hs => hs.TenHocSinh.Split(' ').Last()).ToList();
            Console.WriteLine("Danh sách sắp xếp theo tên:");
            foreach (var hs in danhSachSapXep)
            {
                Console.WriteLine($"Mã: {hs.MaHocSinh}, Tên: {hs.TenHocSinh}, Điểm TB: {hs.TinhDiemTrungBinh():F2}, Xếp loại: {hs.XepLoaiHocLuc()}");
            }
        }
    }
}

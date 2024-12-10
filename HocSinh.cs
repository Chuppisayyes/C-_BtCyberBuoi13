using System;

namespace QuanLyHocSinh
{
    public class HocSinh
    {
        private string maHocSinh;
        private string tenHocSinh;
        private double diemToan;
        private double diemVan;
        private double diemAnh;

        public string MaHocSinh
        {
            get => maHocSinh;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Mã học sinh không được để trống.");
                }
                maHocSinh = value.Trim();
            }
        }

        public string TenHocSinh
        {
            get => tenHocSinh;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tên học sinh không được để trống.");
                }
                tenHocSinh = value.Trim();
            }
        }

        public double DiemToan
        {
            get => diemToan;
            set
            {
                if (value < 0 && value > 10)
                {
                    throw new ArgumentException("Điểm Toán phải nằm trong khoảng từ 0 đến 10.");
                }
                diemToan = value;
            }
        }

        public double DiemVan
        {
            get => diemVan;
            set
            {
                if (value < 0 && value > 10)
                {
                    throw new ArgumentException("Điểm Văn phải nằm trong khoảng từ 0 đến 10.");
                }
                diemVan = value;
            }
        }

        public double DiemAnh
        {
            get => diemAnh;
            set
            {
                if (value < 0 && value > 10)
                {
                    throw new ArgumentException("Điểm Anh phải nằm trong khoảng từ 0 đến 10.");
                }
                diemAnh = value;
            }
        }

        public double TinhDiemTrungBinh()
        {
            return (DiemToan + DiemVan + DiemAnh) / 3;
        }

        public string XepLoaiHocLuc()
        {
            double dtb = TinhDiemTrungBinh();
            if (dtb < 5) return "Yếu";
            if (dtb <= 6.5) return "Trung bình";
            if (dtb < 8) return "Khá";
            return "Giỏi";
        }
    }
}

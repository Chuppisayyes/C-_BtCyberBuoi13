using System;

namespace QuanLySanPham
{
    public class SanPham
    {
        private string maSanPham;
        private string tenSanPham;
        private double giaBan;
        private int soLuongTonKho;

        public string MaSanPham
        {
            get => maSanPham;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Mã sản phẩm không được để trống.");
                }
                maSanPham = value.Trim();
            }
        }

        public string TenSanPham
        {
            get => tenSanPham;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tên sản phẩm không được để trống.");
                }
                tenSanPham = value.Trim();
            }
        }

        public double GiaBan
        {
            get => giaBan;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Giá bán phải lớn hơn 0.");
                }
                giaBan = value;
            }
        }

        public int SoLuongTonKho
        {
            get => soLuongTonKho;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Số lượng tồn kho không được nhỏ hơn 0.");
                }
                soLuongTonKho = value;
            }
        }

        public double TinhTongGiaTri()
        {
            return GiaBan * SoLuongTonKho;
        }
    }
}

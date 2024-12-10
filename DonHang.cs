namespace QuanLySanPham
{
    public class DonHang
    {
        public string MaDonHang { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuongBan { get; set; }
        public string TenNguoiDat { get; set; }
        public bool DaGiao { get; set; }

        public string TrangThaiGiaoHang()
        {
            return DaGiao ? "Đã giao" : "Chưa giao";
        }
    }
}

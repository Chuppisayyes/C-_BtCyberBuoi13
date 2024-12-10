using System;

namespace QuanLyChung
{
    class Program
    {
        static void Main(string[] args)
        {
            QuanLyHocSinh.QuanLyHocSinh quanLyHocSinh = new QuanLyHocSinh.QuanLyHocSinh();
            QuanLySanPham.QuanLySanPham quanLySanPham = new QuanLySanPham.QuanLySanPham();

            while (true)
            {
                Console.WriteLine("\nChọn chức năng:");
                Console.WriteLine("1. Quản lý học sinh");
                Console.WriteLine("2. Quản lý sản phẩm và đơn hàng");
                Console.WriteLine("3. Thoát chương trình");
                Console.Write("Lựa chọn: ");
                int mainChoice = int.Parse(Console.ReadLine());

                switch (mainChoice)
                {
                    case 1:
                        QuanLyHocSinhMenu(quanLyHocSinh);
                        break;

                    case 2:
                        QuanLySanPhamMenu(quanLySanPham);
                        break;

                    case 3:
                        Console.WriteLine("Thoát chương trình.");
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }

        static void QuanLyHocSinhMenu(QuanLyHocSinh.QuanLyHocSinh quanLyHocSinh)
        {
            while (true)
            {
                Console.WriteLine("\n--- Quản lý học sinh ---");
                Console.WriteLine("1. Thêm học sinh");
                Console.WriteLine("2. Tìm kiếm học sinh theo tên");
                Console.WriteLine("3. Cập nhật điểm học sinh");
                Console.WriteLine("4. Xóa học sinh");
                Console.WriteLine("5. Hiển thị danh sách học sinh");
                Console.WriteLine("6. Sắp xếp theo điểm trung bình");
                Console.WriteLine("7. Sắp xếp theo tên");

                Console.WriteLine("8. Quay lại menu chính");
                Console.Write("Lựa chọn: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Nhập mã học sinh: ");
                        string maHS = Console.ReadLine();
                        Console.Write("Nhập tên học sinh: ");
                        string tenHS = Console.ReadLine();
                        Console.Write("Nhập điểm Toán: ");
                        double diemToan = double.Parse(Console.ReadLine());
                        Console.Write("Nhập điểm Văn: ");
                        double diemVan = double.Parse(Console.ReadLine());
                        Console.Write("Nhập điểm Anh: ");
                        double diemAnh = double.Parse(Console.ReadLine());
                        quanLyHocSinh.ThemHocSinh(new QuanLyHocSinh.HocSinh
                        {
                            MaHocSinh = maHS,
                            TenHocSinh = tenHS,
                            DiemToan = diemToan,
                            DiemVan = diemVan,
                            DiemAnh = diemAnh
                        });
                        break;

                    case 2:
                        Console.Write("Nhập tên học sinh cần tìm: ");
                        string tenTimKiem = Console.ReadLine();
                        var hocSinh = quanLyHocSinh.TimKiemHocSinhTheoTen(tenTimKiem);
                        if (hocSinh != null)
                        {
                            Console.WriteLine($"Tìm thấy: {hocSinh.TenHocSinh}, Điểm TB: {hocSinh.TinhDiemTrungBinh():F2}, Xếp loại: {hocSinh.XepLoaiHocLuc()}");
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy học sinh.");
                        }
                        break;

                    case 3:
                        Console.Write("Nhập mã học sinh cần cập nhật: ");
                        string maCapNhat = Console.ReadLine();
                        Console.Write("Nhập điểm Toán mới: ");
                        double diemToanMoi = double.Parse(Console.ReadLine());
                        Console.Write("Nhập điểm Văn mới: ");
                        double diemVanMoi = double.Parse(Console.ReadLine());
                        Console.Write("Nhập điểm Anh mới: ");
                        double diemAnhMoi = double.Parse(Console.ReadLine());
                        quanLyHocSinh.CapNhatDiem(maCapNhat, diemToanMoi, diemVanMoi, diemAnhMoi);
                        break;

                    case 4:
                        Console.Write("Nhập mã học sinh cần xóa: ");
                        string maXoa = Console.ReadLine();
                        quanLyHocSinh.XoaHocSinh(maXoa);
                        break;

                    case 5:
                        quanLyHocSinh.HienThiDanhSachHocSinh();
                        break;

                    case 6:
                        quanLyHocSinh.SapXepTheoDiemTB();
                        break;

                    case 7:
                        quanLyHocSinh.SapXepTheoTen();
                        break;

                    case 8:
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }

        static void QuanLySanPhamMenu(QuanLySanPham.QuanLySanPham quanLySanPham)
        {
            while (true)
            {
                Console.WriteLine("\n--- Quản lý sản phẩm và đơn hàng ---");
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Tìm kiếm sản phẩm");
                Console.WriteLine("3. Cập nhật sản phẩm");
                Console.WriteLine("4. Tính tổng giá trị kho hàng");
                Console.WriteLine("5. Xóa sản phẩm");
                Console.WriteLine("6. Hiển thị danh sách sản phẩm");
                Console.WriteLine("7. Hiển thị sản phẩm theo giá bán tăng dần");
                Console.WriteLine("8. Hiển thị sản phẩm theo tên");
                Console.WriteLine("9. Tạo đơn hàng");
                Console.WriteLine("10. Hiển thị danh sách đơn hàng");
                Console.WriteLine("11. Cập nhật trạng thái đơn hàng");
                Console.WriteLine("12. Xóa đơn hàng");
                Console.WriteLine("13. Quay lại menu chính");
                Console.Write("Lựa chọn: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Nhập mã sản phẩm: ");
                        string maSP = Console.ReadLine();
                        Console.Write("Nhập tên sản phẩm: ");
                        string tenSP = Console.ReadLine();
                        Console.Write("Nhập giá bán: ");
                        double giaBan = double.Parse(Console.ReadLine());
                        Console.Write("Nhập số lượng tồn kho: ");
                        int soLuong = int.Parse(Console.ReadLine());
                        quanLySanPham.ThemSanPham(new QuanLySanPham.SanPham
                        {
                            MaSanPham = maSP,
                            TenSanPham = tenSP,
                            GiaBan = giaBan,
                            SoLuongTonKho = soLuong
                        });
                        break;

                    case 2:
                        Console.Write("Nhập tên sản phẩm: ");
                        string tenTim = Console.ReadLine();
                        quanLySanPham.TimKiemSanPham(tenTim);
                        break;

                    case 3:
                        Console.Write("Nhập mã sản phẩm: ");
                        string maCapNhat = Console.ReadLine();
                        Console.Write("Nhập giá bán mới: ");
                        double giaMoi = double.Parse(Console.ReadLine());
                        Console.Write("Nhập số lượng mới: ");
                        int soLuongMoi = int.Parse(Console.ReadLine());
                        quanLySanPham.CapNhatSanPham(maCapNhat, giaMoi, soLuongMoi);
                        break;

                    case 4:
                        quanLySanPham.TinhTongGiaTriKhoHang();
                        break;

                    case 5:
                        Console.Write("Nhập mã sản phẩm: ");
                        string maXoa = Console.ReadLine();
                        quanLySanPham.XoaSanPham(maXoa);
                        break;

                    case 6:
                        quanLySanPham.HienThiDanhSachSanPham();
                        break;
                    case 7:
                        quanLySanPham.HienThiSanPhamTheoGiaTangDan();
                        break;

                    case 8:
                        quanLySanPham.SapXepSanPhamTheoTenCuoi();
                        break;

                    case 9:
                        Console.Write("Nhập mã đơn hàng: ");
                        string maDH = Console.ReadLine();
                        Console.Write("Nhập mã sản phẩm: ");
                        string maSanPham = Console.ReadLine();
                        Console.Write("Nhập số lượng bán: ");
                        int soLuongBan = int.Parse(Console.ReadLine());
                        Console.Write("Nhập tên người đặt: ");
                        string tenNguoiDat = Console.ReadLine();
                        quanLySanPham.TaoDonHang(new QuanLySanPham.DonHang
                        {
                            MaDonHang = maDH,
                            MaSanPham = maSanPham,
                            SoLuongBan = soLuongBan,
                            TenNguoiDat = tenNguoiDat,
                            DaGiao = false
                        });
                        break;

                    case 10:
                        quanLySanPham.HienThiDanhSachDonHang();
                        break;

                    case 11:
                        Console.Write("Nhập mã đơn hàng cần cập nhật: ");
                        string maDonHang = Console.ReadLine();
                        Console.Write("Trạng thái (true = đã giao, false = chưa giao): ");
                        bool trangThai = bool.Parse(Console.ReadLine());
                        quanLySanPham.CapNhatTrangThaiDonHang(maDonHang, trangThai);
                        break;

                    case 12:
                        Console.Write("Nhập mã đơn hàng cần xóa: ");
                        string maDonHangXoa = Console.ReadLine();
                        quanLySanPham.XoaDonHang(maDonHangXoa);
                        break;

                    case 13:
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }
    }
}

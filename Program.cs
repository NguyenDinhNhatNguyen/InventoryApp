using System;
using System.Text;
using InventoryApp.Services;
using InventoryApp.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        // --- PHẦN ĐĂNG NHẬP ---
        while (WarehouseService.UserSession == null)
        {
            Console.Clear();
            Console.WriteLine("=== ĐĂNG NHẬP HỆ THỐNG ===");
            Console.Write("Tài khoản: "); string u = Console.ReadLine();
            Console.Write("Mật khẩu: "); string p = Console.ReadLine();

            if (WarehouseService.Login(u, p))
            {
                Console.WriteLine($"Chào mừng {WarehouseService.UserSession.FullName}!");
                System.Threading.Thread.Sleep(1000); // Đợi 1 tí cho đẹp
            }
            else
            {
                Console.WriteLine("Sai tài khoản hoặc mật khẩu! Bấm phím bất kỳ để thử lại.");
                Console.ReadKey();
            }
        }

        // --- PHẦN MENU (Giữ nguyên nhưng có thể check Role) ---
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Chào người dùng: {WarehouseService.UserSession?.FullName} | Quyền: {WarehouseService.UserSession?.Role}");
            Console.WriteLine("=== QUẢN LÝ KHO ===");          
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("1. Xem tồn kho");
            Console.WriteLine("2. Nhập hàng");
            Console.WriteLine("3. Xuất hàng");
            Console.WriteLine("4. Xem lịch sử giao dịch");

            // Chỉ hiển thị các mục này nếu là Admin
            if (WarehouseService.UserSession?.Role == "Admin")
            {
                Console.WriteLine("5. [ADMIN] Xem báo cáo giá trị kho");
                Console.WriteLine("6. [ADMIN] Thêm người dùng mới");
            }
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1": WarehouseService.XemKhoHang(); break;
                case "2": WarehouseService.NhapHangMoi(); break;
                case "3": WarehouseService.XuatKho(); break;
                case "4": WarehouseService.XemLichSu(); break;
                
                case "5":
                    if (WarehouseService.UserSession?.Role == "Admin")
                        WarehouseService.BaoCaoTonKho();
                    else
                        Console.WriteLine("Bạn không có quyền xem báo cáo!");
                    break;

                case "6":
                    if (WarehouseService.UserSession?.Role == "Admin")
                        WarehouseService.ThemNguoiDung();
                    else
                        Console.WriteLine("Bạn không có quyền quản lý người dùng!");
                    break;

                case "0": return;
    }
            
            Console.WriteLine("\n[Bấm phím bất kỳ...]");
            Console.ReadKey();
        }
    }
}
using System;
using Microsoft.Data.SqlClient;
using InventoryApp.Models;

namespace InventoryApp.Services;

public class WarehouseService {
    public static User UserSession = null;

    // --- QUẢN LÝ NGƯỜI DÙNG ---
    public static bool Login(string u, string p) {
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        string sql = "SELECT * FROM Users WHERE Username = @u AND Password = @p";
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@u", u);
        cmd.Parameters.AddWithValue("@p", p);
        using var r = cmd.ExecuteReader();
        if (r.Read()) {
            UserSession = new User {
                UserID = (int)r["UserID"],
                Username = r["Username"].ToString(),
                FullName = r["FullName"].ToString(),
                Role = r["Role"].ToString()
            };
            return true;
        }
        return false;
    }

    // --- NGHIỆP VỤ KHO ---
    // --- 1. XEM KHO ---
    public static void XemKhoHang() {
        Console.WriteLine("\n--- DANH SÁCH HÀNG TỒN KHO HIỆN TẠI ---");
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        using var cmd = new SqlCommand("SELECT * FROM Products", conn);
        using var r = cmd.ExecuteReader();
        while (r.Read()) 
            Console.WriteLine($"[{r["ProductID"]}] {r["ProductName"]} - Tồn: {r["StockQuantity"]}");
    }

    // --- 2. NHẬP HÀNG ---
    public static void NhapHangMoi() {
        Console.WriteLine("\n--- NHẬP HÀNG MỚI ---");
        Console.Write("Tên SP: "); string ten = Console.ReadLine() ?? "N/A";
        Console.Write("Giá tiền mỗi đơn vị: "); decimal gia = decimal.Parse(Console.ReadLine() ?? "0");
        Console.Write("Số lượng: "); int sl = int.Parse(Console.ReadLine() ?? "0");
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        string sql = "INSERT INTO Products (ProductName, Price, StockQuantity) OUTPUT INSERTED.ProductID VALUES (@n, @p, @q)";
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@n", ten);
        cmd.Parameters.AddWithValue("@p", gia);
        cmd.Parameters.AddWithValue("@q", sl);
        int id = (int)cmd.ExecuteScalar();
        GhiLog(conn, id, "NHAP", sl, $"User {UserSession.Username} nhap moi");
        Console.WriteLine("Thành công!");
    }


    // --- 3. XUẤT KHO ---
    public static void XuatKho() {
        Console.WriteLine("\n--- XUẤT KHO ---");
        Console.Write("ID SP: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Số lượng bán: "); int sl = int.Parse(Console.ReadLine());
        using var conn = DatabaseHelper.GetConnection();
        conn.Open();
        // Logic kiểm tra tồn (Validation)
        using var cmdCheck = new SqlCommand("SELECT StockQuantity FROM Products WHERE ProductID=@id", conn);
        cmdCheck.Parameters.AddWithValue("@id", id);
        object result = cmdCheck.ExecuteScalar();

        if (result == null) { Console.WriteLine("Sai mã sản phẩm!"); return; }
        if ((int)result < sl) { Console.WriteLine($"Không đủ hàng! Tồn: {result}"); return; }

        using var cmdUp = new SqlCommand("UPDATE Products SET StockQuantity -= @sl WHERE ProductID=@id", conn);
        cmdUp.Parameters.AddWithValue("@sl", sl);
        cmdUp.Parameters.AddWithValue("@id", id);
        cmdUp.ExecuteNonQuery();
        GhiLog(conn, id, "XUAT", sl, $"User {UserSession.Username} xuat kho");
        Console.WriteLine("Đã xuất kho.");
    }
// --- 4. XEM LỊCH SỬ ---
    public static void XemLichSu()
    {
        Console.WriteLine("\n--- 📜 LỊCH SỬ GIAO DỊCH ---");
        using (SqlConnection conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string sql = @"SELECT h.TransDate, p.ProductName, h.TransType, h.Quantity 
                           FROM TransactionHistory h 
                           JOIN Products p ON h.ProductID = p.ProductID 
                           ORDER BY h.TransDate DESC";
            SqlCommand cmd = new SqlCommand(sql, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-20} | {1,-25} | {2,-10} | {3,-5}", "THỜI GIAN", "SẢN PHẨM", "LOẠI", "SL");
                while (reader.Read())
                {
                    Console.WriteLine("{0,-20} | {1,-25} | {2,-10} | {3,-5}", 
                        reader["TransDate"], reader["ProductName"], reader["TransType"], reader["Quantity"]);
                }
            }
        }
    }

    // --- 5. BÁO CÁO (Dùng Stored Procedure) ---
    public static void BaoCaoTonKho()
    {
        Console.WriteLine("\n--- BÁO CÁO GIÁ TRỊ KHO ---");
        using (SqlConnection conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            // Gọi Stored Procedure đã tạo ở file 05_CreateReportProc.sql
            SqlCommand cmd = new SqlCommand("sp_GetInventoryReport", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("{0,-25} | {1,-10} | {2,-30}", "SẢN PHẨM", "TỒN", "TỔNG GIÁ TRỊ");
                Console.WriteLine(new string('-', 60));
                while (reader.Read())
                {
                    Console.WriteLine("{0,-25} | {1,-10} | {2,-30:N0}", 
                        reader["ProductName"], reader["StockQuantity"], reader["TotalValue"]);
                }
            }
        
        }
    }

    // --- QUẢN LÝ USER (Chỉ Admin mới gọi được hàm này) ---
    public static void ThemNguoiDung()
    {
        Console.WriteLine("\n--- TẠO TÀI KHOẢN MỚI ---");
        Console.Write("Tên đăng nhập: "); 
        string username = Console.ReadLine() ?? string.Empty;
        
        Console.Write("Mật khẩu: "); 
        string password = Console.ReadLine() ?? "";
        
        Console.Write("Họ tên: "); 
        string fullName = Console.ReadLine() ?? "N/A";
        
        Console.Write("Quyền (Admin/Staff): "); 
        string role = Console.ReadLine() ?? "Staff";

        using (var conn = DatabaseHelper.GetConnection())
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO Users (Username, Password, FullName, Role) VALUES (@u, @p, @f, @r)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    cmd.Parameters.AddWithValue("@f", fullName);
                    cmd.Parameters.AddWithValue("@r", role);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Đã tạo người dùng thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
    }

    // Hàm phụ: Ghi log (Private vì chỉ dùng nội bộ)
    private static void GhiLog(SqlConnection c, int id, string type, int q, string note) {
        string sql = "INSERT INTO TransactionHistory (ProductID, TransType, Quantity, Note) VALUES (@id, @t, @q, @n)";
        using var cmd = new SqlCommand(sql, c);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@t", type);
        cmd.Parameters.AddWithValue("@q", q);
        cmd.Parameters.AddWithValue("@n", note);
        cmd.ExecuteNonQuery();
    }
}
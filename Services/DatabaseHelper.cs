using Microsoft.Data.SqlClient;
using InventoryApp.Models;

namespace InventoryApp.Services;

public static class DatabaseHelper
{
    // LƯU Ý: Sửa lại Server name nếu máy bạn khác
    public static string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True;";

    // Hàm lấy kết nối
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}
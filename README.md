# 🏭 Inventory Management System (WMS) - Level 4
### *Hệ thống Quản lý Kho hàng chuyên nghiệp (Phân quyền & Báo cáo)*

---

## 🇻🇳 Tiếng Việt

### 📝 ***Giới thiệu***
Dự án này là một **Hệ thống quản lý kho (WMS)** thu nhỏ, được thiết kế để quản lý hàng hóa, tài khoản người dùng và báo cáo tài chính. Dự án áp dụng ***Kiến trúc phân tầng (Layered Architecture)*** để đảm bảo tính *linh hoạt* và *dễ bảo trì*.

### 🚀 ***Tính năng chính***
* **Quản lý tồn kho**: Theo dõi ***nhập/xuất*** hàng hóa theo thời gian thực.
* **Thẻ kho (Transaction History)**: Lưu vết chi tiết mọi biến động kho hàng (*Ai làm, làm gì, lúc nào*).
* **Phân quyền người dùng (RBAC)**: Đăng nhập phân cấp giữa **Admin** và **Staff**.
* **Báo cáo chuyên sâu**: Sử dụng **Stored Procedure** để tính toán ***tổng giá trị tồn kho*** chính xác từng đơn vị.

### 🛠 ***Công nghệ sử dụng***
* **Ngôn ngữ**: **C# (.NET 9)**.
* **Cơ sở dữ liệu**: **Microsoft SQL Server**.
* **Kiến trúc**: ***Models - Services - Presentation***.

---

## 🇺🇸 English

### 📝 ***Introduction***
This is a **Warehouse Management System (WMS)** built to manage products, user accounts, and financial reports. It implements a ***Layered Architecture*** for better *scalability* and *clean code*.

### 🚀 ***Key Features***
* **Inventory Management**: Real-time tracking of ***inbound and outbound*** goods.
* **Transaction History**: Detailed logs of every movement (*Who, What, When*).
* **Role-Based Access Control (RBAC)**: Login system with distinct roles for **Admin** (*Full access*) and **Staff** (*Inbound/Outbound only*).
* **Advanced Reporting**: Utilizes **SQL Stored Procedures** for high-performance ***inventory value calculation***.

### 🛠 ***Tech Stack***
* **Language**: **C# (.NET 9)**.
* **Database**: **Microsoft SQL Server**.
* **Architecture**: ***Models - Services - Presentation***.

---

## 📸 ***Demo Screenshot***
<img width="343" height="111" alt="image" src="https://github.com/user-attachments/assets/86feb5e4-0c28-4ab3-80a0-e3d22ecc9330" />

***Hình ảnh:** Quá trình đăng nhập hệ thống.*

<img width="643" height="413" alt="image" src="https://github.com/user-attachments/assets/5839450f-568e-4d13-acca-f1106670bcb1" />

***Hình ảnh:** Báo cáo tổng giá trị kho hàng được tính toán tự động từ Data mẫu chỉ được truy cập bởi người có quyền Admin.*

---

## ⚙️ ***Cài đặt / Installation***

1.  **SQL Setup**: Chạy các file trong thư mục `/SQL` theo thứ tự từ **01** đến **05** (có thể bỏ qua **02** nếu kho trống).
2.  **C# Setup**: 
    * Cấu hình ***ConnectionString*** trong file `Services/DatabaseHelper.cs`.
    * Sử dụng lệnh `dotnet run` để bắt đầu ứng dụng.

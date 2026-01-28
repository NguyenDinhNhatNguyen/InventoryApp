# 🏭 ProWMS - Inventory Management System

![.NET](https://img.shields.io/badge/.NET-9.0-purple?style=flat&logo=dotnet)
![SQL Server](https://img.shields.io/badge/Database-SQL_Server-red?style=flat&logo=microsoft-sql-server)
![Architecture](https://img.shields.io/badge/Architecture-Layered-blue)

> *Switch language: [🇻🇳 Tiếng Việt](#-tiếng-việt) | [🇺🇸 English](#-english)*

--- 

## 🇻🇳 Tiếng Việt

### 📝 ***Giới thiệu***
Dự án này là một **Hệ thống quản lý kho** thu nhỏ, được thiết kế để quản lý hàng hóa, tài khoản người dùng và báo cáo tài chính. Dự án áp dụng ***Kiến trúc phân tầng*** để đảm bảo tính *linh hoạt* và *dễ bảo trì*.

### 🚀 Tính năng nổi bật
* **📦 Quản lý nhập/xuất Real-time**: Theo dõi biến động kho ngay lập tức.
* **🛡️ Phân quyền chặt chẽ (RBAC)**:
    * **Admin**: Toàn quyền hệ thống, xem báo cáo tài chính.
    * **Staff**: Chỉ được phép nhập/xuất kho, giới hạn quyền xem giá trị.
* **📊 Báo cáo hiệu năng cao**: Sử dụng **SQL Stored Procedures** để tính toán tổng giá trị tồn kho của hàng nghìn mã hàng trong tích tắc.
* **📝 Audit Log**: Ghi lại lịch sử chi tiết: *Ai làm? Làm gì? Lúc nào?*

### 🛠 ***Công nghệ sử dụng***
* **Ngôn ngữ**: **C# (.NET 9)**.
* **Cơ sở dữ liệu**: **Microsoft SQL Server**.
* **Kiến trúc**: ***Models - Services - Presentation***.

---

## 🇺🇸 English

### 📝 ***Introduction***
This is a **Warehouse Management System (WMS)** built to manage products, user accounts, and financial reports. It implements a ***Layered Architecture*** for better *scalability* and *clean code*.

### 🚀 Key Features
* **📦 Real-time Inbound/Outbound Management**: Instantly track inventory movements and fluctuations.
* **🛡️ Strict Role-Based Access Control (RBAC)**:
    * **Admin**: Full system access, authorized to view financial reports.
    * **Staff**: Restricted to stock operations (Inbound/Outbound) only; limited access to financial values.
* **📊 High-Performance Reporting**: Utilizes **SQL Stored Procedures** to calculate the total inventory value of thousands of SKUs instantly.
* **📝 Audit Log**: Detailed transaction history recording: *Who did it? What was done? When did it happen?*

### 🛠 ***Tech Stack***
* **Language**: **C# (.NET 9)**.
* **Database**: **Microsoft SQL Server**.
* **Architecture**: ***Models - Services - Presentation***.

---

## 📸 ***Demo Screenshot***
<img width="343" height="111" alt="image" src="https://github.com/user-attachments/assets/86feb5e4-0c28-4ab3-80a0-e3d22ecc9330" />
<img width="536" height="118" alt="image" src="https://github.com/user-attachments/assets/73eb0e3f-b92a-43e1-9195-e4feb0d86a4b" />

***Hình ảnh:** Quá trình đăng nhập hệ thống (Đúng/Sai).*

<img width="490" height="401" alt="image" src="https://github.com/user-attachments/assets/14f118a0-4aeb-40ab-a57f-3850eb068276" />

***Hình ảnh:** Báo cáo xem hàng tồn kho hàng từ Data mẫu được truy cập bởi người có quyền Staff.*

<img width="643" height="413" alt="image" src="https://github.com/user-attachments/assets/5839450f-568e-4d13-acca-f1106670bcb1" />

***Hình ảnh:** Báo cáo tổng giá trị kho hàng được tính toán tự động từ Data mẫu chỉ được truy cập bởi người có quyền Admin.*

---

## ⚙️ ***Cài đặt (Installation)***

1.  **SQL Setup**: Chạy các file trong thư mục `/SQL` theo thứ tự từ **01** đến **05** (có thể bỏ qua **02** nếu kho trống).
2.  **C# Setup**: 
    * Cấu hình ***ConnectionString*** trong file `Services/DatabaseHelper.cs`.
    * Sử dụng lệnh `dotnet run` để bắt đầu ứng dụng.

### 📂 Cấu trúc dự án
```text
InventoryApp
├── Models           # Chứa các thực thể (Product, User, Transaction)
├── Services         # Xử lý logic nghiệp vụ & DatabaseHelper
├── SQL              # Các script khởi tạo Database & Stored Procs
└── Program.cs        # Entry Point

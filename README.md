# 🏭 Inventory Management System

![.NET](https://img.shields.io/badge/.NET-9.0-purple?style=flat&logo=dotnet)
![SQL Server](https://img.shields.io/badge/Database-SQL_Server-red?style=flat&logo=microsoft-sql-server)
![Architecture](https://img.shields.io/badge/Architecture-Layered-blue)

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

***Image:** System login process (Password: True/False).*

<img width="490" height="401" alt="image" src="https://github.com/user-attachments/assets/14f118a0-4aeb-40ab-a57f-3850eb068276" />

***Image:** Inventory report from sample data accessed by a staff member with authorized privileges.*

<img width="643" height="413" alt="image" src="https://github.com/user-attachments/assets/5839450f-568e-4d13-acca-f1106670bcb1" />

***Image:** The inventory value report is automatically calculated from sample data and is only accessible to users with administrator privileges.*

---
## ⚙️ Installation

### Prerequisites
* [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
* Microsoft SQL Server & SSMS

### Setup Guide
1.  **Clone Repository:**
    ```bash
    git clone [https://github.com/NguyenDinhNhatNguyen/InventoryApp]
    cd Inventory-Management-System
    ```

2.  **Database Setup:**
    * Open **SQL Server Management Studio (SSMS)**.
    * Execute the scripts in the `/SQL` folder in the following order:
        1.  `01_CreateDatabase.sql`
        2.  `02_CreateTables.sql` *(Creates Users, Products, Transactions tables)*
        3.  `03_StoredProcedures.sql` *(Creates Login, UpdateStock, GetReport procedures)*
        4.  `04_SeedData.sql` *(Inserts sample Admin/Staff accounts)*

3.  **Configuration:**
    * Open `Services/DatabaseHelper.cs`.
    * Update the `connectionString` to match your local environment:
        ```csharp
        public static string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True;";
        ```

4.  **Run Application:**
    ```bash
    dotnet run
    ```
    
## 📂 Project Structure
```text
InventoryApp
├── Models/           # Data Entities (Product, User, Transaction)
│   ├── Product.cs
│   ├── TransactionLog.cs
│   └── User.cs
├── Services/         # Business Logic & Database Communication (DAL)
│   ├── DatabaseHelper.cs
│   └── WarehouseService.cs
├── SQL/              # SQL Scripts for Database Initialization
│   ├── 01_InitDatabase.sql
│   ├── 02_SampleData.sql
│   ├── 03_TransactionHistory.sql
│   ├── 04_AddUserTable.sql
│   └── 05_CreateReport.sql
└── Program.cs        # Entry Point
```

## 🤝 Contributing 
This project is open for contributions, especially for optimizing Stored Procedures or enhancing the UI. Please feel free to create a Pull Request.

## 👤 Author
Nguyễn Đình Nhật Nguyên - Computer Engineering Student @ UIT-VNUHCM

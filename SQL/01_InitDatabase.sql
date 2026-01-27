-- 1. Chuyển ra "phòng chờ" (master) để không bị kẹt trong InventoryDB
USE master;
GO

-- 2. Kiểm tra nếu InventoryDB đã tồn tại thì...
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'InventoryDB')
BEGIN
    -- ...Set Single User
    ALTER DATABASE InventoryDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    -- ...Sau đó mới xóa sạch sẽ
    DROP DATABASE InventoryDB;
END
GO

-- 3. Tạo lại Database mới tinh
CREATE DATABASE InventoryDB;
GO

-- 4. Bắt đầu sử dụng Database mới
USE InventoryDB;
GO

-- 5. Tạo bảng Sản phẩm
DROP TABLE Products
GO

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 0),
    StockQuantity INT DEFAULT 0
);
GO

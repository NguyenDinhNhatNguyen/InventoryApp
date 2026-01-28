USE InventoryDB;
GO

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(50) NOT NULL, -- Lưu text thường cho dễ (Thực tế phải mã hóa)
    FullName NVARCHAR(100),
    Role NVARCHAR(20) DEFAULT 'Staff' -- 'Admin' hoặc 'Staff'
);


INSERT INTO Users (Username, Password, FullName, Role) VALUES 
-- Tạo admin / 090305
('admin', '090305', N'Nguyễn Đình Nhật Nguyên', 'Admin'),
-- Tạo staff mẫu / 081106
('staff01','081106', N'Đoàn Phú Mỹ Hưng', 'Staff');
GO

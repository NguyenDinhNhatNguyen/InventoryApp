USE InventoryDB;
GO

CREATE TABLE TransactionHistory (
    TransID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT,
    TransType NVARCHAR(20), -- 'NHAP' hoặc 'XUAT'
    Quantity INT,
    TransDate DATETIME DEFAULT GETDATE(),
    Note NVARCHAR(200),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO
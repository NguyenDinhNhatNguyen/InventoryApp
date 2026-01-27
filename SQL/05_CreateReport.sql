USE InventoryDB;
GO

CREATE PROCEDURE sp_GetInventoryReport
AS
BEGIN
    -- Lấy danh sách SP và tính tổng tiền tồn kho của từng món
    SELECT 
        ProductID,
        ProductName,
        StockQuantity,
        ISNULL(Price, 0) AS UnitPrice,
        -- Tính tổng: ép kiểu về Decimal để tránh lỗi tràn số khi tiền lên hàng tỷ
        (CAST(StockQuantity AS DECIMAL(18,2)) * ISNULL(Price, 0)) AS TotalValue
    FROM Products
    ORDER BY TotalValue DESC;
END  
GO
using System;

namespace InventoryApp.Models;

public class TransactionLog
{
    public int TransID { get; set; }
    public int ProductID { get; set; }
    public string TransType { get; set; } // "NHAP" hoặc "XUAT"
    public int Quantity { get; set; }
    public DateTime TransDate { get; set; }
    public string Note { get; set; }
}
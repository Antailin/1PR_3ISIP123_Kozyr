using pr_7;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoService
{
    public class Part
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Warehouse
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
    }

    public class WarehousePart
    {
        public int WarehouseID { get; set; }
        public int PartID { get; set; }
        public int Count { get; set; }
    }

    public class Customer
    {
        public int ID { get; set; }
        public string CarModel { get; set; }
        public int BrokenPartID { get; set; }
        public decimal RepairCost { get; set; }
        public bool IsServed { get; set; }
    }

    public class PurchaseOrder
    {
        public int PartID { get; set; }
        public int Quantity { get; set; }
        public int RemainingCars { get; set; }
    }
}

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

    public class AutoServiceGame
    {
        private Warehouse warehouse;
        private List<Part> availableParts;
        private List<WarehousePart> warehouseParts;
        private List<PurchaseOrder> pendingOrders;
        private Random random;

        public AutoServiceGame()
        {
            this.random = new Random();
            this.pendingOrders = new List<PurchaseOrder>();
            InitializeGame();
        }

        private void InitializeGame()
        {
            LoadWarehouseData();
            LoadAvailableParts();
            Console.WriteLine("Добро пожаловать в автосервис!");
            Console.WriteLine($"Начальный баланс: {warehouse.Balance:C}");
            ShowWarehouseStatus();
        }
        private void LoadWarehouseData()
        {
            var dbWarehouse = Core.Context.Sklad.FirstOrDefault();
            if (dbWarehouse != null)
            {
                warehouse = new Warehouse
                {
                    ID = dbWarehouse.ID,
                    Balance = (int)dbWarehouse.Balance
                };
            }
        }
    }
}
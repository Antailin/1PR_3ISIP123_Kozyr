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
            Console.WriteLine($"Начальный баланс: {warehouse.Balance}");
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
            warehouseParts = new List<WarehousePart>();
            var dbWarehouseParts = Core.Context.DetaleSklad.ToList();
            foreach (var dbPart in dbWarehouseParts)
            {
                warehouseParts.Add(new WarehousePart
                {
                    WarehouseID = dbPart.SkladID,
                    PartID = dbPart.DetaleID,
                    Count = (int)dbPart.Count
                });
            }
        }
        private void LoadAvailableParts()
        {
            availableParts = new List<Part>();
            var dbParts = Core.Context.Detale.ToList();
            foreach (var dbPart in dbParts)
            {
                availableParts.Add(new Part
                {
                    ID = dbPart.ID,
                    Name = dbPart.Name,
                    Price = (decimal)dbPart.Price
                });
            }
        }
        public void StartGame()
        {
            int carCounter = 0;

            while (true)
            {
                carCounter++;
                Console.WriteLine($"\nМашина #{carCounter}");
                ProcessPendingOrders();
                var customer = GenerateCustomer();
                ShowCustomerInfo(customer);
                ProcessCustomerService(customer);
                if (warehouse.Balance <= 0)
                {
                    Console.WriteLine("\nВы банкрот! Игра окончена.");
                    break;
                }
                ShowWarehouseStatus();
                ShowMainMenu();
            }
        }
        private void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nГлавное меню");
                Console.WriteLine("1 - Следующий клиент");
                Console.WriteLine("2 - Заказать детали");
                Console.WriteLine("3 - Показать статус склада");
                Console.Write("Выберите действие: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        return;
                    case "2":
                        ShowPurchaseMenu();
                        break;
                    case "3":
                        ShowWarehouseStatus();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор! Попробуйте снова.");
                        break;
                }
            }
        }
        private Customer GenerateCustomer()
        {
            var brokenPart = availableParts[random.Next(availableParts.Count)];
            var workCost = brokenPart.Price * 0.3m;
            var repairCost = brokenPart.Price + workCost;

            return new Customer
            {
                ID = random.Next(1000, 9999),
                CarModel = GenerateCarModel(),
                BrokenPartID = brokenPart.ID,
                RepairCost = repairCost,
                IsServed = false
            };
        }
        private string GenerateCarModel()
        {
            var brands = new[] { "Toyota", "Honda", "Ford", "BMW", "Mercedes", "Audi", "Volkswagen", "Hyundai" };
            var models = new[] { "Camry", "Civic", "Focus", "X5", "C-Class", "A4", "Golf", "Elantra" };

            return $"{brands[random.Next(brands.Length)]} {models[random.Next(models.Length)]}";
        }
    }
}
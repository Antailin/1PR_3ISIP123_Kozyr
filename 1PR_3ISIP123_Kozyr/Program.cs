using System;
List<Product> products = new List<Product>();
int id = 1;
Console.WriteLine("\nВыберите действие: ");
Console.WriteLine("1. Добавить товар");
Console.WriteLine("2. Удалить товар");
Console.WriteLine("3. Заказать поставку товара");
Console.WriteLine("4. Продать товар");
Console.WriteLine("5. Поиск товаров");
Console.WriteLine("6. Показать склад");
Console.WriteLine("7. Выход");
int choice = Convert.ToInt32(Console.ReadLine());
while (choice != 7)
{
    switch (choice)
    {
        case 1:
            AddProduct();
            break;
        case 2:
            RemoveProduct();
            break;
        case 3:
            BuyProduct();
            break;
        case 4:
            SellProduct();
            break;
        case 5:
            SearchProduct();
            break;
        case 6:
            DisplayAllProducts();
            break;
    }
    Console.WriteLine("\nВыберите действие: ");
    Console.WriteLine("1. Добавить товар");
    Console.WriteLine("2. Удалить товар");
    Console.WriteLine("3. Заказать поставку товара");
    Console.WriteLine("4. Продать товар");
    Console.WriteLine("5. Поиск товаров");
    Console.WriteLine("6. Показать склад");
    Console.WriteLine("7. Выход");
    choice = Convert.ToInt32(Console.ReadLine());
}

void AddProduct()
{ 
    Console.WriteLine("Введите название: ");
    string name = Console.ReadLine();

    Console.WriteLine("Введите цену: ");
    double price = double.Parse(Console.ReadLine());

    Console.WriteLine("Введите количество: ");
    int count = int.Parse(Console.ReadLine());



    Console.WriteLine($"Выберите категорию:\n 1. {Categ.Транспорт}\n 2. {Categ.Спорт}\n 3. {Categ.Одежда}");

    int categoria = int.Parse(Console.ReadLine());
    Categ category=Categ.Неопр;
    switch (categoria)
    {
        case 1:
            category = Categ.Транспорт;
            break;
        case 2:
            category = Categ.Спорт;
            break;
        case 3:
            category = Categ.Одежда;
            break;
    }

    products.Add(new Product(id, name, price, count, category));
    Console.WriteLine("Товар успешно добавлен!");
    id++;
}

void RemoveProduct()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Список товаров пуст!");
        return;
    }

    Console.WriteLine("Введите ID товара для удаления: ");
    int targetId = Convert.ToInt32(Console.ReadLine());
    Product productToRemove = products.FirstOrDefault(p => p.ProductID == targetId);
    if (productToRemove != null)
    {
        products.Remove(productToRemove);
        Console.WriteLine($"Товар с ID {targetId} успешно удален!");
    }
    else
    {
        Console.WriteLine($"Товар с ID {targetId} не найден!");
    }
}

void BuyProduct()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Список товаров пуст!");
        return;
    }

    Console.WriteLine("Введите ID товара для закупки: ");
    int targetId = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ведите кол-во единиц для закупа: ");
    int AddCount = Convert.ToInt32(Console.ReadLine());
    Product productToBuy = products.FirstOrDefault(p => p.ProductID == targetId);
    if (productToBuy != null)
    {
        productToBuy.Count = productToBuy.Count + AddCount;
    }
    Console.WriteLine($"Закупка прошла успешно! На складе теперь находится {productToBuy.Count} единиц товара <{productToBuy.Name}>");
}


void SellProduct()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Список товаров пуст!");
        return;
    }

    Console.WriteLine("Введите ID товара для продажи: ");
    int targetId = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ведите кол-во единиц для продажи: ");
    int SellCount = Convert.ToInt32(Console.ReadLine());
    Product productToSell = products.FirstOrDefault(p => p.ProductID == targetId);
    if (productToSell != null) 
    { 
        if (productToSell.Count < SellCount)
        {
            Console.WriteLine($"На складе меньше, чем {SellCount} единиц данного товара");
        }
        else
        {
            productToSell.Count = productToSell.Count - SellCount;
        }
        Console.WriteLine($"Продажа прошла успешно! На складе теперь находится {productToSell.Count} единиц товара <{productToSell.Name}>");
    }
}
void SearchProduct()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Список товаров пуст!");
        return;
    }

    Console.WriteLine("\nВыберите критерий поиска:");
    Console.WriteLine("1. Поиск по названию");
    Console.WriteLine("2. Поиск по категории");
    Console.WriteLine("3. Поиск по ID");

    int searchChoice = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Результат поиска:");
    switch (searchChoice)
    {
        case 1:
            Console.WriteLine("Введите название товара для поиска: ");
            string targetName = Console.ReadLine();
            Product productToFindName = products.FirstOrDefault(p => p.Name == targetName);
            if (productToFindName != null)
            {
                productToFindName.PrintInfo();
            }
            break;
        case 2:
            Console.WriteLine($"Выберите категорию товара для поиска: \n 1. {Categ.Транспорт}\n 2. {Categ.Спорт}\n 3. {Categ.Одежда}");
            int categatake = Convert.ToInt32(Console.ReadLine());
            Categ G = Categ.Неопр;
            switch (categatake)
            {
                case 1:
                    G = Categ.Транспорт;
                    break;
                case 2:
                    G = Categ.Спорт;
                    break;
                case 3:
                    G = Categ.Одежда;
                    break;
            }
            for (int i = 0; i < products.Count ; i++)
            {
                if (products[i].Category == G)
                {

                }
            }
            break;
        case 3:
            Console.WriteLine("Введите ID товара для поиска: ");
            int targetId = Convert.ToInt32(Console.ReadLine());
            Product productToFindId = products.FirstOrDefault(p => p.ProductID == targetId);
            if (productToFindId != null)
            {
                productToFindId.PrintInfo();
            }
                break;
    }
}

void DisplayAllProducts()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Список товаров пуст!");
        return;
    }

    Console.WriteLine("\nСписок товаров:");
    foreach (Product product in products)
    {
        product.PrintInfo();
    }
}
public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Count { get; set; }
    public bool Availability = true;
     public Categ Category;

    public Product(int ProductId, string Name, double Price, int Count, Categ category)
    {
        this.ProductID = ProductId;
        this.Name = Name;
        this.Price = Price;
        this.Count = Count;
        Category = category;
    }

    public void PrintInfo()
    {
        if (Count > 0)
        {
            Availability = true;
        }
        else
        {
            Availability = false;
        }
            Console.WriteLine($"ID: {ProductID}");
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Цена: {Price:C}");
        Console.WriteLine($"Количество: {Count}");
        Console.WriteLine($"Остался ли товар: {Availability}");
        Console.WriteLine($"Категория: {Category}");
    }
}
public enum Categ
{
    Неопр,
    Спорт,
    Одежда,
    Транспорт

}

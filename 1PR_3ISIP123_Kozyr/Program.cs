using System;
List<Product> products = new List<Product>();
int id = 1;
Console.WriteLine("\nВыберите действие: ");
Console.WriteLine("1. Добавить товар");
Console.WriteLine("2. Удалить товар");
Console.WriteLine("3. Заказать поставку товара");
Console.WriteLine("4. Продать товар");
Console.WriteLine("5. Поиск товаров");
Console.WriteLine("6. Выход");
int choice = Convert.ToInt32(Console.ReadLine());
while (choice != 6)
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
    }
}

void AddProduct()
{ 
    Console.WriteLine("Введите название: ");
    string name = Console.ReadLine();

    Console.WriteLine("Введите цену: ");
    double price = double.Parse(Console.ReadLine());

    Console.WriteLine("Введите количество: ");
    int count = int.Parse(Console.ReadLine());

    Console.WriteLine("Есть ли товар на складе: ");
    string availability = Console.ReadLine();

    Console.WriteLine($"Выберите категорию: 1. {Categ.Транспорт}\n 2. {Categ.Спорт}\n 3. {Categ.Одежда}");

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

    products.Add(new Product(id, name, price, count, availability, category));
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
    Console.WriteLine("Введите ID товара для закупки: ");
    int targetId = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ведите кол-во единиц для закупа: ");
    int AddCount = Convert.ToInt32(Console.ReadLine());
    Product productToBuy = products.FirstOrDefault(p => p.ProductID == targetId);
    if (productToBuy != null)
    {
        productToBuy.Count = productToBuy.Count + AddCount;
    }

}


void SellProduct()
{
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
}
public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Count { get; set; }
    public string Availability {  get; set; }
    static public Categ Category;

    public Product(int ProductId, string Name, double Price, int Count, string Availability, Categ category)
    {
        this.ProductID = ProductId;
        this.Name = Name;
        this.Price = Price;
        this.Count = Count;
        this.Availability = Availability;
        Category = category;
    }

    public void PrintInfo()
    {
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

List<Book> library = new List<Book>();
Console.WriteLine("\n*** МЕНЮ ***");
Console.WriteLine("1 - Добавить книгу");
Console.WriteLine("2 - Удалить книгу");
Console.WriteLine("3 - Найти книги");
Console.WriteLine("4 - Сортировать книги");
Console.WriteLine("5 - Самая дорогая/дешевая книга");
Console.WriteLine("6 - Статистика по авторам");
Console.WriteLine("7 - Показать все книги");
Console.WriteLine("8 - Выход");
Console.Write("Ваш выбор: ");
string choice = Console.ReadLine();
while (choice != "8")
{
    switch (choice)
    {
        case "1":
            AddBook();
            break;
        case "2":
            RemoveBook();
            break;
        case "3":
            SearchBooks();
            break;
        case "4":
            SortBooks();
            break;
        case "5":
            ShowPriceInfo();
            break;
        case "6":
            ShowAuthorStats();
            break;
        case "7":
            ShowAllBooks();
            break;
        case "8":
            Console.WriteLine("Выход из программы...");
            return;
    }
    Console.WriteLine("\n*** МЕНЮ ***");
    Console.WriteLine("1 - Добавить книгу");
    Console.WriteLine("2 - Удалить книгу");
    Console.WriteLine("3 - Найти книги");
    Console.WriteLine("4 - Сортировать книги");
    Console.WriteLine("5 - Самая дорогая/дешевая книга");
    Console.WriteLine("6 - Статистика по авторам");
    Console.WriteLine("7 - Показать все книги");
    Console.WriteLine("8 - Выход");
    Console.Write("Ваш выбор: ");
    choice = Console.ReadLine();
}
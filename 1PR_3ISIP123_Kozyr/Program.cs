List<Book> library = new List<Book>();
int nextId = 1;
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
            SearchBook();
            break;
        case "4":
            SortBooks();
            break;
        case "5":
            PriceInfo();
            break;
        case "6":
            AuthorStats();
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
void AddBook()
{
    Book newBook = new Book();
    newBook.Id = nextId;
    Console.Write("Введите название: ");
    newBook.Name = Console.ReadLine();
    Console.Write("Введите автора: ");
    newBook.Author = Console.ReadLine();
    Console.WriteLine("Выберите жанр:");
    Console.WriteLine("0 - Fantasy");
    Console.WriteLine("1 - Science");
    Console.WriteLine("2 - Romance");
    Console.Write("Ваш выбор: ");

    if (int.TryParse(Console.ReadLine(), out int GenreChoice))
    {
        if (GenreChoice >= 0 && GenreChoice <= 2)
        {
            newBook.Genre = (BookGenre)GenreChoice;
        }
        else
        {
            Console.WriteLine("Ошибка! Допустимые значения: 0-2.  Жанр установлен как Fantasy");
            newBook.Genre = BookGenre.Fantasy;
        }
    }
    else
    {
        Console.WriteLine("Ошибка! Жанр установлен как Fantasy");
        newBook.Genre = BookGenre.Fantasy;
    }
    Console.Write("Введите год издания: ");
    if (int.TryParse(Console.ReadLine(), out int year))
    {
        newBook.Year = year;
    }
    else
    {
        Console.WriteLine("Ошибка! Год установлен как 2000");
        newBook.Year = 2000;
    }

    Console.Write("Введите цену: ");
    if (int.TryParse(Console.ReadLine(), out int price))
    {
        newBook.Price = price;
    }
    else
    {
        Console.WriteLine("Ошибка! Цена установлена как 0 руб.");
        newBook.Price = 0;
    }
    library.Add(newBook);
    Console.WriteLine($"Книга добавлена! ID: {newBook.Id}");
    nextId++;

}
void RemoveBook()
{
    Console.Write("\nВведите ID книги для удаления: ");

    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Book bookToRemove = library.FirstOrDefault(b => b.Id == id);
        if (bookToRemove != null)
        {
            library.Remove(bookToRemove);
            Console.WriteLine($"Книга с ID {id} удалена!");
        }
        else
        {
            Console.WriteLine("Книга с таким ID не найдена!");
        }
    }
    else
    {
        Console.WriteLine("Неверный формат ID!");
    }

}
void SearchBook()
{
    Console.WriteLine("1 - По названию");
    Console.WriteLine("2 - По автору");
    Console.WriteLine("3 - По жанру");
    Console.Write("Ваш выбор: ");

    string searchType = Console.ReadLine();
    var results = new List<Book>();

    switch (searchType)
    {
        case "1": // По названию
            Console.Write("Введите название: ");
            string title = Console.ReadLine();
            results = library.Where(b => b.Name.ToLower().Contains(title.ToLower())).ToList();
            break;

        case "2":
            Console.Write("Введите автора: ");
            string author = Console.ReadLine();
            results = library.Where(b => b.Author.ToLower().Contains(author.ToLower())).ToList();
            break;

        case "3":
            Console.WriteLine("Выберите жанр (0-Fantasy, 1-Science, 2-Romance): ");
            if (int.TryParse(Console.ReadLine(), out int genre))
            {
                results = library.Where(b => b.Genre == (BookGenre)genre).ToList();
            }
            break;

        default:
            Console.WriteLine("Неверный выбор!");
            return;
    }
    if (results.Any())
    {
        Console.WriteLine($"Найдено книг: {results.Count}");
        foreach (var book in results)
        {
            book.PrintInfo();
        }
    }
    else
    {
        Console.WriteLine("Книги не найдены!");
    }

}
void SortBooks()
{
    Console.WriteLine("1 - По названию");
    Console.WriteLine("2 - По году издания");
    Console.Write("Ваш выбор: ");

    string SortType = Console.ReadLine();
    IEnumerable<Book> SortedBooks;

    switch (SortType)
    {
        case "1": 
            SortedBooks = library.OrderBy(b => b.Name);
            Console.WriteLine("\nКниги отсортированы по названию:");
            break;

       case "2": 
            SortedBooks = library.OrderBy(b => b.Year);
            Console.WriteLine("\nКниги отсортированы по году издания:");
            break;
             
        default:
            Console.WriteLine("Неверный выбор!");
            return;
    }

    foreach (var book in SortedBooks)
    {
        book.PrintInfo();
    }

}
void PriceInfo()
{
    if (library.Any() == false)
    {
        Console.WriteLine("Библиотека пуста!");
        return;
    }

    var MostExpensive = library.OrderByDescending(b => b.Price).First();
    var Cheapest = library.OrderBy(b => b.Price).First();

    Console.WriteLine("\nСАМАЯ ДОРОГАЯ КНИГА");
    MostExpensive.PrintInfo();

    Console.WriteLine("САМАЯ ДЕШЕВАЯ КНИГА");
    Cheapest.PrintInfo();
}
void AuthorStats()
{

}
void ShowAllBooks()
{

}

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public BookGenre Genre { get; set; }
    public int Year { get; set; }
    public int Price { get; set; }

    public Book() { }
    public Book(int BookId, string BookName, string BookAuthor, BookGenre BookGenre, int BookYear, int BookPrice)
    {
        Id = BookId;
        Name = BookName;
        Author = BookAuthor;
        Genre = BookGenre;
        Year = BookYear;
        Price = BookPrice;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Жанр: {Genre}");
        Console.WriteLine($"Год: {Year} г.");
        Console.WriteLine($"Цена: {Price} руб.");
        Console.WriteLine();
    }

}
public enum BookGenre
{
    Fantasy,
    Science,
    Romance
}

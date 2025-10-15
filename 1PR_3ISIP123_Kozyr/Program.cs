var university = new UniversitySystem();
bool running = true;
while (running)
{
    ShowMainMenu();
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ManageStudents(university);
            break;
        case "2":
            ManageTeachers(university);
            break;
        case "3":
            ManageCourses(university);
            break;
        case "4":
            ShowAllInformation(university);
            break;
        case "0":
            running = false;
            Console.WriteLine("До свидания!");
            break;
        default:
            Console.WriteLine("Неверный выбор!");
            break;
    }
}
static void ShowMainMenu()
{
    Console.WriteLine("\nСИСТЕМА УПРАВЛЕНИЯ УНИВЕРСИТЕТОМ");
    Console.WriteLine("1. Управление студентами");
    Console.WriteLine("2. Управление преподавателями");
    Console.WriteLine("3. Управление курсами");
    Console.WriteLine("4. Просмотр всей информации");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите опцию: ");
}

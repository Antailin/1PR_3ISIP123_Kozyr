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
static void ManageStudents(UniversitySystem university)
{
    bool inMenu = true;
    while (inMenu)
    {
        Console.WriteLine("\nУПРАВЛЕНИЕ СТУДЕНТАМИ");
        Console.WriteLine("1. Добавить студента");
        Console.WriteLine("2. Показать всех студентов");
        Console.WriteLine("3. Записать студента на курс");
        Console.WriteLine("4. Показать курсы студента");
        Console.WriteLine("0. Назад");
        Console.Write("Выберите опцию: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите возраст: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Введите email: ");
                string email = Console.ReadLine();
                Console.Write("Введите ID студента: ");
                string studentId = Console.ReadLine();
                university.AddStudent(name, age, email, studentId);
                break;
            case "2":
                university.ShowAllStudents();
                break;
            case "3":
                Console.Write("Введите ID студента: ");
                string studId = Console.ReadLine();
                Console.Write("Введите ID курса: ");
                int coursId = int.Parse(Console.ReadLine());
                university.EnrollStudentInCourse(studId, coursId);
                break;
            case "4":
                Console.Write("Введите ID студента: ");
                string studentIdCourses = Console.ReadLine();
                university.ShowStudentCourses(studentIdCourses);
                break;
            case "0":
                inMenu = false;
                break;
            default:
                Console.WriteLine("Неверный выбор!");
                break;
        }
    }
}
static void ManageTeachers(UniversitySystem university)
{
    bool inMenu = true;
    while (inMenu)
    {
        Console.WriteLine("\nУПРАВЛЕНИЕ ПРЕПОДАВАТЕЛЯМИ");
        Console.WriteLine("1. Добавить преподавателя");
        Console.WriteLine("2. Показать всех преподавателей");
        Console.WriteLine("3. Назначить преподавателя на курс");
        Console.WriteLine("4. Показать курсы преподавателя");
        Console.WriteLine("0. Назад");
        Console.Write("Выберите опцию: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите возраст: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Введите email: ");
                string email = Console.ReadLine();
                Console.Write("Введите ID преподавателя: ");
                string teacherId = Console.ReadLine();
                Console.Write("Введите кафедру: ");
                string department = Console.ReadLine();
                university.AddTeacher(name, age, email, teacherId, department);
                break;
            case "2":
                university.ShowAllTeachers();
                break;
            case "3":
                Console.Write("Введите ID преподавателя: ");
                string teachId = Console.ReadLine();
                Console.Write("Введите ID курса: ");
                int coursId = int.Parse(Console.ReadLine());
                university.AssignTeacherToCourse(teachId, coursId);
                break;
            case "4":
                Console.Write("Введите ID преподавателя: ");
                string teacherIdCourses = Console.ReadLine();
                university.ShowTeacherCourses(teacherIdCourses);
                break;
            case "0":
                inMenu = false;
                break;
            default:
                Console.WriteLine("Неверный выбор!");
                break;
        }
    }
}


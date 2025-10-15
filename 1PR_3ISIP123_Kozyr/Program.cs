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
static void ManageCourses(UniversitySystem university)
{
    bool inMenu = true;
    while (inMenu)
    {
        Console.WriteLine("\nУПРАВЛЕНИЕ КУРСАМИ");
        Console.WriteLine("1. Добавить курс");
        Console.WriteLine("2. Показать все курсы");
        Console.WriteLine("3. Показать студентов курса");
        Console.WriteLine("0. Назад");
        Console.Write("Выберите опцию: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Write("Введите название курса: ");
                string name = Console.ReadLine();
                Console.Write("Введите описание курса: ");
                string description = Console.ReadLine();
                university.AddCourse(name, description);
                break;
            case "2":
                university.ShowAllCourses();
                break;
            case "3":
                Console.Write("Введите ID курса: ");
                int courseId = int.Parse(Console.ReadLine());
                university.ShowCourseStudents(courseId);
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
static void ShowAllInformation(UniversitySystem university)
{
    Console.WriteLine("\nПОЛНАЯ ИНФОРМАЦИЯ О СИСТЕМЕ");
    university.ShowAllStudents();
    university.ShowAllTeachers();
    university.ShowAllCourses();

}
public class UniversitySystem
{
    private List<Student> students;
    private List<Teacher> teachers;
    private List<Course> courses;
    private int nextPersonId;
    private int nextCourseId;

    public UniversitySystem()
    {
        students = new List<Student>();
        teachers = new List<Teacher>();
        courses = new List<Course>();
        nextPersonId = 1;
        nextCourseId = 1;
    }
    public void ShowAllStudents()
    {
        if (!students.Any())
        {
            Console.WriteLine("Студентов нет в системе.");
            return;
        }

        Console.WriteLine("\nВСЕ СТУДЕНТЫ");
        foreach (var student in students)
        {
            Console.WriteLine(student.GetInfo());
        }
    }
    public void ShowAllTeachers()
    {
        if (!teachers.Any())
        {
            Console.WriteLine("Преподавателей нет в системе.");
            return;
        }

        Console.WriteLine("\nВСЕ ПРЕПОДАВАТЕЛИ");
        foreach (var teacher in teachers)
        {
            Console.WriteLine(teacher.GetInfo());
        }
    }
    public void ShowAllCourses()
    {
        if (!courses.Any())
        {
            Console.WriteLine("Курсов нет в системе.");
            return;
        }

        Console.WriteLine("\nВСЕ КУРСЫ");
        foreach (var course in courses)
        {
            Console.WriteLine(course.GetInfo());
            Console.WriteLine("---");
        }
    }
    public void AddStudent(string name, int age, string email, string studentId)
    {
        var student = new Student(nextPersonId++, name, age, email, studentId);
        students.Add(student);
        Console.WriteLine("Студент успешно добавлен!");
    }
    public void AddTeacher(string name, int age, string email, string teacherId, string department)
    {
        var teacher = new Teacher(nextPersonId++, name, age, email, teacherId, department);
        teachers.Add(teacher);
        Console.WriteLine("Преподаватель успешно добавлен!");
    }
    public void AddCourse(string name, string description)
    {
        var course = new Course(nextCourseId++, name, description);
        courses.Add(course);
        Console.WriteLine("Курс успешно добавлен!");
    }
    public Student FindStudentById(string studentId)
    {
        return students.FirstOrDefault(s => s.StudentId == studentId);
    }
    public Teacher FindTeacherById(string teacherId)
    {
        return teachers.FirstOrDefault(t => t.TeacherId == teacherId);
    }
    public Course FindCourseById(int courseId)
    {
        return courses.FirstOrDefault(c => c.CourseId == courseId);
    }


}

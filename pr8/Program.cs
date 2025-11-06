using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Маркетплейс GMWOG");

            while (true)
            {
                Console.WriteLine("\nГлавное меню:");
                Console.WriteLine("1 - Регистрация");
                Console.WriteLine("2 - Вход");
                Console.WriteLine("3 - Товары");
                Console.WriteLine("4 - Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Register(); break;
                    case "2": Login(); break;
                    case "3": ShowProducts(); break;
                    case "4": return;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }
        static void Register()
        {
            Console.WriteLine("\nРегистрация");

            Console.Write("Логин: ");
            string login = Console.ReadLine();
            if (Core.Context.Users.Any(u => u.Username == login))
            {
                Console.WriteLine("Этот логин уже занят!");
                return;
            }

            Console.Write("Email: ");
            string email = Console.ReadLine();

            string password;
            while (true)
            {
                Console.Write("Пароль: ");
                password = Console.ReadLine();

                Console.Write("Повторите пароль: ");
                string password2 = Console.ReadLine();

                if (password == password2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Пароли не совпадают! Попробуйте еще раз.");
                }
            }
            Users newUser = new Users
            {
                Username = login,
                Email = email,
                PasswordHash = password,
                PhoneNumber = ""
            };
            Core.Context.Users.Add(newUser);
            Core.Context.SaveChanges();

            Console.WriteLine("Регистрация успешна!");
        }
        static void Login()
        {
            Console.WriteLine("\nВход");

            Console.Write("Логин: ");
            string login = Console.ReadLine();

            Console.Write("Пароль: ");
            string password = Console.ReadLine();
        }
    }
}

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
    }
}

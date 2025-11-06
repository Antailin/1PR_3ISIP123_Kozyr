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
            Users user = Core.Context.Users.FirstOrDefault(u => u.Username == login);
            if (user != null && password == user.PasswordHash)
            {
                Console.WriteLine($"Добро пожаловать, {user.Username}!");
                UserMenu(user);
            }
            else
            {
                Console.WriteLine("Неверный логин или пароль!");
            }
        }
        static void UserMenu(Users user)
        {
            while (true) 
            {
                Console.WriteLine("\n--- Личный кабинет ---");
                Console.WriteLine("1 - Товары");
                Console.WriteLine("2 - Корзина");
                Console.WriteLine("3 - Мои заказы");
                Console.WriteLine("4 - Выйти");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ShowProducts(user); break;
                    case "2": ShowCart(user); break;      
                    case "3": ShowOrders(user); break;    
                    case "4": return;                    
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }
        static void ShowProducts(Users user = null)
        {
            Console.WriteLine("\nТовары");

            var products = Core.Context.Products.ToList();

            if (products.Count == 0)
            {
                Console.WriteLine("Товаров нет");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductId}. {product.ProductName} - {product.Price} руб. (осталось: {product.StockQuantity})");
            }

            if (user != null)
            {
                Console.Write("\n1 - Добавить в корзину\n2 - Купить сразу\n3 - Назад\nВаш выбор: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddToCart(user);
                }
                else if (choice == "2")
                {
                    BuyProduct(user);
                }
            }
        }
        static void AddToCart(Users user)
        {
            Console.Write("ID товара: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }

            Products product = Core.Context.Products.Find(productId);
            if (product == null)
            {
                Console.WriteLine("Товар не найден!");
                return;
            }

            Console.Write("Количество: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Неверное количество!");
                return;
            }

            if (quantity > product.StockQuantity)
            {
                Console.WriteLine("Недостаточно товара!");
                return;
            }
            Cart cartItem = Core.Context.Cart.FirstOrDefault(c => c.UserId == user.UserId && c.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new Cart
                {
                    UserId = user.UserId,
                    ProductId = productId,
                    Quantity = quantity
                };
                Core.Context.Cart.Add(cartItem);
            }

            Core.Context.SaveChanges();
            Console.WriteLine("Товар добавлен в корзину!");
        }
        static void BuyProduct(Users user)
        {
            Console.Write("ID товара: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }

            Products product = Core.Context.Products.Find(productId);
            if (product == null)
            {
                Console.WriteLine("Товар не найден!");
                return;
            }

            Console.Write("Количество: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Неверное количество!");
                return;
            }

            if (quantity > product.StockQuantity)
            {
                Console.WriteLine("Недостаточно товара!");
                return;
            }

            var points = Core.Context.PickupPoints.ToList();

            if (points.Count == 0)
            {
                Console.WriteLine("Нет пунктов выдачи!");
                return;
            }

            Console.WriteLine("Пункты выдачи:");
            foreach (var point in points)
            {
                Console.WriteLine($"{point.PickupPointId}. {point.PointName} - {point.Address}");
            }

            Console.Write("Выберите пункт выдачи: ");
            if (!int.TryParse(Console.ReadLine(), out int pointId))
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }

        }
    }
}

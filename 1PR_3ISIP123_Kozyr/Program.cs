using System.Diagnostics;

Console.WriteLine("Введите кол-во операций(2 - 40):");
int count;
int lop = 0;
double kef = 0;
count = Convert.ToInt32(Console.ReadLine());
string[] names = new string[count];
double[] prices = new double[count];
if (count < 2 || count > 40)
{
    Console.WriteLine("Error");
}
else
{
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine("Введите трату(Название услуги или товара; Количество денег):");
        string b = Console.ReadLine();
        string[] all = b.Split(new char[] { ';' });
        names[i] = all[0];
        prices[i] = Convert.ToDouble(all[1]);
    }
    Console.WriteLine("1. Вывод данных");
    Console.WriteLine("2. Статистика (среднее, максимальное, минимальное, сумма)");
    Console.WriteLine("3. Сортировка по цене (пузырьковая сортировка)");
    Console.WriteLine("4. Конвертация валюты (пользователь вводит курс или выбирает из списка)");
    Console.WriteLine("5. Поиск по названию");
    Console.WriteLine("0. Выход");
    int r = 1;
    string zov = "rub";
    r = Convert.ToInt32(Console.ReadLine());
    while (r != 0)
    {
        switch (r)
        {
            case 1:
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"{names[i]} - {prices[i]} {zov}");
                }
                Console.WriteLine("");
                break;
            case 2:
                double max = -999;
                double min = 999999999;
                double s = 0;
                for (int i = 0; i < count; i++)
                {
                    s = s + prices[i];
                    if (prices[i] < min)
                    {
                        min = prices[i];
                    }
                    if (prices[i] > max)
                    {
                        max = prices[i];
                    }
                }
                Console.WriteLine($"Мaксимальное - {max} {zov}, минимальное - {min} {zov}, среднее - {s / count} {zov}, сумма - {s} {zov}");
                Console.WriteLine("");
                break;
            case 3:
                double temp = 0;
                string temp2 = "";
                for (int write = 0; write < prices.Length; write++)
                {
                    for (int sort = 0; sort < prices.Length - 1; sort++)
                    {
                        if (prices[sort] > prices[sort + 1])
                        {
                            temp = prices[sort + 1];
                            prices[sort + 1] = prices[sort];
                            prices[sort] = temp;
                            temp2 = names[sort + 1];
                            names[sort + 1] = names[sort];
                            names[sort] = temp2;
                        }
                    }
                }
                Console.WriteLine("Сортировка по возростнаию:");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"{names[i]} - {prices[i]} {zov}");
                }
                Console.WriteLine("");
                break;
            case 4:
                Console.WriteLine("Выберите: Доллар - 1, Евро - 2, Рубль - 3, Своя валюта - 4");
                int z;
                z = Convert.ToInt32(Console.ReadLine());
                switch (z)
                {
                    case 1:
                        for (int i = 0; i < count; i++)
                        {
                            prices[i] = prices[i] * 0.011674;
                        }
                        zov = "usd";
                        Console.WriteLine("Успешно!");
                        Console.WriteLine("");
                        break;
                    case 2:
                        for (int i = 0; i < count; i++)
                        {
                            prices[i] = prices[i] * 0.010026;
                        }
                        zov = "eur";
                        Console.WriteLine("Успешно!");
                        Console.WriteLine("");
                        break;
                    case 3:
                        switch (zov)
                        {
                           case "rub":
                                break;
                           case "usd":
                                for (int i = 0; i < count; i++)
                                {
                                    prices[i] = prices[i] * 85.66;
                                }
                                break;
                            case "eur":
                                for (int i = 0; i < count; i++)
                                {
                                    prices[i] = prices[i] * 99.74;
                                }
                                break;

                        }
                        if (lop == 1)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                prices[i] = prices[i] / kef;
                            }
                            lop = lop - 1;
                        }
                        zov = "rub";
                        Console.WriteLine("Успешно!");
                        Console.WriteLine("");
                        break;
                        case 4:
                        lop = 1;
                        Console.WriteLine("Введите название валюты:");
                        zov = Console.ReadLine();
                        Console.WriteLine("Введите коэфицент к рублю:");
                        kef = Convert.ToDouble(Console.ReadLine());
                        for (int i = 0; i < count; i++)
                        {
                            prices[i] = prices[i] * kef;
                        }
                        Console.WriteLine("Успешно!");
                        Console.WriteLine("");
                        break;
                }
                break;
            case 5:
                int o = 0;
                Console.WriteLine("Введите данные для поиска: ");
                string l = Console.ReadLine();
                Console.WriteLine("Результаты поиска:");
                for (int i = 0; i < count; i++)
                {
                    bool res = names[i].Contains(l);
                    if (res == true)
                    {
                        Console.WriteLine($"{names[i]} - {prices[i]} {zov}");
                        o++;
                    }
                }
                if (o == 0) { Console.WriteLine("Ничего не найденно!"); }
                Console.WriteLine("");
                break;

        }
        Console.WriteLine("1. Вывод данных");
        Console.WriteLine("2. Статистика (среднее, максимальное, минимальное, сумма)");
        Console.WriteLine("3. Сортировка по цене (пузырьковая сортировка)");
        Console.WriteLine("4. Конвертация валюты (пользователь вводит курс или выбирает из списка)");
        Console.WriteLine("5. Поиск по названию");
        Console.WriteLine("0. Выход");
        r = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
    }
}
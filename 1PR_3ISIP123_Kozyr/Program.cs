Game game = new Game();
game.Start();
public class Item
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public Item(string name, int attack = 0, int defense = 0)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
    }
}
public class Weapon : Item
{
    public Weapon(string name, int attack) : base(name, attack, 0) { }
}

public class Armor : Item
{
    public Armor(string name, int defense) : base(name, 0, defense) { }
}
public class Enemy
{
    public string Name { get; set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public double CritChance { get; set; }
    public double FreezeChance { get; set; }
    public bool IgnoreDefense { get; set; }

    public Enemy(string name, int hp, int attack, int defense, double critChance = 0, double freezeChance = 0, bool ignoreDefense = false)
    {
        Name = name;
        MaxHP = hp;
        HP = hp;
        Attack = attack;
        Defense = defense;
        CritChance = critChance;
        FreezeChance = freezeChance;
        IgnoreDefense = ignoreDefense;
    }
    public bool IsAlive() => HP > 0;
}
public class Player
{
    public int MaxHP { get; set; } = 100;
    public int HP { get; set; } = 100;
    public Weapon Weapon { get; set; }
    public Armor Armor { get; set; }
    public bool IsFrozen { get; set; } = false;
    public Player()
    {
        Weapon = new Weapon("Кулаки", 5);
        Armor = new Armor("Простая одежда", 2);
    }
    public int GetAttack() => Weapon.Attack;
    public int GetDefense() => Armor.Defense;
    public bool IsAlive() => HP > 0;
    public void Heal() => HP = MaxHP;
}
public class Game
{
    private Player player;
    private Random random;
    private int turnCount;

    private readonly List<Enemy> normalEnemies;
    private readonly List<Enemy> bosses;

    public Game()
    {
        player = new Player();
        random = new Random();
        turnCount = 0;

        normalEnemies = new List<Enemy>
            {
                new Enemy("Гоблин", 30, 8, 3, critChance: 0.2),
                new Enemy("Скелет", 25, 10, 2, ignoreDefense: true),
                new Enemy("Маг", 20, 12, 1, freezeChance: 0.25)
            };

        bosses = new List<Enemy>
            {
                new Enemy("ВВГ (Гоблин)", 60, 12, 4, critChance: 0.3),
                new Enemy("Ковальский (Скелет)", 63, 13, 3, ignoreDefense: true),
                new Enemy("Архимаг C++", 36, 19, 1, freezeChance: 0.35),
                new Enemy("Пестов С--", 33, 18, 1, ignoreDefense: true, freezeChance: 0.4)
            };
    }
    public void Start()
    {
        Console.WriteLine("ТЕКСТОВЫЙ РОГАЛИК");
        Console.WriteLine("Добро пожаловать в игру!");
        Console.WriteLine("Каждый ход вас ждет либо сундук, либо враг.");
        Console.WriteLine("Каждые 10 ходов - встреча с боссом!\n");

        while (player.IsAlive())
        {
            turnCount++;
            Console.WriteLine($"\nХод {turnCount}");
            Console.WriteLine($"Здоровье: {player.HP}/{player.MaxHP}");
            Console.WriteLine($"Оружие: {player.Weapon.Name} (Атака: {player.Weapon.Attack})");
            Console.WriteLine($"Броня: {player.Armor.Name} (Защита: {player.Armor.Defense})");

            if (player.IsFrozen)
            {
                Console.WriteLine("Вы заморожены и пропускаете ход!");
                player.IsFrozen = false;
                continue;
            }
            if (turnCount % 10 == 0)
            {
                Console.WriteLine("\n!!! ПОЯВИЛСЯ БОСС !!!");
                Enemy boss = bosses[random.Next(bosses.Count)];
                Fight(boss);
            }
            else
            {
                if (random.Next(2) == 0)
                {
                    FightEnemy();
                }
                else
                {
                    OpenChest();
                }
            }
            if (!player.IsAlive())
            {
                Console.WriteLine("\nВЫ ПОГИБЛИ");
                Console.WriteLine($"Вы продержались {turnCount} ходов");
                break;
            }

        }
    }
    private void FightEnemy()
    {
        Enemy enemy = normalEnemies[random.Next(normalEnemies.Count)];
        Fight(enemy);
    }

    private void Fight(Enemy enemy)
    {
        Console.WriteLine($"\nПеред вами: {enemy.Name}");
        Console.WriteLine($"HP: {enemy.HP}, Атака: {enemy.Attack}, Защита: {enemy.Defense}");

        while (enemy.IsAlive() && player.IsAlive())
        {
            Console.WriteLine("\nВаш ход:");
            Console.WriteLine("1 - Атака");
            Console.WriteLine("2 - Защита");

            int choice = GetChoice(1, 2);
            bool defended = false;

            if (choice == 2)
            {
                defended = true;
                Console.WriteLine("Вы готовитесь к защите...");
            }
            else
            {
                int playerDamage = player.GetAttack();
                enemy.HP -= playerDamage;
                Console.WriteLine($"Вы нанесли {playerDamage} урона!");
                Console.WriteLine($"У {enemy.Name} осталось {Math.Max(0, enemy.HP)} HP");
            }

            if (!enemy.IsAlive()) break;
            Console.WriteLine($"\nХод {enemy.Name}:");

            if (defended && random.NextDouble() < 0.4)
            {
                Console.WriteLine("Вы успешно уклонились от атаки!");
                continue;
            }

            int enemyDamage = enemy.Attack;
            if (random.NextDouble() < enemy.CritChance)
            {
                enemyDamage = (int)(enemyDamage * 1.5);
                Console.WriteLine("Критический удар!");
            }
            if (random.NextDouble() < enemy.FreezeChance)
            {
                player.IsFrozen = true;
                Console.WriteLine("Вас заморозили! Вы пропустите следующий ход.");
            }
            int finalDamage;
            if (enemy.IgnoreDefense)
            {
                finalDamage = enemyDamage;
                Console.WriteLine("Враг игнорирует вашу защиту!");
            }
            else
            {
                if (defended)
                {
                    double blockPercent = 0.7 + random.NextDouble() * 0.3;
                    int blockedDamage = (int)(player.GetDefense() * blockPercent);
                    finalDamage = Math.Max(0, enemyDamage - blockedDamage);
                    Console.WriteLine($"Вы заблокировали {blockedDamage} урона");
                }
                else
                {
                    finalDamage = Math.Max(0, enemyDamage - player.GetDefense());
                }
            }

            player.HP -= finalDamage;
            Console.WriteLine($"Вам нанесли {finalDamage} урона!");
            Console.WriteLine($"У вас осталось {Math.Max(0, player.HP)} HP");
        }

        if (!enemy.IsAlive())
        {
            Console.WriteLine($"\nВы победили {enemy.Name}!");
        }
    }
    private void OpenChest()
    {
        Console.WriteLine("\nВы нашли сундук!");
        int chestType = random.Next(3);

        switch (chestType)
        {
            case 0:
                Console.WriteLine("В сундуке лечебное зелье!");
                player.Heal();
                Console.WriteLine("Ваше здоровье полностью восстановлено!");
                break;

            case 1:
                Weapon newWeapon = GenerateWeapon();
                Console.WriteLine($"В сундуке оружие: {newWeapon.Name} (Атака: {newWeapon.Attack})");
                Console.WriteLine($"Ваше текущее оружие: {player.Weapon.Name} (Атака: {player.Weapon.Attack})");
                Console.WriteLine("Взять новое оружие? (1 - да, 2 - нет)");

                if (GetChoice(1, 2) == 1)
                {
                    player.Weapon = newWeapon;
                    Console.WriteLine("Вы экипировали новое оружие!");
                }
                break;

            case 2:
                Armor newArmor = GenerateArmor();
                Console.WriteLine($"В сундуке броня: {newArmor.Name} (Защита: {newArmor.Defense})");
                Console.WriteLine($"Ваша текущая броня: {player.Armor.Name} (Защита: {player.Armor.Defense})");
                Console.WriteLine("Взять новую броню? (1 - да, 2 - нет)");

                if (GetChoice(1, 2) == 1)
                {
                    player.Armor = newArmor;
                    Console.WriteLine("Вы экипировали новую броню!");
                }
                break;
        }
    }
    private Weapon GenerateWeapon()
    {
        var weapons = new[]
        {
                new Weapon("Кинжал", 8),
                new Weapon("Меч", 12),
                new Weapon("Топор", 15),
                new Weapon("Посох", 10),
                new Weapon("Двуручный меч", 18)
            };
        return weapons[random.Next(weapons.Length)];
    }

    private Armor GenerateArmor()
    {
        var armors = new[]
        {
                new Armor("Кожаная броня", 5),
                new Armor("Кольчуга", 8),
                new Armor("Латы", 12),
                new Armor("Мантию мага", 6),
                new Armor("Доспех воина", 10)
            };
        return armors[random.Next(armors.Length)];
    }
    private int GetChoice(int min, int max)
    {
        while (true)
        {
            Console.Write($"Выберите действие ({min}-{max}): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
            {
                return choice;
            }
            Console.WriteLine("Неверный ввод!");    
        }
    }
}

    
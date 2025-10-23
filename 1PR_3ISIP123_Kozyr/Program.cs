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
}
    
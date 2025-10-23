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
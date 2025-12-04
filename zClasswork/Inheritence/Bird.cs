namespace CompSci.zClasswork.Inheritence;

public class Bird : Animal, IEggLayer
{
    public Bird(string name, int age) : base(name, age){}

    public override void Speak()
    {
        Console.WriteLine("Tweet!");
    }

    public void LayEgg()
    {
        Console.WriteLine($"{Name} just laid an egg!");
    }
}

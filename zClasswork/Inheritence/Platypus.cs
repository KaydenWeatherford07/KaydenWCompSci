namespace CompSci.zClasswork.Inheritence;

public sealed class Platypus : Monotreme
{
    public Platypus(string name, int age) : base(name, age, "Brown") { }

    public override void Speak()
    {
        Console.WriteLine("Quack?");
    }
}
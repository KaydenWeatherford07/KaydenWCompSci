namespace Inheritence;

public sealed class Cat : Animal
{
    public Cat(string name, int age) : base(name, age)
    {
        
    }

    public override void Speak()
    {
        Console.WriteLine($"{name} Meowed!");
    }

    public override void Bathtime()
    {
        Console.WriteLine($"{name} refused to take a bath. It doesnt like water.");
    }
}
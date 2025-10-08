namespace Inheritence;

public class Cat : Animal
{
    public Cat(string name, int age) : base(name, age)
    {
        
    }

    public override void Speak()
    {
        Console.WriteLine($"{name} Meowed!");
    }
}
namespace CompSci.zClasswork.Inheritence;

public sealed class Cat : Mammal
{
    public Cat(string name, int age, string furColor) : base(name, age, furColor)
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
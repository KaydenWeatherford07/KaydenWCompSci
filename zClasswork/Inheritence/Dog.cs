namespace Inheritence;


public class Dog : Animal
{
    public Dog(string name, int age) : base(name, age) {}

    public void PlayFetch()
    {
        Console.WriteLine($"Played fetch with {name}");
    }

    public override void Speak()
    {
        Console.WriteLine($"{name} Barked!");
    }
}
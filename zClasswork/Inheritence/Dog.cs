namespace CompSci.zClasswork.Inheritence;


public class Dog : Mammal
{
    public Dog(string name, int age, string furColor) : base(name, age, furColor)
    {
        
    }

    public void PlayFetch()
    {
        Console.WriteLine($"Played fetch with {name}");
    }

    public override void Speak()
    {
        Console.WriteLine($"{name} Barked!");
    }
}
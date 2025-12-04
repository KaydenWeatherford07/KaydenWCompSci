namespace CompSci.zClasswork.Inheritence;

public abstract class Monotreme : Mammal, IEggLayer
{
    public Monotreme(string name, int age, string furColor) : base(name, age, furColor)
    {
        
    }

    public void LayEgg()
    {
        Console.WriteLine($"{Name}, despite being a mammal, just laid an egg!");
    }
}
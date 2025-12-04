namespace CompSci.zClasswork.Inheritence;

public abstract class Mammal : Animal
{
    public Mammal(string name, int age, string furColor) : base(name, age)
    {
        if (string.IsNullOrEmpty(furColor))
        {
            throw new ArgumentException("FurColor cannot be null or empty");
        }
        FurColor = furColor;
    }

    public string FurColor
    {
        get;
    }
}
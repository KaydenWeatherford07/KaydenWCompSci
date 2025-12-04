namespace CompSci.zClasswork.Inheritence;

public abstract class Animal
{
    protected string name;
    protected int age;

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public sealed override string ToString()
    {
        return $"{Name} is {Age} years old";
    }
    
    public String Name
    {
        get => name; 
        set
        { 
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or white space.");
            }
            name = value;
        }
    }

    public int Age
    {
        get => age; 
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }
            age = value;
        }
    }

    public abstract void Speak();

    public virtual void Bathtime()
    {
        Console.WriteLine($"{name} took a bath,");
    }

}

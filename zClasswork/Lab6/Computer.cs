namespace CompSci.zClasswork.Lab6;

public abstract class Computer : item
{
    public Computer(double price, string model, string manufacturer, int storage) : base(price, model, manufacturer)
    {
        if (storage < 0)
        {
            throw new ArgumentException("Storage cannot be negative");
        }
        Storage = storage;
    }
    
    public int Storage { get; }

    public override string ToString()
    {
        return $"The {Manufacturer} {Model} ({Price:C2}) has {Storage} GB of storage";
    }
}
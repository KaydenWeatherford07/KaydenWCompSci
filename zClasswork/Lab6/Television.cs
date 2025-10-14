namespace Lab6;

public class Television : item
{
    public Television(double price, string model, string manufacturer, int size) : base(price, model, manufacturer)
    {
        if (size < 0)
        {
            throw new ArgumentException("Size cannot be negative");
        }
        Size = size;
    }
    
    public int Size { get; }

    public override string ToString()
    {
       return $"The {Manufacturer} {Model} ({Price:C2}) is {Size}\"";
    }
}
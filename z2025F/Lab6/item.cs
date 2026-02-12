namespace Lab6;

public abstract class item
{
    private double price;
    
    public item(double price, string model, string manufacturer)
    {
        if (price < 0)
        {
            throw new ArgumentException("Price must be greater than or equal to 0");
        }
        Price = price;
        if (string.IsNullOrEmpty(model))
        {
            throw new ArgumentException("Model cannot be null or empty");
        }
        Model = model;

        if (string.IsNullOrEmpty(manufacturer))
        {
            throw new ArgumentException("Manufacturer cannot be null or empty");
        }
        Manufacturer = manufacturer;
    }

    public double Price
    {
        get { return price; }
        set {
            if (value < 0)
            {
                throw new ArgumentException("Price cant be negative");
            }
            price = value;
        }
    }
    public string Model { get; }
    public string Manufacturer { get; }
    
    public abstract override string ToString();
}
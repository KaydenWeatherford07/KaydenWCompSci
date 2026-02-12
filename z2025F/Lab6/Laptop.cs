namespace Lab6;

public class Laptop: Computer
{
    public Laptop(double price, string model, string manufacturer, int storage, int batteryLifeTime) : base(price, model, manufacturer, storage)
    {
        if (batteryLifeTime <= 0)
        {
            throw new ArgumentException("Battery lifetime must be greater than zero");
        }
        BatteryLifeTime =  batteryLifeTime;
    }
    
    public int BatteryLifeTime { get; }

    public override string ToString()
    {
        return $"The {Manufacturer} {Model} laptop ({Price:C2}) has {Storage} GB of storage and {BatteryLifeTime} hours of battery life";
    }
}

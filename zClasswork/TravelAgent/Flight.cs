public class Flight
{
    private double price;
    
    public Flight(int fliNum, string dep, string arr, double price)
    {
        if (fliNum < 1000 || fliNum > 9999)
        {
            throw new ArgumentException("Flight number must be between 1000 and 9999.");
        }
        FlightNumber = fliNum;

        if (dep == null || dep.Length == 0)
        {
            throw new ArgumentException("Departure city cannot be null or empty.");
        }
        Departure = dep;

        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentException("Arrival city cannot be null or empty.");
        }
        Arrival = arr;
        
        Price = price;
    }

    public int FlightNumber
    {
        get;
    }
    public string Departure
    {
        get;
    }
    public string Arrival
    {
        get;
    }
    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0 || value > 9999.99)
            {
                throw new ArgumentException("Price must be between 0 and 9999.99");
            }
            price = value;
        }
    }

    public override string ToString()
    {
        return $"Flight #{FlightNumber} from {Departure} to {Arrival} ({Price:C2})";
    }
    
}   
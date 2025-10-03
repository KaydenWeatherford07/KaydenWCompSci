namespace KaydenWCompSci;

public class Theater
{
    private double price;
    
    public Theater(int numSeats)
    {
 
        if (numSeats < 0)
        {
            throw new Exception("Seats cannot be negative");
        }
        NumSeats = numSeats;
    }

    public Movie CurrentlyShowing
    {
        get;
        set;
    }

    public double Price
    {
        get
        {
            return price;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("Price cannot be negative");
            }
            price = value;
        }
    }

    public int NumSeats { get; }

    public override string ToString()
    {
        return $"{NumSeats} seats available to see {CurrentlyShowing} for ${Price:F2}";
    }

}

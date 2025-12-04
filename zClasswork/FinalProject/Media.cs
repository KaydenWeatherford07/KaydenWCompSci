namespace CompSci.zClasswork.FinalProject;

public abstract class Media
{
    private string title;
    private string creator;
    private int year;
    private int duration;
        
    public Media(string title, string creator, int year, int duration)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException("title");
        Title = title;
        
        if (string.IsNullOrEmpty(creator))
            throw new ArgumentNullException("creator");
        Creator = creator;
        
        if (year > 2025)
            throw new ArgumentOutOfRangeException("year", "Year must be 2025 or earlier.");
        Year = year;
        
        if (duration < 1)
            throw new ArgumentOutOfRangeException("duration", "Duration must be greater than 0.");
        Duration = duration;
    }
    
    public string Title
    {
        get;
    }
    public string Creator
    {
        get;
    }
    public int Year
    {
        get;
    }
    public int Duration
    {
        get;
    }

    public abstract double NormalizedRating { get; }

}

    // Thank god for generics
public abstract class Media<T> : Media where T : IRating
{
    public Media(string title, string creator, int year, int duration, T rating)
        : base(title, creator, year, duration)
    {
        rating.ValidateRating();
        Rating = rating;
    }

    public T Rating { get; }
    public override double NormalizedRating => Rating.Rating;
}

public readonly struct IntRating : IRating
{
    public IntRating(int rating)
    {
        if (rating < 0 || rating > 10)
            throw new ArgumentException("Rating must be between 0 and 10");
        Value = rating;
    }
    public int Value { get; }
    public void ValidateRating() {}
    public double Rating => Value / 10.0;
}

public readonly struct BoolRating : IRating
{
    public BoolRating(bool rating)
    {
        Value = rating;
    }
    public bool Value {get;}
    public void ValidateRating() { }
    public double Rating => Value? 1.0 : 0;
}

public readonly struct DoubleRating : IRating
{
    public DoubleRating(double rating)
    {
        if (rating < 0 || rating > 5.0)
        {
            throw new ArgumentException("Rating must be between 0 and 5");
        }
        
        Value = rating;
    }
    public double Value {get;}
    public void ValidateRating(){}
    public double Rating => Value / 5.0;
}
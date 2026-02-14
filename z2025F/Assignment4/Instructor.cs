namespace CompSci.zClasswork.Assignment4;

public class Instructor : Person, IEmployee
{
    private double _salary;
    
    public Instructor(string firstName, string lastName, int id, string department, double salary) : base(firstName, lastName, id)
    {
        if (salary < 0)
        {
            throw new ArgumentException("Salary cannot be negative");
        }
        _salary = salary;
        Department = department;
    }
    
    public string Department { get; set;}

    public double Salary
    {
        get => _salary;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }
            _salary = value;
        }
    }

    public override string ToString()
    {
        return $"Prof. {LastName} ({ID}) [Dept. of {Department}] ({Salary:C2})" ;
    }
}
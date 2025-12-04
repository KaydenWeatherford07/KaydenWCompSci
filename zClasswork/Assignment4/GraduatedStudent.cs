namespace CompSci.zClasswork.Assignment4;

public class GraduatedStudent : Student, IEmployee
{
    private double _salary;
    
    public GraduatedStudent(string firstName, string lastName, int id, string major, string minor, double gpa, double salary) : base(firstName, lastName, id, major, minor, gpa)
    {
        if (salary < 0)
        {
            throw new ArgumentException("Salary cannot be negative");
        }
        _salary = salary;
    }
    
    public override string ToString()
    {
        return $"{LastName}, {FirstName} ({ID}) [{Major} Major / {Minor} Minor] GPA: {GPA:F3} ({Salary:C2})";
    }

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
}
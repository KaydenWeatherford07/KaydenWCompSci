namespace CompSci.zClasswork.Assignment4;

public class Student : Person
{
    public Student(string firstName, string lastName, int id, string major, string minor, double gpa) : base(firstName, lastName, id)
    {
        Major = major;
        Minor = minor;
        if (gpa < 0 || gpa > 4)
            throw new ArgumentException("GPA should be between 0 and 4");
        GPA = gpa;
    }

    public string Major { get; set; }
    public string Minor { get; set; }
    public double GPA { get; set; }

    public override string ToString()
    {
        return $"{LastName}, {FirstName} ({ID}) [{Major} Major / {Minor} Minor] GPA: {GPA:F3}";
    }
}
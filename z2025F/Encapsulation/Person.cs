namespace CompSci.zClasswork.Lecture_2;

class Person
{
    private string name;
    private int id;
    private double salary;
    public Person(string name, int id,  double salary)
    {
        Name = name;
        if (id < 1_000_000 || id > 9_999_999)
        {
            throw new ArgumentOutOfRangeException();
        }
        Id = id;
        Salary = salary;
    }

    public string Name
    {
        get => name;
        set
        {
            if (value == null && value.Length == 0 )
            {
                throw new ArgumentException("Name cannot be empty or Null!");
            }
            name = value;
        }
}
    public int Id
    {
        get;
    }
    public double Salary
    {
        get => salary;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Salary cannot be negative!");
            }
            salary = value;
        }
    }
    public override string ToString()
    {
        return $"\nName: \t\t {name} \nID: \t\t {Id} \nSalary: \t {salary:C2}";
    }
}
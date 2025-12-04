namespace CompSci.zClasswork.Assignment4;

public class University
{
    public static void Main()
    {
        Person[] myUniversity = [
            new Instructor("Brian", "Merriso", 4206900, "Computer Science", 80000.50),
            new Instructor("Daniel", "Szelogowski", 4206901, "Computer Science", 80001.50),
            new Instructor("Jesus", "Christ", 1000000, "Religious Studies", 1225000.00),
            new GraduatedStudent("John", "Doe", 1000001, "Religious Studies", "Christianity", 3.99, 30000.00),
            new GraduatedStudent("Greg", "Barhbehchue", 1000005, "Culinary Arts", "Grilling", 2.33, 45000.00),
            new GraduatedStudent("Sidorovich", "Thoaghtrader", 1000995, "Business", "Robbing People", 3.1, 91000.00),
            new Student("Kayden", "Weatherford", 2107925, "Computer Science", "IT", 3.0),
            new Student("Yevhen", "Martynenko", 2912056, "Philosophy", "Hmmmm", 2.5),
            new Student("Alexey", "Pajitnov", 4444444, "Computer Science", "Game Design", 3.9)
        ];


        for (int i = 0; i < myUniversity.Length; i++)
        {
            Console.WriteLine(myUniversity[i]);
        }
        
        Console.WriteLine("\n\n\n\n");

        for (int i = 0; i < myUniversity.Length; i++)
        {
            if (myUniversity[i] is GraduatedStudent)
            {
                Console.WriteLine(myUniversity[i]);
            }
        }
        
        Console.WriteLine("\n");

        int cnt = 0;
        double gpaTotal = 0;
        for (int i = 0; i < myUniversity.Length; i++)
        {
            if (myUniversity[i] is Student s)
            {
                cnt++;
                gpaTotal += s.GPA;
            }
        }
        
        Console.WriteLine($"Out of {cnt} students, Average GPA is: {gpaTotal/cnt:F3}");
        
        double hSalary = 0;
        int hSalIndex = 0;
        double lSalary = Double.MaxValue;
        int lSalIndex = 0;
        for (int i = 0; i < myUniversity.Length; i++)
        {
            if (myUniversity[i] is IEmployee e)
            {
                if (e.Salary > hSalary)
                {
                    hSalary = e.Salary;
                    hSalIndex = i;
                }
                else if (e.Salary < lSalary)
                {
                    lSalary = e.Salary;
                    lSalIndex = i;
                }
            }
        }
        
        Console.WriteLine($"\nThe highest paid employee is: {myUniversity[hSalIndex]}");
        Console.WriteLine($"The lowest paid employee is: {myUniversity[lSalIndex]}");
    }
}
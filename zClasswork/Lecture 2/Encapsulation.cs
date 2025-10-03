namespace Lecture_2;

public class Encapsulation
{
    private static void Main()
    {
        var name = "Bob";
        var id = 2107925;
        var salary = 55000.00;

        var bob = new Person(name, id, salary);

        Console.WriteLine(bob);
    }
}
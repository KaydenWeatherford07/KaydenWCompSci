namespace CompSci.zClasswork.Lecture_2;
internal class IntroOrientedPro
{
    private static void Main()
    {   
        string[] names =    ["Bob", "Alice"];
        int[] ids =         [1944485, 1847729];
        double[] salaries = [40000, 55000];
        
        Person[] people = new Person[2];
        for (int i = 0; i < people.Length; i++)
        {
            people[i] = new Person(names[i], ids[i], salaries[i]);
        }

        for (int i = 0; i < people.Length; i++)
        {
            people[i].DispPerson();
        }
        
        GiveRaise(people[1]);
    }

    private static void GiveRaise(Person p)
    {
        p.Salary = p.Salary * 1.1;
        p.DispPerson();
    }
}
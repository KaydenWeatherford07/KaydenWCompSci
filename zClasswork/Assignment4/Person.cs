namespace CompSci.zClasswork.Assignment4;

public abstract class Person
{
    public Person(string firstName, string lastName, int id)
    {
        FirstName = firstName;
        LastName = lastName;
        if (id < 1_000_000 || id > 9_999_999)
            throw new ArgumentException("ID has to be 7 digits long between 1,000,000 and 9,999,999");
        ID = id;
    }
    
    public string FirstName { get;}
    public string LastName { get;}
    public int ID { get;}
}
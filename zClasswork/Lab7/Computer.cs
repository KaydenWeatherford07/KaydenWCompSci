namespace CompSci.zClasswork.Lab7;

public class Computer : IEmailReceiver
{
    public Computer(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Invalid name loser");
        }
        Name = name;
    }

    public string Name
    {
        get;
        set; //You can change the name of a putr in settings
    }

    public void ReceiveEmail(string sender, string subject)
    {
        Console.WriteLine($"*chime* from: {sender} subject: {subject}");
    }
}
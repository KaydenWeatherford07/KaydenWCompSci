namespace CompSci.zClasswork.Lab7;

public sealed class Smartphone : Phone,IEmailReceiver, ITextReceiver
{
    public Smartphone(string number) : base(number)
    {

    }

    public void ReceiveText(string message)
    {
        Console.WriteLine($"*ping* new text message");
    }

    public void ReceiveEmail(string sender, string subject)
    {
        Console.WriteLine($"*ping* new email from {sender}");
    }
}
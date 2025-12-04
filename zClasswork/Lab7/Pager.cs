namespace CompSci.zClasswork.Lab7;

public class Pager: ITextReceiver
{
    public Pager(int id)
    {
        if (id <= 0 || id > 9999)
        {
            throw new ArgumentException("id must be between 0 and 9999 loser.");
        }
        ID = id;
    }    
    
    public int ID { get; }

    public void ReceiveText(string message)
    {
        Console.WriteLine($"*buzz* {message}");
    }
}
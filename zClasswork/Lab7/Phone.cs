namespace CompSci.zClasswork.Lab7;

public class Phone : ICallReceiver
{
    public Phone(string number)
    {
        if (number == null || String.IsNullOrEmpty(number))
        {
            throw new ArgumentException("Phone number cannot be null or empty loser.");
        }
        else if (number.Length != 10)
        {
            throw new ArgumentException("Phone number must have exactly 10 numbers loser.");
        }
        Number = number;
    }

    public string Number
    {
        get;
    }

    public void ReceiveCall(string callerNumber)
    {
        Console.WriteLine($"*ring* {Number} is reciving a call from {callerNumber}");
    }
}
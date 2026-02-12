namespace Lab7;

public interface IEmailReceiver
{
    void ReceiveEmail(string sender, string subject);
}
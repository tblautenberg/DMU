public class Message
{
    private string to;
    private string message;

    public Message(string to, string message)
    {
        this.to = to;
        this.message = message;
    }

    public bool IsTo(string userName)
    {
        return to.Equals(userName, StringComparison.OrdinalIgnoreCase);
    }

    public string GetMessage()
    {
        return message;
    }
}

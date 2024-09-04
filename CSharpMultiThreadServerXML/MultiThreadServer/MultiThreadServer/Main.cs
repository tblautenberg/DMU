public class Program
{
    public static void Main(string[] args) // Starter programmet
    {
        ClientManager manager = new ClientManager(6010);
        manager.Run();
    }
}

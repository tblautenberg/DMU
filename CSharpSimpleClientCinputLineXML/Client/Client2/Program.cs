using Client2;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

public class Client
{
    private string host;
    private int port;

    public Client(string host, int port)
    {
        this.host = host;
        this.port = port;
    }

    public void Run()
    {
        try
        {
            using (TcpClient connection = new TcpClient(host, port))
            using (StreamWriter writer = new StreamWriter(connection.GetStream()))
            using (StreamReader reader = new StreamReader(connection.GetStream()))
            {
                Console.WriteLine("[Client] Connected to " + host + ":" + port);

                string inputLine;

                // Uendeligt loop der stoper ved EXIT
                while (true)
                {
                    // XML SENDER STUFF

                    Console.WriteLine("Write a name and age (name age)");
                    string line = Console.ReadLine();


                    string[] parts = line.Split(' ', 2);
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    Person person = new Person(name, age);
                    SendLine(writer, "XML " + person.ToXML());
                }
            }
        }
        catch (IOException e)
        {
            Console.Error.WriteLine("[Client] Connection failed: " + e.Message);
        }
    }

    private void SendLine(StreamWriter writer, string line)
    {
        Console.WriteLine("[Client] Sending line: " + line);
        writer.WriteLine(line);
        writer.Flush();
    }

    public static void Main(string[] args)
    {
        Client client = new Client("127.0.0.1", 6010);
        client.Run();
    }


}

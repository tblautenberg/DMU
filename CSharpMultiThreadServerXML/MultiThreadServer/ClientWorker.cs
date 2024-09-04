using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class ClientWorker
{
    private static int IDcounter;
    private int WorkerID;
    private TcpClient connection;
    private ClientManager manager;
    private string userName;

    public ClientWorker(ClientManager manager, TcpClient connection)
    {
        this.manager = manager;
        this.connection = connection;
        this.WorkerID = Interlocked.Increment(ref IDcounter); // ChatGPT max - kan man gøre dette smartere? Virker fint i Java ved bare at "this.workerID = ++workderID" - Spørg lige Flemming
    }

    public void Run()
    {
        Console.WriteLine("[ClientWorker #" + WorkerID + "] New connection from: " + ((IPEndPoint)connection.Client.RemoteEndPoint).Address.ToString()); // ChatGPT max

        // Stream (næsten som i java) til to-vejs kommunikation
        try
        {
            using (StreamReader reader = new StreamReader(connection.GetStream()))
            using (StreamWriter writer = new StreamWriter(connection.GetStream()))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("[ClientWorker #" + WorkerID + "] Server logged message: " + line);

                    if (line.StartsWith("LOGIN "))
                    {
                        userName = line.Substring(6).Trim(); // Hvis den modtagende string starter med "LOGOUT" så trim de første 6 (altså slet dem), og gem resten som username
                        SendLine(writer, "Logged in as " + userName);
                    }
                    else if (line.StartsWith("LOGOUT"))
                    {
                        SendLine(writer, "Logged out"); // Slutter loopet - måske den også skal lukke tråden? Det kigger jeg lige på senere
                        break;
                    }
                    else if (line.StartsWith("MESSAGE "))
                    {
                        string[] parts = line.Split(' ', 3);
                        if (parts.Length >= 3)
                        {                                // <MESSAGE> (part 0)
                            string recipient = parts[1]; // Brugernavn (part 1)
                            string message = parts[2];   // Password (part 2)
                            manager.StoreMessage(recipient, message);
                            SendLine(writer, "Message sent to " + recipient);
                        }
                        else
                        {
                            SendLine(writer, "Broken MESSAGE command"); // Fejlkode hvis MESSAGE ikke indeholder 3 splits
                        }
                    }
                    else if (line.StartsWith("GET")) // Henter den seneste besked fra brugeren der bliver kaldt efter en GET commando
                    {
                        string retrievedMessage = manager.GetMessage(userName);

                        if (retrievedMessage != null)
                        {
                            SendLine(writer, retrievedMessage);
                        }
                        else
                        {
                            SendLine(writer, "No messages");
                        }
                    }
                    else
                    {
                        SendLine(writer, "Received: " + line);
                    }

                    /*
                    if (line.Equals(":-)"))
                    {
                        manager.Shutdown();
                    }
                    */
                }
            }
        }
        catch (IOException e)
        {
            Console.Error.WriteLine("[ClientWorker #" + WorkerID + "] I/O error: " + e.Message);
        }
        finally
        {
            try
            {
                connection.Close();
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("[ClientWorker #" + WorkerID + "] Error when trying to close connection: " + e.Message);
            }
            Console.WriteLine("[ClientWorker #" + WorkerID + "] Connection closed");
        }
    }

    private void SendLine(StreamWriter writer, string line)
    {
        writer.WriteLine(line);
        writer.Flush();
    }
}

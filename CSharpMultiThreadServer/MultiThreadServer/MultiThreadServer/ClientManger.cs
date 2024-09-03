using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class ClientManager
{
    private List<ClientWorker> workers = new List<ClientWorker>();
    private List<Message> messages = new List<Message>();
    private int port;
    private bool stop = false;

    public ClientManager(int port)
    {
        this.port = port;
    }

    public void Run()
    {
        TcpListener serverSocket = null;
        try
        {
            serverSocket = new TcpListener(IPAddress.Any, port);
            serverSocket.Start();
            Console.WriteLine("[ClientManager] Server online");

            while (!stop)
            {
                try
                {
                    if (serverSocket.Pending())
                    {
                        TcpClient connection = serverSocket.AcceptTcpClient();
                        ClientWorker worker = new ClientWorker(this, connection);
                        workers.Add(worker);

                        // Starter ClientWorker på en ny tråd
                        Task.Run(() => worker.Run());
                    }
                    else
                    {
                        Thread.Sleep(100); // Laver en lille timeout
                    }
                }
                catch (SocketException e)
                {
                    Console.Error.WriteLine("[ClientManager] Socket error: " + e.Message);
                }
            }

            Console.WriteLine("[ClientManager] Server offline");
        }
        catch (IOException e)
        {
            Console.Error.WriteLine("[ClientManager] I/O error: " + e.Message);
        }
        finally
        {
            if (serverSocket != null)
            {
                serverSocket.Stop();
            }
        }
    }

    public void StoreMessage(string to, string message)
    {
        lock (messages)
        {
            messages.Add(new Message(to, message));
        }
    }

    public string GetMessage(string userName)
    {
        lock (messages)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                if (messages[i].IsTo(userName))
                {
                    string message = messages[i].GetMessage();
                    messages.RemoveAt(i);
                    return message;
                }
            }
        }
        return null;
    }
}

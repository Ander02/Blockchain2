using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Peer
{
    public class Server
    {
        private readonly TcpListener listener;

        public Server(IPAddress address, int port)
        {
            listener = new TcpListener(address, port);
            listener.Start();
        }

        public async Task Start(Action<object> OnReceiveHandle)
        {
            try
            {
                bool isRunning = true;
                while (isRunning)
                {
                    var client = await listener.AcceptTcpClientAsync();

                    var thread = new Thread(new ParameterizedThreadStart(OnReceiveHandle));
                    thread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Received exception {ex}");
            }
        }
    }
}

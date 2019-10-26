using Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Peer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var tasks = new List<Task>();
            foreach (var (ip, port) in Constants.Peers)
            {
                var task = Task.Run(async () =>
               {
                   var server = new Server(IPAddress.Parse(ip), port);

                   await server.Start((object clientObj) =>
                   {
                       var client = clientObj as TcpClient;

                       var stream = client.GetStream();

                       byte[] buffer = new byte[client.ReceiveBufferSize];

                       int i;
                       while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
                       {
                           var message = Encoding.UTF8.GetString(buffer).Replace("\0", "");

                           Console.WriteLine($"Received Message: {message} from {ip}:{port}");
                           var responseBytes = Encoding.UTF8.GetBytes("Received");
                           stream.Write(responseBytes, 0, responseBytes.Length);
                       }
                   });
               });
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}

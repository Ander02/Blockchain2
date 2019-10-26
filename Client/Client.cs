using System;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class Client
    {
        private readonly TcpClient client;

        public Client(string server, int port)
        {
            client = new TcpClient(server, port);
        }

        public void Send(string message, Action<byte[]> onReceive)
        {
            var stream = client.GetStream();

            var messageBytes = Encoding.UTF8.GetBytes(message);

            stream.Write(messageBytes, 0, messageBytes.Length);

            var receivedBytes = new byte[client.ReceiveBufferSize];
            while (stream.Read(receivedBytes, 0, receivedBytes.Length) != 0)
            {
                onReceive(receivedBytes);
            };
        }

        public void Close()
        {
            this.client.Close();
        }
    }
}

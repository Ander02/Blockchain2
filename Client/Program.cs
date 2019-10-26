using Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {


            //await RunTest();
        }

        private static async Task RunTest()
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                var s = i;
                foreach (var (ip, port) in Constants.Peers)
                {
                    var client = new Client(ip, port);
                    var task = Task.Run(() =>
                    {
                        client.Send($"Teste {s}", (bytes) =>
                        {
                            Console.WriteLine($"Client Received: {Encoding.UTF8.GetString(bytes).Replace("\0", "")}");
                        });
                        client.Close();
                    });
                    tasks.Add(task);
                }
            }
            await Task.WhenAll(tasks);
        }
    }
}

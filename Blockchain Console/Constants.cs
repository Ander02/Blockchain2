using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Shared
{
    public class Constants
    {
        public static readonly IEnumerable<(string ip, int port)> Peers = new List<(string, int)>
        {
            ("127.0.0.1", 5000),
            ("127.0.0.1", 5002),
        };
    }
}

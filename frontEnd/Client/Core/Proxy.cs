using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Interop;

namespace Client.Core
{
  class Proxy
  {

    public void Conect(string url)
    {
      IPHostEntry hostEntry = Dns.GetHostEntry("google.com");
      int port;
      if (url.Contains("https://")) { port = 443; }
      else { port = 80; }
      IPEndPoint localEndPoint = new IPEndPoint(hostEntry.AddressList[0], port);
      Socket client = new(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
      client.Bind(localEndPoint);

      client.Connect(localEndPoint);

      //string msg = "";

    }






  }
}

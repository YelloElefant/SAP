using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace Inventory.Core
{

  public class SocketClass
  {


    public static void StartServer()
    {
      MySqlClass.Start();

      Byte[] ip = new byte[4] { 192, 168, 1, 28 };




      // Get Host IP Address that is used to establish a connection
      // In this case, we get one IP address of localhost that is IP : 127.0.0.1
      // If a host has multiple addresses, you will get a list of addresses
      //IPHostEntry host = Dns.GetHostEntry("192.168.1.34");
      IPAddress ipAddress = new IPAddress(ip);
      IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

      try
      {

        // Create a Socket that will use Tcp protocol
        Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        // A Socket must be associated with an endpoint using the Bind method
        listener.Bind(localEndPoint);
        // Specify how many requests a Socket can listen before it gives Server busy response.
        // We will listen 10 requests at a time
        while (true)
        {
          listener.Listen(10);

          Console.WriteLine("Waiting for a connection...");
          Socket handler = listener.Accept();

          // Incoming data from the client.
          string? data = null;
          byte[]? bytes = null;

          while (true)
          {
            bytes = new byte[1024];
            int bytesRec = handler.Receive(bytes);
            data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
            break;
          }





          Console.WriteLine("Text received : {0}", data);

          byte[] msg = Encoding.ASCII.GetBytes("<|ACK|>");
          handler.Send(msg);
          handler.Shutdown(SocketShutdown.Both);
          handler.Close();
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
      }

      Thread.Sleep(5000);



    }


  }
}

using System.Net.Sockets;
using System.Net;
using System.Text;
using System;
using System.Threading.Tasks;

namespace Core;
public class SocketClass
{
    public static async Task ExecuteServerAsync()
    {
        // Establish the local endpoint
        // for the socket. Dns.GetHostName
        // returns the name of the host
        // running the application.
        Byte[] ip = new byte[4] { 192, 168, 1, 34 };

        //IPHostEntry ipHost = Dns.GetHostEntry("192.168.1.34");
        IPAddress ipAddr = new IPAddress(ip);
        IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11000);

        // Creation TCP/IP Socket using
        // Socket Class Constructor
        Socket client = new(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        await client.ConnectAsync(localEndPoint);
        while (true)
        {
            // Send message.
            var message = "Hi friends 👋!<|EOM|>";
            var messageBytes = Encoding.UTF8.GetBytes(message);
            _ = await client.SendAsync(messageBytes, SocketFlags.None);
            Console.WriteLine($"Socket client sent message: \"{message}\"");

            // Receive ack.
            var buffer = new byte[1_024];
            var received = await client.ReceiveAsync(buffer, SocketFlags.None);
            var response = Encoding.UTF8.GetString(buffer, 0, received);
            if (response == "<|ACK|>")
            {
                Console.WriteLine(
                    $"Socket client received acknowledgment: \"{response}\"");
                break;
            }
            // Sample output:
            //     Socket client sent message: "Hi friends 👋!<|EOM|>"
            //     Socket client received acknowledgment: "<|ACK|>"
        }


        
    }
}

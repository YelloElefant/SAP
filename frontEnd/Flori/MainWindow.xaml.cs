using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Sockets;
using System.Net;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Printing;

namespace Flori
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    public MainWindow()
    {
      InitializeComponent();
      Byte[] ip = new byte[4] { 192, 168, 1, 28 };


      IPAddress ipAddress = new IPAddress(ip);
      IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

      Socket client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
      client.Connect(localEndPoint);

      while (true)
      {
        // Send message.
        var message = "Hi friends 👋!<|EOM|>";
        var messageBytes = Encoding.UTF8.GetBytes(message);
        client.Send(messageBytes, SocketFlags.None);
        output.Content = message;
              
        // Receive ack.
        var buffer = new byte[1_024];
        var received = client.Receive(buffer, SocketFlags.None);

        var response = Encoding.UTF8.GetString(buffer, 0, received);
        if (response == "<|ACK|>")
        {
            output.Content = $"Socket server sent::" + response;
          break;
        }
        // Sample output:
        //     Socket client sent message: "Hi friends 👋!<|EOM|>"
        //     Socket client received acknowledgment: "<|ACK|>"
      }

      client.Shutdown(SocketShutdown.Both);



    }
  }
}

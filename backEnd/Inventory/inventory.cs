using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;



namespace Inventory
{


  public class Inventory
  {
    public static bool isConected = false;
    private static MySqlConnection connection;
    private static string? server;
    private static string? database;
    private static string? user;
    private static string? password;
    private static string? port;
    private static string? connectionString;
    private static string? sslM;


    public static Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
    public static void Main()
    {
      Start();
      StartServer();
    }

    public static void StartServer()
    {
        // Get Host IP Address that is used to establish a connection
        // In this case, we get one IP address of localhost that is IP : 127.0.0.1
        // If a host has multiple addresses, you will get a list of addresses
        IPHostEntry host = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        try {

            // Create a Socket that will use Tcp protocol
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // A Socket must be associated with an endpoint using the Bind method
            listener.Bind(localEndPoint);
            // Specify how many requests a Socket can listen before it gives Server busy response.
            // We will listen 10 requests at a time
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");
            Socket handler = listener.Accept();

             // Incoming data from the client.
             string data = null;
             byte[] bytes = null;

            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            Console.WriteLine("Text received : {0}", data);

            byte[] msg = Encoding.ASCII.GetBytes(data);
            handler.Send(msg);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\n Press any key to continue...");
        Console.ReadKey();
    }





    /// <summary>
    /// creats and logs on to mysql server
    /// </summary>
    public static void Login()
    {
      server = "192.168.1.34";
      database = "PHP";
      user = "yelloelefant";
      password = "elefant";
      port = "3306";
      sslM = "none";

      connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);
      connection = new MySqlConnection(connectionString);
    }
    /// <summary>
    /// opens conection to mysql server
    /// </summary>
    public static void Start()
    {
        Login();

        try
        {
            connection.Open();

            isConected = true;

        }
        catch (MySqlException ex)
        {
            isConected = false;
            Console.WriteLine(ex.Code);


        }
    }
    /// <summary>
    /// adds entry to database table
    /// </summary>
    /// <param name="word">value to add</param>
    public static void Add(string word)
    {
      string query = $"insert into PHP.Inventory (product) values ('{word}')";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      var reader = cmd.ExecuteReader();
      reader.Read();
      reader.Close();




    }
    /// <summary>
    /// closes the conection to mysql server
    /// </summary>
    public static void Stop()
    {
      connection.Close();
    }

    


  }
}
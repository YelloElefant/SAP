using System;
using System.Data;


using MySql.Data;
using MySql.Data.MySqlClient;



namespace Inventory
{


  public class Inventory
  {
    public static bool isConected = false;
    private static MySqlConnection connection;
    private static string server;
    private static string database;
    private static string user;
    private static string password;
    private static string port;
    private static string connectionString;
    private static string sslM;




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
    public static void conexion()
    {
        try
        {
            connection.Open();

            isConected = true;

        }
        catch (MySqlException ex)
        {
          isConected = false;
           
        }
    }

    public static void Add(int word)
    {
      string query = $"insert into PHP.Inventory (product) values ({word})";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      var reader = cmd.ExecuteReader();
        
      reader.Close();
      



    }

    public static void disConect()
    {
      connection.Close();
    }
  }
}
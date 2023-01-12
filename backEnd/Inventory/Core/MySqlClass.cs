using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core
{
    public class MySqlClass
    {
        private static MySqlConnection connection;
        private static string? server;
        private static string? database;
        private static string? user;
        private static string? password;
        private static string? port;
        private static string? connectionString;
        private static string? sslM;
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

                Inventory.isConected = true;

            }
            catch (MySqlException ex)
            {
                Inventory.isConected = false;
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

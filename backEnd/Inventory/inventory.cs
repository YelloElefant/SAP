using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using Inventory.Core;

namespace Inventory
{


  public class Inventory
  {
    public static bool isConected = false;




    public static Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
    public static void Main()
    {
        MySqlClass.Start();
    }
    
    




  
   
    

    


  }
}
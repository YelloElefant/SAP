using System;
using Inventory;
using System.Windows;
using User.commandLib;


namespace Program
{
  public class Program
  {
    public static Thread threadInventory = new Thread(new ThreadStart(Inventory.Core.SocketClass.StartServer));


    public static void Main()
    {
      Console.WriteLine("User Interface for backEnd SAP control");
      Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
      Console.WriteLine("--enter commands to run--");

      while (true)
      {
        Console.Write(">");
        string? input = Console.ReadLine();
        command(input);

      }




    }

    private static void command(string userCmd)
    {
      var splitCommmnd = userCmd.Split(' ');
      if (splitCommmnd[0] == "inventory")
      {
        command2(splitCommmnd);
      }
      else if (splitCommmnd[0] == "exit")
      {
        System.Environment.Exit(1);
      }


    }


    public static void command2(string[] userCmd)
    {
      switch (userCmd[1])
      {
        case "start":
          threadInventory.Start();
          break;
        case "stop":
          try
          {
            if (threadInventory.IsAlive == false)
            {
              throw new Exception();
            }
            threadInventory.Interrupt();
            System.Console.WriteLine("thred was stoped");
          }
          catch
          {
            System.Console.WriteLine("thred was not stoped or was never started");
          }
          break;
        default:
          break;
      }

    }

  }
}
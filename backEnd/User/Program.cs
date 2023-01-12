using System;
using Inventory;
using System.Windows;
using User.commandLib;


namespace Program
{
    public class Program
    {
        


        public static void Main()
        {
            Console.WriteLine("User Interface for backEnd SAP control");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("--enter commands to run--");

            while (true)
            {
                string? input = Console.ReadLine();
                command(input);

            }

            


        }

        private static void command(string userCmd) 
        {
            var splitCommmnd = userCmd.Split(' ');
            if (splitCommmnd[0] == "inventory" ) 
            {
                InventoryCmd.command2(splitCommmnd);
            }


        }

        
    }
}







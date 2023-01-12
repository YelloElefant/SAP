using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory;

namespace User.commandLib
{
    public class InventoryCmd
    {

        public static void command2(string[] userCmd) 
        {
            switch (userCmd[1]) 
            {
                case "start":

                    Inventory.Core.MySqlClass.Start();
                    Console.WriteLine($"database {Inventory.Inventory.isConected}");
                    break;
                case "stop":
                    Inventory.Core.MySqlClass.Stop();
                    Console.WriteLine("database disconected");
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
        
        }

        

    }
}

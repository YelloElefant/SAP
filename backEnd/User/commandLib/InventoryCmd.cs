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
                    Inventory.Core.SocketClass.StartServer();
                    break;
                case "stop":
                    
                    break;
                default:
                    break;
            }
        
        }

        

    }
}

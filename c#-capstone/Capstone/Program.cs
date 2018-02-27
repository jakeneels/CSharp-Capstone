using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Inventory;
using Capstone.Inventory.ProductFolder;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryClass inventory = new InventoryClass();
            Account account = new Account();
            Menu menu = new Menu();
            menu.Start(inventory, account);

           //Console.WriteLine($"Total Change returned = {changeReturn.Sum()}");

            Console.ReadKey();
        }
    }
}

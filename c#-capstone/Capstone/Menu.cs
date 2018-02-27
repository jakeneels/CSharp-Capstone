using Capstone.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capstone.Inventory.ProductFolder;
using System.Threading;

namespace Capstone
{
    public class Menu : InventoryClass
    {
        public static string lastStatus = "";
        public void Start(InventoryClass inventory, Account account)
        {
            string selection = "";
           
            while (selection != "0")
            {
                
                DisplayVendingMenu(inventory);
                Console.WriteLine($"Your current balance is {account.Balance}");
                Console.WriteLine($"Enter a Item Key to buy");
                Console.WriteLine($"Enter 1 to feed money");
                Console.WriteLine("Enter 0 to quit and checkout");
                Console.WriteLine(lastStatus);
                selection = Console.ReadLine().ToUpper();

                if (inventory.ItemLocation.ContainsKey(selection))
                {
                    Product product = inventory.ItemLocation[selection];

                    if (account.Balance < product.Price)
                    {
                        lastStatus = $"You are {Math.Abs((product.Price - account.Balance))} short of making this purchase select 1 to add funds";
                    }

                    inventory.Sale(selection, account);
                }

                if (selection == "1")
                {
                    Console.WriteLine("Enter how much money you would like to add or 0 to go back");
                    account.FeedMoney();
                }
                if (selection == "0")
                {
                    Console.WriteLine(account.FinishTransaction());
                    Console.WriteLine("Hit any key to quit");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }

        public void DisplayVendingMenu(InventoryClass inventory)
        {
            Console.WriteLine("Key   Name                 Price   Available");
            foreach (var item in inventory.ItemLocation)
            {
                Console.WriteLine($"{item.Value.ProductKey.PadRight(5)} {item.Value.Name.PadRight(20)} {item.Value.Price}      {item.Value.QuantityLeft}");
            }
            Console.WriteLine();
        }

        public void FeedMoneyMenu(InventoryClass vend)
        {
            Console.WriteLine("Enter money to feed");
            decimal money;
            decimal.TryParse(Console.ReadLine(), out money);
            Account account = new Account();

            account.FeedMoney();

            Console.WriteLine($"Current Money is:{account.Balance}");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "1")
            {
                account.FeedMoney();
            }
            else if (userInput == "2")
            {
                DisplayVendingMenu(vend);
            }
        }
    }
}


using Capstone.Inventory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class Logger
    {
        static string logDirectory = Environment.CurrentDirectory +
             "\\..\\../TransactionsLog/Log.txt";

        static DateTime timeStamp;

        public static void Product(Product product, decimal balanceBefore)
        {
            using (StreamWriter sr = new StreamWriter(logDirectory, true))
            {
                timeStamp = DateTime.Now;
                InventoryClass inventory = new InventoryClass();
                sr.WriteLine($"{timeStamp.ToString().PadRight(20)} " +
                             $" Item {product.Name.PadRight(20)} {product.ProductKey.PadRight(20)} {balanceBefore.ToString().PadRight(20)}" +
                             $"    {balanceBefore - product.Price}  ");
            }
        }

        public static void FeedMoney(decimal money, decimal balance)
        {
            using (StreamWriter sr = new StreamWriter(logDirectory, true))
            {
                timeStamp = DateTime.Now;
                InventoryClass inventory = new InventoryClass();
                sr.WriteLine($"{timeStamp.ToString().PadRight(20)}  FEED MONEY  {money.ToString().PadLeft(40).PadRight(55)}" +
                             $"     {balance.ToString().PadRight(20)}");
            }
        }

        public static void GiveChange(decimal balance)
        {
            using (StreamWriter sr = new StreamWriter(logDirectory, true))
            {
                timeStamp = DateTime.Now;
                sr.WriteLine($"{timeStamp.ToString().PadRight(20)}  GIVE CHANGE {balance.ToString().PadLeft(40).PadRight(40)}" +
                             $"                    0");
            }
        }
    }
}

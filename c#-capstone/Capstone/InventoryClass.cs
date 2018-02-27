using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Capstone.Inventory.ProductFolder;

namespace Capstone.Inventory
{
    public class InventoryClass
    {
        Dictionary<string, Product> _itemLocation
            = new Dictionary<string, Product>();

        public Dictionary<string, Product> ItemLocation
        { get { return _itemLocation; } }

        public InventoryClass()
        {
            string folder = Environment.CurrentDirectory;
            string fileName = "\\..\\..\\../etc/vendingmachine.csv";
            string fullName = Path.Combine(folder + fileName);

            using (StreamReader sr = new StreamReader(fullName))
            {
                while (!sr.EndOfStream)
                {
                    string inventoryLine = sr.ReadLine();
                    string[] data = inventoryLine.Split('|');
                    string itemLocation = data[0];
                    switch (data[0][0]) // first char of key, there must be a better way
                    {
                        case 'A':
                            _itemLocation.Add(itemLocation, new Chip(data));
                            break;

                        case 'B':
                            _itemLocation.Add(itemLocation, new Candy(data));
                            break;

                        case 'C':
                            _itemLocation.Add(itemLocation, new Beverage(data));
                            break;

                        case 'D':
                            _itemLocation.Add(itemLocation, new Gum(data));
                            break;
                    }
                }
            }
        }

        public void Sale(string ProductKey, Account account)
        {
            if (ItemLocation.ContainsKey(ProductKey))
            {
                Product product = ItemLocation[ProductKey];

                if (account.Balance >= product.Price)
                {
                    product.QuantityLeft--;
                    Menu.lastStatus = product.GetSound();
                    account.Balance -= product.Price;
                    Logger.Product(product, account.Balance);
                }

                if (product.QuantityLeft == 0)
                {
                    RemoveFromStock(ProductKey);
                    Menu.lastStatus = $"Removing {ProductKey} {product.Name} Out of Stock";
                    Thread.Sleep(1500);
                }
            }
        }

        private void RemoveFromStock(string ProductKey)
        {
            ItemLocation.Remove(ProductKey);
        }

        public string Print()
        {
            string items = "";
            foreach (var product in ItemLocation)
            {
                Console.WriteLine($"{product.Key} {product.Value.Name}        {product.Value.Price} ");
            }
            return items;
        }
    }
}

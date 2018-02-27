using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Inventory
{
    public class Product
    {
        decimal _price;
        string _productKey;

        public string Name { get; set; }
        public decimal Price { get { return _price; } }
        public int QuantityLeft { get; set; }
        public string ProductKey { get { return _productKey.ToUpper(); } private set { _productKey = value; } }

        public Product(string[] data)
        {
            Name = data[1];
            decimal.TryParse(data[2], out _price);
            QuantityLeft = 5;
            ProductKey = data[0];
        }

        public virtual string GetSound()
        {
            return ""; 
        }
    }
}

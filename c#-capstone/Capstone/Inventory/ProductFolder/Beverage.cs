using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Inventory.ProductFolder
{
    public class Beverage : Product
    {
        public override string GetSound()
        {
            return "Glug, Glug, Yum!";
        }
        public Beverage(string[] csvData) : base(csvData) { }

    }
}

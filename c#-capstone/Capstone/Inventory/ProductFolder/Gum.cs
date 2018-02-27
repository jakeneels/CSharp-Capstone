using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Inventory.ProductFolder
{
    public class Gum : Product
    {
        public override string GetSound()
        {
            return "Chew, Chew, Yum!";
        }

        public Gum(string[] csvData) : base(csvData) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Inventory.ProductFolder
{
    public class Candy : Product
    {

        public override string GetSound()
        {
            return "Munch, Munch, Yum!";
        }
        public Candy(string[] csvData) : base(csvData) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Inventory.ProductFolder
{
    public class Chip : Product
    {
        public Chip(string[] csvData) : base(csvData) { }

        public override string GetSound()
        {
            return "Crunch, Crunch, Yum!";
        }
    }
}

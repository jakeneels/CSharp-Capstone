using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Please enter the search phrase:");
            var searchPhrase = Console.ReadLine();
            Console.WriteLine($"Please enter the replace phrase:");
            var replacePhrase = Console.ReadLine();
            Console.WriteLine($"Please enter the source file path (if entry is blank, default file will be used):");
            var sourcePath = Console.ReadLine();
            if (sourcePath == "")
            {
                sourcePath = Environment.CurrentDirectory + "\\..\\..\\../alices_adventures_in_wonderland.txt";
            }
            while (!File.Exists(sourcePath))
            {
                Console.WriteLine($"invalid source path, please re-enter (if entry is blank, default file will be used):");
                sourcePath = Console.ReadLine();
                if (sourcePath == "")
                {
                    sourcePath = Environment.CurrentDirectory + "\\..\\..\\../alices_adventures_in_wonderland.txt";
                }
            }

            Console.WriteLine("Please enter the destination file path (if entry is blank, default file will be used):");
            var destinyPath = Console.ReadLine();
            if (destinyPath == "")
            {
                destinyPath = Environment.CurrentDirectory + "\\..\\..\\../alices_adventures_in_wonderland_copy.txt";
            }
            if (File.Exists(destinyPath))
            {
                Console.WriteLine("This file already exists, exiting program...good-bye.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            using (StreamReader sr = new StreamReader(sourcePath))
            {              
                while (!sr.EndOfStream)
                {
                    var srLine = sr.ReadLine();

                    if (srLine.Contains(searchPhrase))
                    {
                        srLine = srLine.Replace(searchPhrase, replacePhrase);
                    }                  
                    using (StreamWriter sw = new StreamWriter(destinyPath, true))
                    {
                        sw.WriteLine(srLine);
                    }

                }
            }
       
        }
    }
}

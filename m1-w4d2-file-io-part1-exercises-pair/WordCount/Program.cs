using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        public static void Main(string[] args)
        {
            string filePath = Environment.CurrentDirectory + "\\..\\..\\../alices_adventures_in_wonderland.txt";

            Console.WriteLine("Where do you want to search? Press Enter for default.");
            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                filePath = userInput;
            }

            Console.WriteLine(WordCountExercise(filePath));
            Console.WriteLine(SentenceCountExercise(filePath));
            Console.ReadKey();
        }

        public static int WordCountExercise(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] streamArray;
                string normalString = sr.ReadToEnd();

                streamArray = normalString.Split(new[] { '\r', '\n', ' ', }, StringSplitOptions.RemoveEmptyEntries);

                return streamArray.Length;
            }
        }
        public static int SentenceCountExercise(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] streamArray;
                string normalString = sr.ReadToEnd();

                streamArray = normalString.Split(new[] { ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);

                return streamArray.Length;
            }
        }
    }
}


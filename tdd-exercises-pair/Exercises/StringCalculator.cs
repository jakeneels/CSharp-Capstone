using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExercises
{
    public class StringCalculator
    {
        // {1,2,3}
        public int Add(string inputStr)
        {
            string[] strArr;

            if (inputStr.Contains(','))
            {
                strArr = inputStr.Split(',');
            }
            else 
            {
                strArr = inputStr.Split('\n');
            }
            int result = 0;

            foreach (var str in strArr)
            {
                int toAdd = 0;

                if (str != "")
                {
                    int.TryParse(str, out toAdd);
                }

                result += toAdd;
            }

            return result;
        }

        public int Add(string[]strArr)
        {
            int result = 0;
            foreach (var str in strArr)
            {
                result += Add(str);

            }
            return result;
        }
    }
}

using Capstone.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Account
    {
        public int[] _changeReturn = new int[5];
        public decimal Balance { get; set; }

        public string FinishTransaction()
        {
            while (Balance - 1 >= 0)
            {
                Balance -= 1;
                _changeReturn[0]++;
            }
            while (Balance - 0.25m >= 0)
            {
                Balance -= 0.25m;
                _changeReturn[1]++;
            }
            while (Balance - 0.10m >= 0)
            {
                Balance -= 0.10m;
                _changeReturn[2]++;
            }
            while (Balance - 0.05m >= 0)
            {
                Balance -= 0.05m;
                _changeReturn[3]++;
            }
            while (Balance - 0.01m >= 0)
            {
                Balance -= 0.01m;
                _changeReturn[4]++;
            }
            Logger.GiveChange(Balance);
            Balance = 0;

            return $"Your change:" +
                   $"\n{_changeReturn[0]} Sacagawea(s) " +
                   $"\n{_changeReturn[1]} quarter(s) " +
                   $"\n{_changeReturn[2]} dime(s) " +
                   $"\n{_changeReturn[3]} nickel(s) " +
                   $"\n{_changeReturn[4]} pennie(s) ";
        }

        public void FeedMoney()
        {
            decimal money = 0;
            do
            {
                decimal.TryParse(Console.ReadLine(), out money);
                if (money < 1.00m)
                {
                    Console.WriteLine("Minimum increment to add is $1");
                }
                else
                {
                    Balance += money;
                    Menu.lastStatus = $"Added ${money} successfully";
                    Logger.FeedMoney(money, Balance);
                }
            } while (money < 1 && money != 0);
            
        }
    }
}

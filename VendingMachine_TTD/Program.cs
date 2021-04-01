using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_TTD;

namespace VendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserCoinOptions.UserOptions();
        }


    }

    public class UserCoinOptions
    {
       public static double enteredCoin = 0.0;
        public static void CommonOptions()
        {
           
            Console.WriteLine("Welcome to Vending machine");
            Console.WriteLine("---------- Please enter Valid Coin-------------");
            Console.WriteLine("1] Nickels (0.05$): ");
            Console.WriteLine("2] Dimes 0.1$");
            Console.WriteLine("3] Quarter 0.25$");
            enteredCoin = Convert.ToDouble(Console.ReadLine());
        }
        public static void UserOptions()
        {
            #region User Input and call Business Logic 

            CommonOptions();
            //Call Business Logic

            VendingMachine_BL objVending = new VendingMachine_BL(enteredCoin);
            objVending.CheckValidCoin();

            Console.ReadLine();
            #endregion
        }

        public static void MoreCoinAddingOptions()
        {
            CommonOptions();
            VendingMachine_BL objMoreCoin = new VendingMachine_BL();
            Console.ReadLine();

        }
    }


    public class UserProductOptions
    {
        public static string ProductName { get; set; }
        public static void UserProductOpts(double enteredAmount)
        {

            Console.WriteLine("01. Cola is for $1.00");
            Console.WriteLine("02. Chips is for $0.50");
            Console.WriteLine("03. Candy is for $0.65");
            ProductName = Console.ReadLine().ToUpper();
        }
    }
}

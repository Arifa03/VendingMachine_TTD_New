using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserOptions userOptions = new UserOptions();
            userOptions.UserOptions_AddCoin();
            userOptions.SelectProductOptions();            

            Console.ReadLine();
        }
    }

    public class UserOptions
    {
        public static double enteredCoin = 0.0;
        VendingMachine_BL objVending = new VendingMachine_BL();
        public void CommonOptions()
        {

            Console.WriteLine("Welcome to Vending machine");
            Console.WriteLine("---------- Please enter Valid Coin-------------");
            Console.WriteLine("1] Nickels (0.05$): ");
            Console.WriteLine("2] Dimes 0.1$");
            Console.WriteLine("3] Quarter 0.25$");
            var enterCoin_check = Console.ReadLine();
            
            if (!double.TryParse(enterCoin_check,out enteredCoin))
            {
                Console.WriteLine($"{enterCoin_check} is not valid Coin..");
            }

        }
        public void UserOptions_AddCoin()
        {
            #region User Input and call Business Logic 
            CommonOptions();
            //Call Business Logic            
            while (true)
            {
                objVending.CheckValidCoin(enteredCoin);

                Console.WriteLine($"Do you want to enter more coins : Y/N");
                string moreCoin = Console.ReadLine();
                if (moreCoin.Equals("N"))
                { 
                    break;
                }
                
                CommonOptions();
            }            
            #endregion
        }
        
        public void SelectProductOptions()
        {            
            while (true)
            {
                Console.WriteLine("01. Cola is for $1.00");
                Console.WriteLine("02. Chips is for $0.50");
                Console.WriteLine("03. Candy is for $0.65");

                bool isSuccess = objVending.SelectProduct(Console.ReadLine().ToUpper());
                
                if (isSuccess)
                {
                    break;
                }
                else
                {
                    UserOptions_AddCoin();
                }
            }
            
        }
    }

}

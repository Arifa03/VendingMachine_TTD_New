using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine;

namespace VendingMachine_TTD
{
    class VendingMachine_BL : IAcceptCoin, ISelectProduct, IDespenceProduct
    {
        public double Total_Amount = 0.0;
        double _enteredCoin = 0.0;

        #region CoinConst

        public const double Nickels = 0.05;
        public const double Dimes = 0.1;
        public const double Quarter = 0.25;
        #endregion

        #region ProductConsts

        public const string product_1 = "COLA";
        public const string product_2 = "CHIPS";
        public const string product_3 = "CANDY";

        public const double prod_1_Amount = 1.00;
        public const double prod_2_Amount = 0.50;
        public const double prod_3_Amount = 0.65;

        #endregion

        public VendingMachine_BL(double enteredCoin)
        {
            this._enteredCoin = enteredCoin;
            Total_Amount = this._enteredCoin;

        }
        public VendingMachine_BL()
        {
            Total_Amount= this._enteredCoin;
        }

        #region CheckCoinMethod
        public void CheckValidCoin()
        {
            if (_enteredCoin == Nickels || _enteredCoin == Dimes || _enteredCoin == Quarter)
            {

                Console.WriteLine($"{_enteredCoin} is valid amount, " +
                    $"Do you want to enter more coins : Y/N");
                string moreCoin = Console.ReadLine();
                switch (moreCoin.ToUpper())
                {
                    case "Y":
                        UserCoinOptions.UserOptions();
                        Total_Amount += _enteredCoin;
                        break;
                    case "N":
                        UserProductOptions.UserProductOpts(_enteredCoin);
                        string productName = UserProductOptions.ProductName;
                        SelectProduct(productName, _enteredCoin);
                        break;
                    default:
                        break;
                }

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"{_enteredCoin} is invalid coin");
                Console.WriteLine("Do you enter coin again? Y/N");
                string reset = Console.ReadLine();
                switch (reset.ToUpper())
                {
                    case "Y":
                        UserCoinOptions.UserOptions();
                        Total_Amount += _enteredCoin;
                        break;

                    case "N":
                        Console.WriteLine("We can't move further..");
                        break;

                    default:
                        Console.WriteLine("Invalid Coin");
                        break;


                }
            }
        }
        #endregion

        #region SelectProduct 
        public void SelectProduct(string product, double enteredAmount)
        {
            if (product == product_1 || product == product_2 || product == product_3)
            {
                //check sufficient balance
                bool isTrue = CheckSufficientBalance(product);
                if (isTrue == true)
                {
                    DespenceProduct(product);
                }
                else
                {
                    Console.WriteLine($"{product} not a valid product.");
                    Console.ReadLine();
                }
            }
            else
            {

            }
        }
        #endregion

        #region DespenceProduct
        public void DespenceProduct(string product_Name)
        {
            Console.WriteLine($"{product_Name} has been despenced successfully, THANK YOU!");
            Console.ReadLine();
        }
        #endregion

        public bool CheckSufficientBalance(string productName)
        {
            if (productName == product_1)
            {
                if (Total_Amount >= prod_1_Amount)
                {
                    Total_Amount = Total_Amount - prod_1_Amount;
                    Console.WriteLine($"The Remaining Amount in your account is {Total_Amount}");
                    return true;
                }


            }
            else if (productName == product_2)
            {
                if (Total_Amount >= prod_2_Amount)
                {
                    Total_Amount = Total_Amount - prod_1_Amount;
                    Console.WriteLine($"The Remaining Amount in your account is {Total_Amount}");
                    return true;
                }

            }
            else if (productName == product_3)
            {
                if (Total_Amount >= prod_3_Amount)
                {
                    Total_Amount = Total_Amount - prod_1_Amount;
                    Console.WriteLine($"The Remaining Amount in your account is {Total_Amount}");
                    return true;
                }

            }

            return false;


        }

    }

}


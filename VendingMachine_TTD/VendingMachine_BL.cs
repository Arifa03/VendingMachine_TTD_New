using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine;

namespace VendingMachine
{
    public class VendingMachine_BL : IAcceptCoin, ISelectProduct, IDespenceProduct
    {
        public double Total_Amount = 0.0;
        double _enteredCoin = 0.0;

        #region CoinConst

        IDictionary<double, string> coinList = new Dictionary<double, string>();


        #endregion

        #region ProductConsts


        IDictionary<string, double> productList = new Dictionary<string, double>();

        #endregion

        public VendingMachine_BL() //double enteredCoin
        {
            //this._enteredCoin = enteredCoin;
            //Total_Amount =+ this._enteredCoin;
            GetCoins();
            GetProducts();
        }

        public void GetCoins()
        {
            coinList.Add(0.05, "Nickels");
            coinList.Add(0.1, "Dimes");
            coinList.Add(0.25, "Quarter");
        }

        public void GetProducts()
        {
            productList.Add("COLA", 1.00);
            productList.Add("CHIPS", 0.5);
            productList.Add("CANDY", 0.65);
        }

        #region CheckCoinMethod
        public void CheckValidCoin(double enteredAmount)
        {
            try
            {
                if (coinList.ContainsKey(enteredAmount)) 
                {
                    Total_Amount += enteredAmount;                    
                }
                else
                {
                    Console.WriteLine($"{enteredAmount} is invalid coin");                    
                }
                Console.WriteLine($"Total Coin Amount: {Total_Amount}");
            }
            catch (Exception)
            {
                Console.WriteLine("There is some issue cannot proceed further..");
            }

        }
        #endregion

        #region SelectProduct 
        public bool SelectProduct(string product)
        {            
            if (productList.ContainsKey(product.ToUpper()))
            {
                if (Total_Amount >= productList[product])
                {
                    DespenceProduct(product);
                    Total_Amount = Total_Amount - productList[product];
                    Console.WriteLine($"The Remaining Amount in your account is {Total_Amount}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Insufficient Balance.");
                }
            }
            else
            {
                Console.WriteLine($"{product} not a valid product.");
            }
            return false;
        }
        #endregion

        #region DespenceProduct
        public void DespenceProduct(string product_Name)
        {
            Console.WriteLine($"{product_Name} has been despenced successfully, THANK YOU!");
            Console.ReadLine();
        }
        #endregion

    }

}


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VendingMachine;

namespace VendingMachine_Tests
{
    [TestClass]
    public class VendingMachineTests
    {
        VendingMachine_BL vendingMachine_BL = new VendingMachine_BL();        

        [TestMethod]
        public void CheckValidCoinSuccess()
        {
            //Arrange
            double coin = 0.05;
            double expectedTotalAmt = 0.05;

            //Act
            vendingMachine_BL.CheckValidCoin(coin);
            double actualTotalAmt = vendingMachine_BL.Total_Amount;

            //Assert
            Assert.AreEqual(expectedTotalAmt, actualTotalAmt, "Valid Coin");
        }

        [TestMethod]
        public void CheckValidCoinFail()
        {
            //Arrange
            double coin = 0.05;
            double expectedTotalAmt = 0.15;

            //Act
            vendingMachine_BL.CheckValidCoin(coin);
            double actualTotalAmt = vendingMachine_BL.Total_Amount;

            //Assert
            Assert.AreNotEqual(expectedTotalAmt, actualTotalAmt, "InValid Coin");
        }

        [TestMethod]
        public void SelectProductSuccess()
        {
            //Arrange
            string product = "CHIPS";
            bool expected = true;

            vendingMachine_BL.CheckValidCoin(0.25);
            vendingMachine_BL.CheckValidCoin(0.25);

            //Act
            bool actual = vendingMachine_BL.SelectProduct(product);            

            //Assert
            Assert.AreEqual(expected, actual, "Product Selected");
        }

        [TestMethod]
        public void SelectProductInsufficientBalance()
        {
            //Arrange
            string product = "CHIPS";
            bool expected = true;

            vendingMachine_BL.CheckValidCoin(0.25);            

            //Act
            bool actual = vendingMachine_BL.SelectProduct(product);

            //Assert
            Assert.AreNotEqual(expected, actual, "Insufficient Balance");
        }


        [TestMethod]
        public void SelectProductInvalidProduct()
        {
            //Arrange
            string product = "CHOCO";
            bool expected = true;

            vendingMachine_BL.CheckValidCoin(0.25);
            vendingMachine_BL.CheckValidCoin(0.25);
            vendingMachine_BL.CheckValidCoin(0.25);

            //Act
            bool actual = vendingMachine_BL.SelectProduct(product);

            //Assert
            Assert.AreNotEqual(expected, actual, "Invalid Product");
        }
    }
}

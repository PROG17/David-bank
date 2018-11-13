using DaBank.Controllers;
using DaBank.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTesting
{
    [TestClass]
    public class BankControllerTest
    {

        public Bank bankRep = new Bank();

        [TestInitialize]
        public void Init()
        {

            bankRep.Customers = new List<Customer>
            {
                new Customer("David Agdelius", 1, new List<Account>
                {
                    new Account(10, 1000),
                    new Account(11, 400)
                }),
            };
        }

        [TestMethod]
        public void Withdraw()
        {
            var bankController = new BankController();

            decimal withdrawNumber = 500;

            var result = bankController.Withdraw(bankRep.Customers[0].Account[0], withdrawNumber);

            Assert.AreEqual(500, result.Moneyz);

        }

        [TestMethod]
        public void Deposit()
        {
            var bankController = new BankController();

            decimal depositNumber = 500;

            var result = bankController.Deposit(bankRep.Customers[0].Account[0], depositNumber);

            Assert.AreEqual(1500, result.Moneyz);

        }


        [TestMethod]
        public void AssertOverdraw()
        {
            var bankController = new BankController();

            decimal withdrawNumber = 1500;

            var result = bankController.Withdraw(bankRep.Customers[0].Account[0], withdrawNumber);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TransferWithinFunds()
        {
            var bankController = new BankController();

            decimal amount = 300, expectedAcc1Moneyz = 700, expectedAcc2Moneyz = 700;

            var result = bankController.Transfer(GetAccount(10), GetAccount(11), amount);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedAcc1Moneyz, GetAccount(10).Moneyz);
            Assert.AreEqual(expectedAcc2Moneyz, GetAccount(11).Moneyz);
        }

        [TestMethod]
        public void TransferTooMuch()
        {
            var bankController = new BankController();

            decimal amount = 500, expectedAcc1Moneyz = 1000, expectedAcc2Moneyz = 400;

            var result = bankController.Transfer(GetAccount(11), GetAccount(10), amount);

            Assert.IsFalse(result);
            Assert.AreEqual(expectedAcc1Moneyz, GetAccount(10).Moneyz);
            Assert.AreEqual(expectedAcc2Moneyz, GetAccount(11).Moneyz);
        }

        private Account GetAccount(int accountNumber)
        {
            return bankRep.Customers.SelectMany(x => x.Account).FirstOrDefault(x => x.AccountNumber == accountNumber);
        }
    }
}

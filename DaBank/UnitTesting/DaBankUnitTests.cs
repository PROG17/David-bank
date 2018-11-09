using DaBank.Controllers;
using DaBank.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class BankControllerTest
    {

        public BankRepository bankRep = new BankRepository();

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
    }


}

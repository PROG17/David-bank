using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaBank.Models
{
    public class Customer
    {

        public string Name { get; set; }
        public int CustomerNumber { get; set; }
        public List<Account> Account;

        public Customer(string name, int custNumber, List<Account> account)
        {
            Name = name;
            CustomerNumber = custNumber;
            Account = account;
        }

    }
}

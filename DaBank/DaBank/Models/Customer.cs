using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaBank.Models
{
    public class Customer
    {
       
        public string Name { get; set; }
        public List<Account> Account;
        
        public Customer(string name, List<Account> account)
        {
            Name = name;
            Account = account;
        }

    }
}

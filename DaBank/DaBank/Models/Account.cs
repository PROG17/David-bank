using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaBank.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public int CustomerNumber { get; set; }
        public decimal Moneyz { get; set; }

        public Account(int accNumber, decimal moneyz)
        {
            AccountNumber = accNumber;
            Moneyz = moneyz;
        }
    }
}

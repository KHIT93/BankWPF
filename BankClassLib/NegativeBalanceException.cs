using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLib
{
    public class NegativeBalanceException : Exception
    {
        public NegativeBalanceException(string msg) : base(msg)
        {
            
        }
    }
}

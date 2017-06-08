using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Exceptions
{
    public class NegativeBalanceException : Exception
    {
        public NegativeBalanceException(string msg) : base(msg)
        {

        }
    }
}

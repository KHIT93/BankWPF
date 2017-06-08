using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Exceptions
{
    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string msg) : base(msg)
        {

        }
    }
}

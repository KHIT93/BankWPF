using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Exceptions
{
    public class InvalidAccountNameException : Exception
    {
        public InvalidAccountNameException(string msg = "The specified account name is invalid") : base(msg)
        {

        }
    }
}

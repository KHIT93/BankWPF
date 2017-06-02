using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLib
{
    public class InvalidAccountNameException : Exception
    {
        public InvalidAccountNameException(string msg = "The specified account name is invalid") : base(msg)
        {

        }
    }
}

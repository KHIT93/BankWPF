using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BankClassLib
{
    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string msg) : base(msg)
        {
            
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Models
{
    public class SalaryAccount : Account
    {
        public SalaryAccount(string name, int accountNumber)
        {
            this.Name = name;
            this._balance = 0;
        }
        public SalaryAccount(string name, int accountNumber, double balance)
        {
            this.Name = name;
            this._balance = balance;
        }
        public override void AddInterest()
        {
            this.Balance *= 1.005;
        }
    }
}

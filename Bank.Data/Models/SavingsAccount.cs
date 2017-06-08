﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Models
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string name, int accountNumber)
        {
            this.Name = name;
            this._balance = 0;
        }
        public SavingsAccount(string name, int accountNumber, double balance)
        {
            this.Name = name;
            this._balance = balance;
        }
        public override void AddInterest()
        {
            if (this._balance < 50000)
            {
                this._balance *= 1.01;
            }
            else if (this._balance > 50000 && this._balance < 100000)
            {
                this._balance *= 1.02;
            }
            else if (this._balance > 100000)
            {
                this.Balance *= 1.03;
            }
        }
    }
}
﻿using Bank.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Models
{
    public class Overdraft : Account
    {
        public Overdraft()
        {

        }
        public Overdraft(string name)
        {
            this.Name = name;
            this._balance= 0;
        }
        public Overdraft(string name, double balance)
        {
            this.Name = name;
            this._balance = balance;
        }

        public override double Balance
        {
            get { return this._balance; }
            set
            {
                this._balance = value;
                if ((this._balance) < 0)
                {
                    throw new NegativeBalanceException(string.Format("Warning!\nPlease note that the account balance for account number {0} is negative.\nThe current balance is {1:c}", this.AccountId, this._balance));
                }
            }
        }

        public override string AccountType
        {
            get
            {
                return "Overdraft";
            }
        }

        public override double AddInterest()
        {
            return (this._balance < 0) ? this.Balance * 0.05 : this.Balance * 0.005;
        }

        public override bool CanWithdraw()
        {
            return true;
        }

        public override bool CanWithdraw(double amount)
        {
            return this.CanWithdraw();
        }
    }
}

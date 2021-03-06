﻿using Bank.Data.Exceptions;
using Bank.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Models
{
    public abstract class Account : IAccount
    {
        protected double _balance;
        [Key]
        public int AccountId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public virtual double Balance
        {
            get
            {
                return this._balance;
            }
            set
            {
                if(value < 0)
                {
                    throw new NegativeBalanceException(
                        string.Format(
                            "Warning!\nThe account type for account number {0} does now allow a negative balance.\nThe current balance is {1:c}",
                            this.AccountId,
                            this._balance
                        )
                    );
                }
                else
                {
                    this._balance = value;
                }
            }
        }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        public abstract double AddInterest();
        public abstract string AccountType { get; }

        public void CalculateBalance()
        {
            this.Balance = this.Transactions.Sum(o => o.Amount);
            //return this.Transactions.Sum(o => o.Amount);
        }

        public virtual bool CanWithdraw()
        {
            return this.Balance > 0;
        }

        public virtual bool CanWithdraw(double amount)
        {
            try
            {
                if(amount == 0)
                {
                    return true;
                }
                else
                {
                    this.Balance = this.Balance + amount;
                }
            }
            catch (NegativeBalanceException ex)
            {
                return false;
            }
            return true;
        }
    }
}

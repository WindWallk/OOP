﻿using BankOfKurtovoKonare.Models;

namespace BankOfKurtovoKonare.Interface
{
    interface IAccount
    {
        Customer Customer { get; set; }

        decimal Balance { get; set; }

        decimal InterestRate { get; set; }

        void DepositMoney(decimal money);

        decimal CalculateInterest(int months);
    }
}

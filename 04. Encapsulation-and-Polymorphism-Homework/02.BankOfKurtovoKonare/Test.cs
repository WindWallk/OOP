using System;
using BankOfKurtovoKonare.Models;

namespace _02.BankOfKurtovoKonare
{
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                Deposit deposit = new Deposit(Customer.Company, 20000m, 3.4m);
                deposit.Withdraw(345m);
                deposit.DepositMoney(1000m);
                deposit.CalculateInterest(10);
                Console.WriteLine("Deposit:\n{0}", deposit);

                Loan loanIndividual = new Loan(Customer.Individual, 1000m, 20m);
                loanIndividual.DepositMoney(3000m);
                loanIndividual.CalculateInterest(5);
                Console.WriteLine("Loan individual:\n{0}", loanIndividual);

                Loan loanCompalny = new Loan(Customer.Company, 200000m, 5m);
                loanCompalny.DepositMoney(30000m);
                loanCompalny.CalculateInterest(4);
                Console.WriteLine("Loan company:\n{0}", loanCompalny);

                Mortage mortageIndividual = new Mortage(Customer.Individual, 500, 3.3m);
                mortageIndividual.DepositMoney(200m);
                mortageIndividual.CalculateInterest(7);
                Console.WriteLine("Mortage individual:\n{0}", mortageIndividual);

                Mortage mortageCompany = new Mortage(Customer.Company, 50000, 4m);
                mortageIndividual.DepositMoney(2000m);
                mortageIndividual.CalculateInterest(13);
                Console.WriteLine("Mortage individual:\n{0}", mortageIndividual);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

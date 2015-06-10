namespace BankOfKurtovoKonare.Models
{
    class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }
            return this.InterestRate = this.Balance * (1 + this.InterestRate * months);
        }

        public void Withdraw(decimal money)
        {
            this.Balance -= money;
        }
    }
}

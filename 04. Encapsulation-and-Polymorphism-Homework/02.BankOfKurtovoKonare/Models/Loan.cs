namespace BankOfKurtovoKonare.Models
{
    class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 3 && this.Customer == Customer.Individual)
            {
                return 0;
            }
            else if (months < 2 && this.Customer == Customer.Company)
            {
                return 0;
            }
            return this.InterestRate = this.Balance * (1 + this.InterestRate * months);
        }
    }
}

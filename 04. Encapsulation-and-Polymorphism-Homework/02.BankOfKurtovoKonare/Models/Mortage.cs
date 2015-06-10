namespace BankOfKurtovoKonare.Models
{
    class Mortage : Account
    {
        public Mortage(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest = this.Balance * (1 + this.InterestRate * months);
            if (months < 6 && this.Customer == Customer.Individual)
            {
                return 0;
            }
            else if (months < 12 && this.Customer == Customer.Company)
            {
                return this.InterestRate = interest / 2;
            }
            return this.InterestRate = interest;
        }
    }
}

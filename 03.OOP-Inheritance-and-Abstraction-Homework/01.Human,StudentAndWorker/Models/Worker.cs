using System;

namespace HumanStudentWorker.Models
{
    class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, int workHoursPerDay, decimal weekSalary)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }

            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentOutOfRangeException("workHoursPerDay", "Work hours must be in the range [0...24]");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }

            set
            {
                if (weekSalary < 0m)
                {
                    throw new ArgumentOutOfRangeException("weekSalary", "The salary cannot be a negative number");
                }

                this.weekSalary = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal result = this.WeekSalary/(this.WorkHoursPerDay*5);

            return result;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("Work hours per day: {0}\nWeek salary: {1}\nMoneyPerHour: {2}\n", this.WorkHoursPerDay, this.WeekSalary, this.MoneyPerHour());
        }
    }
}

using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Models
{
    class RegularEmployee : Employee
    {
        public RegularEmployee(string id, string firstName, string lastName, Department department, decimal salary)
            : base(id, firstName, lastName, department, salary)
        {
        }
    }
}

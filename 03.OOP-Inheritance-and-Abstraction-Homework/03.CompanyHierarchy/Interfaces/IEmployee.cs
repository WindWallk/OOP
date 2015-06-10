using CompanyHierarchy.Models;

namespace CompanyHierarchy.Interfaces
{
    interface IEmployee
    {
        Department Department { get; set; }

        decimal Salary { get; set; }

        string ToString();
    }
}

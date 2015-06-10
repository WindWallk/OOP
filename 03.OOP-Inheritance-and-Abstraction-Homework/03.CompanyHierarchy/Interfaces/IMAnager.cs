using System.Collections.Generic;
using CompanyHierarchy.Models;

namespace CompanyHierarchy.Interfaces
{
    interface IManager
    {
        ISet<Employee> Employees { get; set; }

        void AddEmployees(ISet<Employee> employees);

        string ToString();
    }
}

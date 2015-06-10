using System.Collections.Generic;
using CompanyHierarchy.Models;

namespace CompanyHierarchy.Interfaces
{
    interface ISalesEmployee
    {
        ISet<Sale> Sales { get; set; }

        void AddSales(ISet<Sale> sales);

        string ToString();
    }
}

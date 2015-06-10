using System;

namespace CompanyHierarchy.Interfaces
{
    interface ISale
    {
        string ProductName { get; set; }

        DateTime SaleDate { get; set; }

        decimal ProductPrice { get; set; }
    }
}

using System.Collections.Generic;
using CompanyHierarchy.Models;

namespace CompanyHierarchy.Interfaces
{
    interface IDeveloper
    {
        ISet<Project> Projects { get; set; }

        void AddProjects(ISet<Project> projects);

        string ToString();
    }
}

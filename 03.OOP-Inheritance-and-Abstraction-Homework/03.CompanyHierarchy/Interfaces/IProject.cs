using System;
using CompanyHierarchy.Models;

namespace CompanyHierarchy.Interfaces
{
    interface IProject
    {
        string Name { get; set; }

        string Details { get; set; }

        DateTime StartDate { get; set; }

        ProjectState State { get; set; }

        void CloseProject();
    }
}

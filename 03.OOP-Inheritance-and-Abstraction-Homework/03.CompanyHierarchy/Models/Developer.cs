using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Models
{
    class Developer : RegularEmployee, IDeveloper
    {
        public Developer(string id, string firstName, string lastName, Department department, decimal salary, ISet<Project> projects = null) 
            : base(id, firstName, lastName, department, salary)
        {
            this.Projects = projects ?? new HashSet<Project>();
        }

        public ISet<Project> Projects { get; set; }

        public void AddProjects(ISet<Project> projects)
        {
            foreach (var project in projects)
            {
                Projects.Add(project);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendFormat("Open projects: {0}\n",
                this.Projects.Count(project => project.State == ProjectState.Open));
            result.AppendFormat("Closed projects: {0}\n",
                this.Projects.Count(project => project.State == ProjectState.Closed));
            return result.ToString();
        }
    }
}

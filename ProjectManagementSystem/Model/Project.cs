using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public class Project
    {
        private int id;
        private string projectName;
        private string description;
        private DateTime? startDate;
        private string status;

        // Default Constructor
        public Project() { }

        // Parameterized Constructor
        public Project(int id, string projectName, string description, DateTime? startDate, string status)
        {
            this.id = id;
            this.projectName = projectName;
            this.description = description;
            this.startDate = startDate;
            this.status = status;
        }

        // Properties (Getters and Setters)
        public int Id { get => id; set => id = value; }
        public string ProjectName { get => projectName; set => projectName = value; }
        public string Description { get => description; set => description = value; }
        public DateTime? StartDate { get => startDate; set => startDate = value; }
        public string Status { get => status; set => status = value; }
    }

}

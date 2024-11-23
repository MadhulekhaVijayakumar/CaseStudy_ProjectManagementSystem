using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public class Task
    {
        private int taskId;
        private string taskName;
        private int? projectId;
        private int? employeeId;
        private string status;

        // Default Constructor
        public Task() { }

        // Parameterized Constructor
        public Task(int taskId, string taskName, int? projectId, int? employeeId, string status)
        {
            this.taskId = taskId;
            this.taskName = taskName;
            this.projectId = projectId;
            this.employeeId = employeeId;
            this.status = status;
        }

        // Properties (Getters and Setters)
        public int TaskId { get => taskId; set => taskId = value; }
        public string TaskName { get => taskName; set => taskName = value; }
        public int? ProjectId { get => projectId; set => projectId = value; }
        public int? EmployeeId { get => employeeId; set => employeeId = value; }
        public string Status { get => status; set => status = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public class Employee
    {
        private int id;
        private string name;
        private string designation;
        private string gender;
        private decimal salary;
        private int? projectId;

        // Default Constructor
        public Employee() { }

        // Parameterized Constructor
        public Employee(int id, string name, string designation, string gender, decimal salary, int? projectId)
        {
            this.id = id;
            this.name = name;
            this.designation = designation;
            this.gender = gender;
            this.salary = salary;
            this.projectId = projectId;
        }

        // Properties (Getters and Setters)
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Designation { get => designation; set => designation = value; }
        public string Gender { get => gender; set => gender = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public int? ProjectId { get => projectId; set => projectId = value; }
    }
}

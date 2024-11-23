using System.Collections.Generic;
using ProjectManagementSystem.Exception;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Repository;

namespace ProjectManagementSystem.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool CreateEmployee(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Name) || employee.Salary <= 0)
            {
                throw new ArgumentException("Invalid employee details.");
            }
            return _employeeRepository.CreateEmployee(employee);
        }

        public bool DeleteEmployee(int userId)
        {

           
            if (userId <= 0 )
                {
                    throw new EmployeeNotFoundException("Employee with ID  does not exist.");
                }
                return _employeeRepository.DeleteEmployee(userId);
            
            

        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }
    }
}

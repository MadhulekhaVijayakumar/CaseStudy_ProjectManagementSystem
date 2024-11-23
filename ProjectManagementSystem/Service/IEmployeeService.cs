using System.Collections.Generic;
using ProjectManagementSystem.Model;

namespace ProjectManagementSystem.Service
{
    public interface IEmployeeService
    {
        bool CreateEmployee(Employee employee);
        bool DeleteEmployee(int userId);
        List<Employee> GetAllEmployees();
    }
}

using System.Collections.Generic;
using ProjectManagementSystem.Model;

namespace ProjectManagementSystem.Repository
{
    public interface IEmployeeRepository
    {
        bool CreateEmployee(Employee employee);
        bool DeleteEmployee(int userId);
        List<Employee> GetAllEmployees();
    }
}

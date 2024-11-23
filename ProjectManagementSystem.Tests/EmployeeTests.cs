using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Buffers.Text;
using System;
using ProjectManagementSystem.Service;
using ProjectManagementSystem.Repository;
using ProjectManagementSystem.Model;
namespace ProjectManagementSystem.Tests
{
    [TestFixture]

    public class EmployeeTests
    {
        private IEmployeeService _employeeService;
        private EmployeeRepository _employeeRepo;

        [SetUp]
        public void Setup()
        {
            _employeeRepo = new EmployeeRepository(); // Assume this connects to a mock database
            _employeeService = new EmployeeService(_employeeRepo);
        }

        [Test]
        public void CreateEmployee_ValidEmployee_ShouldReturnTrue()
        {
            // Arrange
            var employee = new Employee
            {
                Name = "John Doe",
                Designation = "Developer",
                Gender = "Male",
                Salary = 50000
            };

            // Act
            var result = _employeeService.CreateEmployee(employee);

            // Assert
            Assert.That(result, Is.True, "Employee creation should return true for valid input.");
        }
    }
}

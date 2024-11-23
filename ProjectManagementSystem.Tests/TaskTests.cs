using NUnit.Framework;
using ProjectManagementSystem.Repository;
using ProjectManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Tests
{
    [TestFixture]
    public class TaskTests
    {
        private ITaskService _taskService;
        private TaskRepository _taskRepo;

        [SetUp]
        public void Setup()
        {
            _taskRepo = new TaskRepository(); // Assume this connects to a mock database
            _taskService = new TaskService(_taskRepo);
        }

        [Test]
        public void CreateTask_ValidTask_ShouldReturnTrue()
        {
            // Arrange
            var task = new Model.Task
            {
                TaskName = "Code Review",
                ProjectId = 1,
                EmployeeId = 2,
                Status = "Assigned"
            };

            // Act
            var result = _taskService.CreateTask(task);

            // Assert
            Assert.That(result, Is.True, "Task creation should return true for valid input.");
        }
    }
}

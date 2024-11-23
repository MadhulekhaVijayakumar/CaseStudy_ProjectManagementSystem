using System.Collections.Generic;
using ProjectManagementSystem.Model;
using Task = ProjectManagementSystem.Model.Task;

namespace ProjectManagementSystem.Service
{
    public interface ITaskService
    {
        bool CreateTask(Task task);
        bool AssignTaskToEmployee(int taskId, int projectId, int employeeId);
        List<Task> GetAllTasksForEmployeeInProject(int employeeId, int projectId);
    }
}

using System.Collections.Generic;
using ProjectManagementSystem.Model;
using Task = ProjectManagementSystem.Model.Task;

namespace ProjectManagementSystem.Repository
{
    public interface ITaskRepository
    {
        bool CreateTask(Task task);
        bool AssignTaskToEmployee(int taskId, int projectId, int employeeId);
        List<Task> GetAllTasksForEmployeeInProject(int employeeId, int projectId);
    }
}

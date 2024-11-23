using System.Collections.Generic;
using ProjectManagementSystem.Repository;
using Task = ProjectManagementSystem.Model.Task;

namespace ProjectManagementSystem.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public bool CreateTask(Task task)
        {
            if (string.IsNullOrWhiteSpace(task.TaskName) || string.IsNullOrWhiteSpace(task.Status))
            {
                throw new ArgumentException("Invalid task details.");
            }
            return _taskRepository.CreateTask(task);
        }

        public bool AssignTaskToEmployee(int taskId, int projectId, int employeeId)
        {
            if (taskId <= 0 || projectId <= 0 || employeeId <= 0)
            {
                throw new ArgumentException("Invalid task, project, or employee ID.");
            }
            return _taskRepository.AssignTaskToEmployee(taskId, projectId, employeeId);
        }

        public List<Task> GetAllTasksForEmployeeInProject(int employeeId, int projectId)
        {
            if (employeeId <= 0 || projectId <= 0)
            {
                throw new ArgumentException("Invalid employee or project ID.");
            }
            return _taskRepository.GetAllTasksForEmployeeInProject(employeeId, projectId);
        }
    }
}

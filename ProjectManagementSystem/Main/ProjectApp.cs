using System;
using System.Collections.Generic;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Service;
using ProjectManagementSystem.Repository;
using Task = ProjectManagementSystem.Model.Task;
using ProjectManagementSystem.Exception;

namespace ProjectManagementSystem.Main
{
    public class ProjectApp
    {
        private readonly IEmployeeService _employeeService;
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;

        public ProjectApp()
        {
            // Instantiate repositories
            var employeeRepo = new EmployeeRepository();
            var projectRepo = new ProjectRepository();
            var taskRepo = new TaskRepository();

            // Instantiate services using the repositories
            _employeeService = new EmployeeService(employeeRepo);
            _projectService = new ProjectService(projectRepo);
            _taskService = new TaskService(taskRepo);
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n--- Project Management System ---");
                Console.WriteLine("1. Create Employee");
                Console.WriteLine("2. Delete Employee");
                Console.WriteLine("3. View All Employees");
                Console.WriteLine("4. Create Project");
                Console.WriteLine("5. Assign Project to Employee");
                Console.WriteLine("6. View All Projects");
                Console.WriteLine("7. Delete Project");
                Console.WriteLine("8. Create Task");
                Console.WriteLine("9. Assign Task to Employee in Project");
                Console.WriteLine("10. View All Tasks for an Employee in a Project");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Employee Name: ");
                        string empName = Console.ReadLine();
                        Console.Write("Enter Designation: ");
                        string designation = Console.ReadLine();
                        Console.Write("Enter Gender: ");
                        string gender = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        decimal salary = Convert.ToDecimal(Console.ReadLine());
                        Employee newEmployee = new Employee { Name = empName, Designation = designation, Gender = gender, Salary = salary };
                        Console.WriteLine(_employeeService.CreateEmployee(newEmployee) ? "Employee created successfully." : "Failed to create employee.");
                        break;

                    case 2:

                        try
                        {
                            Console.Write("Enter Employee ID to delete: ");
                            int empId = Convert.ToInt32(Console.ReadLine());

                            if (_employeeService.DeleteEmployee(empId))
                            {
                                Console.WriteLine("Employee deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to delete employee. Please check the employee ID and try again.");
                            }
                        }
                        catch (EmployeeNotFoundException ex)
                        {
                            // Handle specific EmployeeNotFoundException
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("All Employees:");
                        List<Employee> employees = _employeeService.GetAllEmployees();
                        foreach (var employee in employees)
                        {
                            Console.WriteLine($"{employee.Id} - {employee.Name}, {employee.Designation}, {employee.Gender}, {employee.Salary}");
                        }
                        break;

                    case 4:
                        Console.Write("Enter Project Name: ");
                        string projectName = Console.ReadLine();
                        Console.Write("Enter Description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter Start Date (YYYY-MM-DD): ");
                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter Status: ");
                        string status = Console.ReadLine();
                        Project newProject = new Project { ProjectName = projectName, Description = description, StartDate = startDate, Status = status };
                        Console.WriteLine(_projectService.CreateProject(newProject) ? "Project created successfully." : "Failed to create project.");
                        break;

                    case 5:
                        Console.Write("Enter Project ID: ");
                        int projectId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Employee ID: ");
                        int assignEmpId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(_projectService.AssignProjectToEmployee(projectId, assignEmpId) ? "Project assigned successfully." : "Failed to assign project.");
                        break;

                    case 6:
                        Console.WriteLine("All Projects:");
                        List<Project> projects = _projectService.GetAllProjects();
                        foreach (var project in projects)
                        {
                            Console.WriteLine($"{project.Id} - {project.ProjectName}, {project.Description}, {project.StartDate}, {project.Status}");
                        }
                        break;

                    case 7:
                        Console.Write("Enter Project ID to delete: ");
                        int delProjectId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(_projectService.DeleteProject(delProjectId) ? "Project deleted successfully." : "Failed to delete project.");
                        break;

                    case 8:
                        Console.Write("Enter Task Name: ");
                        string taskName = Console.ReadLine();
                        Console.Write("Enter Project ID: ");
                        int taskProjectId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Employee ID: ");
                        int taskEmpId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Status: ");
                        string taskStatus = Console.ReadLine();
                        Task newTask = new Task { TaskName = taskName, ProjectId = taskProjectId, EmployeeId = taskEmpId, Status = taskStatus };
                        Console.WriteLine(_taskService.CreateTask(newTask) ? "Task created successfully." : "Failed to create task.");
                        break;

                    case 9:
                        Console.Write("Enter Task ID: ");
                        int taskId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Project ID: ");
                        int assignTaskProjId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Employee ID: ");
                        int assignTaskEmpId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(_taskService.AssignTaskToEmployee(taskId, assignTaskProjId, assignTaskEmpId) ? "Task assigned successfully." : "Failed to assign task.");
                        break;

                    case 10:
                        Console.Write("Enter Employee ID: ");
                        int taskEmp = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Project ID: ");
                        int taskProj = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Tasks assigned to the employee in the project:");
                        List<Task> tasks = _taskService.GetAllTasksForEmployeeInProject(taskEmp, taskProj);
                        foreach (var task in tasks)
                        {
                            Console.WriteLine($"{task.TaskId} - {task.TaskName}, {task.Status}");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}


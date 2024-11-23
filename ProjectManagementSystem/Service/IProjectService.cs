using System.Collections.Generic;
using ProjectManagementSystem.Model;

namespace ProjectManagementSystem.Service
{
    public interface IProjectService
    {
        bool CreateProject(Project project);
        bool AssignProjectToEmployee(int projectId, int employeeId);
        List<Project> GetAllProjects();
        bool DeleteProject(int projectId);
    }
}

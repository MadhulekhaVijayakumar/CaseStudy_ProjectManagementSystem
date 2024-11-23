using System.Collections.Generic;
using ProjectManagementSystem.Model;

namespace ProjectManagementSystem.Repository
{
    public interface IProjectRepository
    {
        bool CreateProject(Project project);
        bool AssignProjectToEmployee(int projectId, int employeeId);
        List<Project> GetAllProjects();
        bool DeleteProject(int projectId);
    }
}

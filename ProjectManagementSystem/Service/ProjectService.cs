using System.Collections.Generic;
using ProjectManagementSystem.Exception;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Repository;

namespace ProjectManagementSystem.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public bool CreateProject(Project project)
        {
            if (string.IsNullOrWhiteSpace(project.ProjectName) || string.IsNullOrWhiteSpace(project.Status))
            {
                throw new ArgumentException("Invalid project details.");
            }
            return _projectRepository.CreateProject(project);
        }

        public bool AssignProjectToEmployee(int projectId, int employeeId)
        {
            if (projectId <= 0 || employeeId <= 0)
            {
                throw new ArgumentException("Invalid project or employee ID.");
            }
            return _projectRepository.AssignProjectToEmployee(projectId, employeeId);
        }

        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }

        public bool DeleteProject(int projectId)
        {
            try
            {
                if (projectId <= 0)
                {
                    throw new ProjectNotFoundException($"Project with ID {projectId} does not exist.");
                }
                return _projectRepository.DeleteProject(projectId);
            }
            catch (ProjectNotFoundException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

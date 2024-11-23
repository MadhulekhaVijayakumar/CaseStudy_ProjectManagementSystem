using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Utility;

namespace ProjectManagementSystem.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        public bool CreateProject(Project project)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                const string query = "INSERT INTO Project (ProjectName, Description, StartDate, Status) VALUES (@ProjectName, @Description, @StartDate, @Status)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                    command.Parameters.AddWithValue("@Description", project.Description);
                    command.Parameters.AddWithValue("@StartDate", project.StartDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Status", project.Status);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AssignProjectToEmployee(int projectId, int employeeId)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                const string query = "UPDATE Employee SET ProjectId = @ProjectId WHERE Id = @EmployeeId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Project> GetAllProjects()
        {
            var projects = new List<Project>();
            using (var connection = DBConnUtil.GetConnection())
            {
                const string query = "SELECT * FROM Project";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projects.Add(new Project
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ProjectName = reader["ProjectName"].ToString(),
                                Description = reader["Description"].ToString(),
                                StartDate = reader["StartDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["StartDate"]),
                                Status = reader["Status"].ToString()
                            });
                        }
                    }
                }
            }
            return projects;
        }

        public bool DeleteProject(int projectId)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                const string query = "DELETE FROM Project WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", projectId);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}

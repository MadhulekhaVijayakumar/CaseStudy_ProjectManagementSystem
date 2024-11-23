using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ProjectManagementSystem.Utility;
using Task = ProjectManagementSystem.Model.Task;

namespace ProjectManagementSystem.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public bool CreateTask(Task task)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                const string query = "INSERT INTO Task (task_name, project_id, employee_id, Status) VALUES (@TaskName, @ProjectId, @EmployeeId, @Status)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaskName", task.TaskName);
                    command.Parameters.AddWithValue("@ProjectId", task.ProjectId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@EmployeeId", task.EmployeeId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Status", task.Status);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AssignTaskToEmployee(int taskId, int projectId, int employeeId)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                const string query = "UPDATE Task SET project_id = @ProjectId, employee_id = @EmployeeId WHERE task_id = @TaskId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaskId", taskId);
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Task> GetAllTasksForEmployeeInProject(int employeeId, int projectId)
        {
            var tasks = new List<Task>();
            using (var connection = DBConnUtil.GetConnection())
            {
                const string query = "SELECT * FROM Task WHERE employee_id = @EmployeeId AND project_id = @ProjectId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@ProjectId", projectId);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add(new Task
                            {
                                TaskId = Convert.ToInt32(reader["task_id"]), // Update column name
                                TaskName = reader["task_name"].ToString(),  // Update column name
                                ProjectId = reader["project_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["project_id"]), // Update column name
                                EmployeeId = reader["employee_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["employee_id"]), // Update column name
                                Status = reader["status"].ToString() // Update column name
                            });
                        }
                    }
                }
            }
            return tasks;
        }
    }
}

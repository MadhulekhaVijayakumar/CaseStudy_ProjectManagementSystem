using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Utility;

namespace ProjectManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool CreateEmployee(Employee employee)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                // Get the highest current ID from the Employee table
                string getMaxIdQuery = "SELECT MAX(id) FROM Employee";
                int newId;

                using (var command = new SqlCommand(getMaxIdQuery, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    newId = result == DBNull.Value ? 1 : Convert.ToInt32(result) + 1;
                }

                // insert the employee with the generated id
                const string query = "INSERT INTO Employee (id, Name, Designation, Gender, Salary, ProjectId) " +
                                     "VALUES (@Id, @Name, @Designation, @Gender, @Salary, @ProjectId)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", newId);  
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Designation", employee.Designation);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@ProjectId", (object)employee.ProjectId ?? DBNull.Value);

                    connection.Close();
                    connection.Open();
                    return command.ExecuteNonQuery() > 0; 
                }
            }
        }


        public bool DeleteEmployee(int userId)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                // Check if tasks exist
                const string checkTasksQuery = "SELECT COUNT(*) FROM Task WHERE employee_id = @EmployeeId";
                const string deleteEmployeeQuery = "DELETE FROM Employee WHERE Id = @Id";

                connection.Open();

                using (var checkCommand = new SqlCommand(checkTasksQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@EmployeeId", userId);
                    int taskCount = (int)checkCommand.ExecuteScalar();

                    if (taskCount > 0)
                    {
                        // Prevent deletion if tasks exist
                        return false;
                    }
                }

                using (var deleteCommand = new SqlCommand(deleteEmployeeQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@Id", userId);
                    return deleteCommand.ExecuteNonQuery() > 0;
                }
            }
        }


        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            using (var connection = DBConnUtil.GetConnection())
            {
                const string query = "SELECT * FROM Employee";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Designation = reader["Designation"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                Salary = Convert.ToDecimal(reader["Salary"]),
                                ProjectId = reader["ProjectId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ProjectId"])
                            });
                        }
                    }
                }
            }
            return employees;
        }
    }
}

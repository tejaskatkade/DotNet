using Model;
using MySql.Data.MySqlClient;

namespace Repository
{
    public class EmployeeRepository : IEmpolyeeRepository
    {
        private string connnectionStirng = "server=localhost;database=dotnet_test;user=root;password=student";
        
        public bool AddPerson(Employee employee)
        { 
            bool res = false;

            string query = "INSERT INTO employees (Name,Age,Department,Designation,Salary) VALUES (@Name,@Age,@Department,@Designation,@Salary)";
            using (MySqlConnection connection = new MySqlConnection(connnectionStirng))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                //command.Parameters.AddWithValue("@ID", employee.Id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@Salary", employee.Salary);

                if (command.ExecuteNonQuery() > 0)
                { 
                    res = true; 
                }

            }
            return res;
        }

        public bool DeletePerson(int id)
        {
            bool res = false;

            string query = "DELETE FROM employees  WHERE Id = @Id";

            using (MySqlConnection connection = new MySqlConnection(connnectionStirng))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                if(command.ExecuteNonQuery() > 0)
                {
                    res = true;
                }
            }
            return res;
        }

        public Employee GetPerson(int id)
        {

            string query = "SELECT * FROM employees WHERE Id = @Id";
            Employee employee  = new Employee();
            using (MySqlConnection connection = new MySqlConnection(connnectionStirng))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    employee.Id = reader.GetInt32("Id");
                    employee.Name = reader.GetString("Name");
                    employee.Age = reader.GetInt32("Age");
                    employee.Designation = reader.GetString("Designation");
                    employee.Department = reader.GetString("Department");
                    employee.Salary = reader.GetFloat("Salary");
                }
            }
            return employee;
        }

        public List<Employee> GetPersons()
        {
            string query = "SELECT * FROM employees";
            List<Employee> employees = new List<Employee>();
            using (MySqlConnection connection = new MySqlConnection(connnectionStirng))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = reader.GetInt32("Id");
                    employee.Name = reader.GetString("Name");
                    employee.Age = reader.GetInt32("Age");
                    employee.Designation = reader["Designation"].ToString();
                    employee.Department = reader.GetString("Department");
                    employee.Salary = reader.GetFloat("Salary");

                    Console.WriteLine(employee.Designation);
                    employees.Add(employee);
                }
                
            }
            return employees;

        }

        public bool UpdatePerson(Employee employee)
        {
            bool res = false;

            string query = "UPDATE employees SET Name = @Name,Age = @Age,Department = @Department,Designation = @Designation,Salary = @Salary WHERE Id = @Id";
            //string query = "update employees set Name = @Name, Age = @Age, Department = @Department, Designation = @Designation, Salary = @Salary where Id = @Id";


            using (MySqlConnection connection = new MySqlConnection(connnectionStirng))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                
                if(command.ExecuteNonQuery() > 0)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}

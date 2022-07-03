using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using NathansCRUDWebsite.Models;


namespace NathansCRUDWebsite
{
    public class EmployeeRepo
    {
        public static string connectionString = ProductRepo.connectionString;

        

        public List<Employees> GetEmployees()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT EmployeeID, FirstName, LastName, EmailAddress, DateOfBirth FROM employees;";

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Employees> employees = new List<Employees>();
                while (reader.Read())
                {
                    Employees row = new Employees();
                    row.EmployeeID = reader.GetInt32("EmployeeID");
                    row.FirstName = reader.GetString("FirstName");

   
                   row.LastName = reader.GetString("LastName");
                    

                 
                    
                   row.EmailAddress = reader.GetString("EmailAddress");



                    row.DateOfBirth = reader.GetDateTime("DateOfBirth");
                    

               

                    employees.Add(row);
                }
                return employees;
            }
        }

        public void CreateEmployees(Employees e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO employees(EmployeeID, FirstName, LastName, EmailAddress, DateOfBirth) VALUES(@empID, @first, @last, @email, @dob);";
                cmd.Parameters.AddWithValue("empID", e.EmployeeID);
                cmd.Parameters.AddWithValue("first", e.FirstName);
                cmd.Parameters.AddWithValue("last", e.LastName);
                cmd.Parameters.AddWithValue("email", e.EmailAddress);
                cmd.Parameters.AddWithValue("dob", e.DateOfBirth);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employees e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE employees SET FirstName=@first, LastName=@last, EmailAddress=@email, DateOfBirth=@dob " +
                    " WHERE EmployeeID=@id;";
                cmd.Parameters.AddWithValue("first", e.FirstName);
                cmd.Parameters.AddWithValue("last", e.LastName);
                cmd.Parameters.AddWithValue("email", e.EmailAddress);
                cmd.Parameters.AddWithValue("dob", e.DateOfBirth);
                cmd.Parameters.AddWithValue("id", e.EmployeeID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM employees WHERE EmployeeID=@id;";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

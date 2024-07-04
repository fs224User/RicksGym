using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EmployeeManagement;
using Oracle.ManagedDataAccess.Client;

namespace EmployeeManagement.Helper;

public static class DatabaseHelper
{
    private static readonly string _ConnectionString = "Data Source=db-server.s-atiw.de:1521/atiwora;User ID=FS224_rhartmann;Password=rick;";

    public static Employee GetEmployeeByID(Guid Id)
    {
        StringBuilder builder = new();
        try
        {
            using var _Connection = new OracleConnection(_ConnectionString);
            _Connection.Open();

            using OracleCommand command = new();
            command.CommandText = $"SELECT EMPLOYEE FROM GYM_PERSONAL WHERE EMPLOYEE.ID = {Id}";

            using var execution = command.ExecuteReader();


            while (execution.Read())
            {
                for (byte i = 0; i < execution.FieldCount; i++)
                {
                    builder.AppendLine(execution.GetString(i) + ";");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new Employee(builder.ToString());
    }

    public static List<Employee> GetAllEmployees()
    {
        var employees = new List<Employee>();
        try
        {
            StringBuilder builder = new();
            using (var Connection = new OracleConnection(_ConnectionString))
            {
                using var Command = new OracleCommand("SELECT * FROM GYM_PERSONAL", Connection);
                Command.Connection.Open();
                var execution = Command.ExecuteReader();
                while (execution.Read())
                {
                    for (byte i = 0; i < execution.FieldCount; i++)
                    {
                        builder.Append(execution.GetString(i) + ";");
                    }

                    employees.Add(new Employee(builder.ToString()));
                    builder.Clear();
                }
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "\n" + ex.GetType());
        }
        return employees;
    }

    public static void InsertEmployeeInDatabase(Employee employee)
    {
        try
        {
            //"ID;FirstName;LastName;Email;Telephone;JobTitle;Salary;IBAN;Gender;Address;Birthdate;StartDate"
            using var Connection = new OracleConnection(_ConnectionString);
            using var Command = new OracleCommand($"INSERT INTO GYM_PERSONAL \nVALUES ({employee.ToSqlRepresentation()})", Connection);
            Command.Connection.Open();
            Command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message+"\n");
        }
    }

    public static void DeleteUserFromDatabase(Employee employee)
    {
        try
        {
            using var Connection = new OracleConnection(_ConnectionString);
            Connection.Open();
            using var Command = new OracleCommand();
            Command.CommandText = $"DELETE FROM GYM_PERSONAL WHERE TRAINER_ID = {employee.ID}";
            Command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
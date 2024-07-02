using System;
using System.Data;
using System.Linq;
using System.Text;
using EmployeeManagement.Entities;
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
            using var Connection = new OracleConnection(_ConnectionString);
            Connection.Open();
            using var Command = new OracleCommand();
            Command.CommandText = "SELECT * FROM GYM_PERSONAL";
            var execution = Command.ExecuteReader();
            StringBuilder builder = new();

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

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return employees;
    }

    public static void WriteEmployeeToDatabase(Employee employee)
    {
        try
        {
            using var Connection = new OracleConnection(_ConnectionString);
            Connection.Open();
            using var Command = new OracleCommand();
            Command.CommandText = $"INSERT INTO GYM_PERSONAL VALUES ({employee.ToSqlRepresentation()})";
            Command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
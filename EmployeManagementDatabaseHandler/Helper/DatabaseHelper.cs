using System.Data;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using EmployeeManagement.Entities;
using System.Text;

namespace EmployeeManagement.Helper;

public static class DatabaseHelper
{
    private static string _ConnectionString { get; set; } = "";

    public static Employee GetEmployeeByID(Guid Id)
    {
        using var _Connection = new OracleConnection(_ConnectionString);
        _Connection.Open();

        using OracleCommand command = new();
        command.CommandText = $"SELECT EMPLOYEE FROM GYM_PERSONAL WHERE EMPLOYEE.ID = {Id}";

        using var execution = command.ExecuteReader();

        StringBuilder builder = new();

        while (execution.Read())
        {
            for (byte i = 0; i < execution.FieldCount; i++)
            {
                builder.AppendLine(execution.GetString(i) + ";");
            }
        }

        return new Employee(builder.ToString());

    }
}
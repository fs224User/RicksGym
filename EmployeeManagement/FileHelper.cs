using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EmployeeManagement;

namespace EmployeeManagement;

public static class FileHelper
{
    private static readonly string _HeaderRow = "ID;FirstName;LastName;Email;Phone;JobTitle;Salary;IBAN;Gender;ZipCode;Street;HouseNumber";

    private static readonly string _FileStore = $"C:/Users/{Environment.UserName}/Downloads/ExportedUsers.csv";

    public static void ExportToCSV(string path, List<Employee> employees)
    {
        using var _Writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite));
        var _Builder = new StringBuilder();
        _Builder.AppendLine(_HeaderRow);
        foreach (var e in employees)
        {
            _Builder.AppendLine(e.ToCsvString());
        }

        using (_Writer) { _Writer.Write(_Builder.ToString()); }
    }

    public static List<Employee> ImportFromCSV(string path)
    {
        using var _Reader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));

        var employees = new List<Employee>();
        using (_Reader)
        {
            var _ = _Reader.ReadLine();
            while (!_Reader.EndOfStream)
            {
                var employee = _Reader.ReadLine();
                employees.Add(new Employee(employee));
            }
        }

        return employees;
    }
}

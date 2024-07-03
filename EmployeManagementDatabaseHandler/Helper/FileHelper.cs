using System.Text;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Helper;

public static class FileHelper
{
    private static readonly string _HeaderRow = "ID;FirstName;LastName;Email;Telephone;JobTitle;Salary;IBAN;Gender;Address;Birthdate;StartDate";

    private static readonly string _FileStore = $"C:/Users/{Environment.UserName}/Downloads/ExportedUsers.csv";

    public static void ExportToCSV(string path, List<Employee> employees)
    {
        using var _Writer = new StreamWriter(new FileStream(_FileStore, FileMode.OpenOrCreate, FileAccess.ReadWrite));
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
        using var _Reader = new StreamReader(new FileStream(_FileStore, FileMode.Open, FileAccess.Read));

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

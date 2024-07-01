using System.Text;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Helper;

public static class FileHelper
{
    private static readonly string _HeaderRow = "ID;FirstName;LastName;Email;Telephone;JobTitle;Salary;IBAN;Gender;Address;Birthdate;StartDate";

    private static readonly StringBuilder _Builder = new StringBuilder();

    private static readonly string _FileStore = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

    private static readonly StreamWriter _Writer = new (new FileStream(_FileStore, FileMode.Open, FileAccess.Read));


    public static void ExportToCSV(string path, List<Employee> employees)
    {
        throw new NotImplementedException();
        _Builder.AppendLine(_HeaderRow);
        foreach (var e in employees)
        {

        }


        _Builder.Clear();
    }

    public static List<Employee> ImportFromCSV(string path)
    {
        throw new NotImplementedException();
    }
}

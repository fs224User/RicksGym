using EmployeeManagement.Entities;
using EmployeeManagement.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement;

internal class Program
{
    public static void Main()
    {
        var idFactory = Guid.NewGuid();
        List<Employee> list = new List<Employee>();
        for (int i = 0; i < 100; i++)
        {
            list.Add(new Employee(Guid.NewGuid(), $"vorname{i}", $"nachname{i}", (byte)i, "m", $"asidjh@{i}.de", "0123/45678910", $"Position{i}", $"Address{i}", $"DE{i}", 12345.23));
        }

        FileHelper.ExportToCSV(@"C:\Users\tim.zander\Downloads", list);
    }
    
}

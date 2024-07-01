namespace EmployeeManagement.Entities;

public class Employee
{
    private Guid _ID { get; set; }

    private string _FirstName { get; set; }

    private string _LastName { get; set; }

    private byte _Age { get; set; }

    private string _Gender { get; set; }

    private string _Email { get; set; }

    private string _Phone { get; set; }

    private string _JobTitle { get; set; }

    private string _Address { get; set; }

    private string _IBAN { get; set; }

    private double _Salary { get; set; }

    public Employee(string CsvRepresentation)
    {
        var data = CsvRepresentation.Split(";");
        _ID = Guid.Parse(data[0]);
        _FirstName = data[1];
        _LastName = data[2];
        _Age = byte.Parse(data[3]);
        _Gender = data[4];
        _Email = data[5];
        _Phone = data[6];
        _JobTitle = data[7];
        _Address = data[8];
        _IBAN = data[9];
        _Salary = double.Parse(data[10]);
    }

    public Employee(string guid, string firstName, string lastName, byte age, string gender, string email, string phone, string jobTitle, string address, string iban, double salary)
    {
        _ID = Guid.Parse(guid);
        _FirstName = firstName;
        _LastName = lastName;
        _Age = age;
        _Gender = gender;
        _Email = email;
        _Phone = phone;
        _JobTitle = jobTitle;
        _Address = address;
        _IBAN = iban;
        _Salary = salary;
    }

    public string ToCsvString()
    {
        return $"{_ID};{_FirstName};{_LastName};{_Age};{_Gender};{_Email};{_Phone};{_JobTitle};{_Address};{_IBAN};{_Salary}";
    }
}

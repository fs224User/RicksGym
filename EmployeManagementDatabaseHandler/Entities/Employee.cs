namespace EmployeeManagement.Entities;

public class Employee
{
    private Guid _ID;
    public Guid ID { get => _ID; set => _ID = value; }
    
    private string _FirstName;
    public string FirstName { get => _FirstName; set => _FirstName = value; }

    private string _LastName;
    public string LastName { get => _LastName; set => _LastName = value; }

    private byte _Age;
    public byte Age { get => _Age; set => _Age = value; }

    private string _Gender;
    public string Gender { get => _Gender; set => _Gender = value; }

    private string _Email;
    public string Email { get => _Email; set => _Email = value; }

    private string _Phone;
    public string Phone { get => _Phone; set => _Phone = value; }

    private string _JobTitle;
    public string JobTitle { get => JobTitle; set => JobTitle = value; }

    private string _Address;
    public string Address { get => _Address; set => _Address = value; }

    private string _IBAN;
    public string IBAN { get => _IBAN; set => _IBAN = value; }

    private double _Salary;
    public double Salary { get => _Salary; set => _Salary = value; }

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

    public Employee(Guid guid, string firstName, string lastName, byte age, string gender, string email, string phone, string jobTitle, string address, string iban, double salary)
    {
        _ID = guid;
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
        return $"{ID};{FirstName};{LastName};{Age};{Gender};{Email};{Phone};{JobTitle};{Address};{IBAN};{Salary}";
    }

    public string ToSqlRepresentation()
    {
        return $"{ID},{FirstName},{LastName},{Age},{Gender},{Email},{Phone},{JobTitle},{Address},{IBAN},{Salary}";
    }
}

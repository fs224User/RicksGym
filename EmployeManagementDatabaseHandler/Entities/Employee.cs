using System.IO;
using System.Reflection.Emit;

namespace EmployeeManagement.Entities;

public class Employee
{
    private string _TrainerID; // Only for mock data purposes
    public string TrainerID { get => _TrainerID; set => _TrainerID = value; }

    private Guid? _ID;
    public Guid? ID { get => _ID; set => _ID = value; }

    //private string _ID;
    //public string ID { get => _ID; set => _ID = value; }

    private string _FirstName;
    public string FirstName { get => _FirstName; set => _FirstName = value; }

    private string _LastName;
    public string LastName { get => _LastName; set => _LastName = value; }

    private DateOnly _HiringDate;
    public DateOnly HiringDate { get => _HiringDate; set => _HiringDate = value; }

    private string _Gender;
    public string Gender { get => _Gender; set => _Gender = value; }

    private string _Email;
    public string Email { get => _Email; set => _Email = value; }

    private string _Phone;
    public string Phone { get => _Phone; set => _Phone = value; }

    private string _JobTitle;
    public string JobTitle { get => _JobTitle; set => _JobTitle = value; }

    private string _Address;
    public string Address { get => _Address; set => _Address = value; }

    private string _IBAN;
    public string IBAN { get => _IBAN; set => _IBAN = value; }

    private double _Salary;
    public double Salary { get => _Salary; set => _Salary = value; }

    private string _ZipCode;
    public string ZipCode { get => _ZipCode; set => _ZipCode = value; }

    private string _Street;
    public string Street { get => _Street; set => _Street = value; }

    private string _HouseNumber;
    public string HouseNumber { get => _HouseNumber; set => _HouseNumber = value; }


    //$"'{ID}','{FirstName}','{LastName}','{Email}','{Phone}','{JobTitle}',{Salary},'{IBAN}','{Gender}', '{HiringDate}','{ZipCode}','{Street}','{HouseNumber}'";
    public Employee(string CsvRepresentation)
    {
        var data = CsvRepresentation.Split(";");
        _ID = Guid.Parse(data[0]);
        _FirstName = data[1];
        _LastName = data[2];
        _Email = data[3];
        _Phone = data[4];
        _JobTitle = data[5];
        _Salary = double.Parse(data[6]);
        _IBAN = data[7];
        _Gender = data[8];
        _HiringDate = DateOnly.Parse(data[9]);
        _ZipCode = data[10];
        _Street = data[11];
        _HouseNumber = data[12];
    }
    
    public Employee(string guid, string firstName, string lastName, DateOnly HiringDate, string gender, string email, string phone, string jobTitle, string zipCode, string street, string houseNumber, string iban, double salary)
    {
        _ID = Guid.Parse(guid);
        _FirstName = firstName;
        _LastName = lastName;
        _Email = email;
        _Phone = phone;
        _JobTitle = jobTitle;
        _Salary = salary;
        _IBAN = iban;
        _Gender = gender;
        _HiringDate = HiringDate;
        _ZipCode = zipCode;
        _Street = street;
        _HouseNumber = houseNumber;
    }

    public Employee(Guid guid, string firstName, string lastName, DateOnly HiringDate, string gender, string email, string phone, string jobTitle, string address, string iban, double salary, string zipCode, string street, string houseNumber)
    {
        _ID = guid;
        _FirstName = firstName;
        _LastName = lastName;
        _Email = email;
        _Phone = phone;
        _JobTitle = jobTitle;
        _Salary = salary;
        _IBAN = iban;
        _Gender = gender;
        _HiringDate = HiringDate;
        _ZipCode = zipCode;
        _Street = street;
        _HouseNumber = houseNumber;
    }

    public Employee(string guid, string firstName, string lastName, DateOnly HiringDate, string gender, string email, string phone, string jobTitle, string address, string iban, double salary, string zipCode, string street, string houseNumber)
    {
        _TrainerID = guid;
        _FirstName = firstName;
        _LastName = lastName;
        _Email = email;
        _Phone = phone;
        _JobTitle = jobTitle;
        _Salary = salary;
        _IBAN = iban;
        _Gender = gender;
        _HiringDate = HiringDate;
        _ZipCode = zipCode;
        _Street = street;
        _HouseNumber = houseNumber;
    }

    public string ToCsvString()
    {
        return $"{ID};{FirstName};{LastName};{Email};{Phone};{JobTitle};{Salary};{IBAN};{Gender};{ZipCode};{Street};{HouseNumber}";
    }

    public string ToSqlRepresentation()
    {
        return $"'{(ID.ToString()) ?? TrainerID}','{FirstName}','{LastName}','{Email}','{Phone}','{JobTitle}',{Salary},'{IBAN}','{Gender}','{ZipCode}','{Street}','{HouseNumber}'";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundenuebersicht.Model
{
    public class Customer
    {
        private Guid memberid;
        private string lastname;
        private string firstname;
        private DateTime birthday;
        private string street;
        private int housenumber;
        private string city;
        private int postalCode;
        private string email;
        private string phonenumber;
        private string iban;
        //private Kurs kurs;
        private Contract contract;


        public Customer(string lastname, string firstname, DateTime birthday, string street, int housenumber, string city, int postalCode, string email, string phonenumber, string iban, string contract, double amount, DateTime startDate)
        { 
            this.memberid = Guid.NewGuid();
            this.lastname = lastname;
            this.firstname = firstname;
            this.birthday = birthday;
            this.street = street;
            this.housenumber = housenumber;
            this.city = city;
            this.postalCode = postalCode;
            this.email = email;
            this.phonenumber = phonenumber;
            this.iban = iban;
            this.contract = new Contract(contract, amount, startDate);
        }

        public Guid MemberID { get => memberid; set => memberid = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string Street { get => street; set => street = value; }
        public int Housenumber { get => housenumber; set => housenumber = value; }
        public string City { get => city; set => city = value; }
        public int PostalCode { get => postalCode; set => postalCode = value; }
        public string Email { get => email; set => email = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Iban { get => iban; set => iban = value; }
        public Contract Contract { get => contract; set => contract = value; }

        public override string ToString()
        {
            return $"{this.Lastname}, {this.firstname}";
        }
    }
}

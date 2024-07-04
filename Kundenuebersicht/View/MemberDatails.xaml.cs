using Kundenuebersicht.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kundenuebersicht.View
{
    /// <summary>
    /// Interaktionslogik für MemberDatails.xaml
    /// </summary>
    public partial class MemberDatails : Window
    {
        public MemberDatails(List<Customer> lk, Guid id)
        {
            InitializeComponent();

            foreach(Customer k in lk)
            {
                if (k.MemberID == id)
                {
                    txt_name.Content = $"{k.Firstname} {k.Lastname}";
                    txt_adress_street.Content = k.Street;
                    txt_adress_housenumber.Content = k.Housenumber;
                    txt_adress_city.Content = k.City;
                    txt_adress_zipcode.Content = k.PostalCode;
                    string[] birthdaydate = k.Birthday.ToString().Split(' ');
                    txt_name_Kopieren.Content = birthdaydate[0];
                    txt_contact_phonenumber.Content = k.Phonenumber;
                    txt_contact_email.Content = k.Email;
                    txt_iban.Content = k.Iban;
                    txt_contract.Content = k.Contract.ToString();

                }
            }
            
        }



    }
}

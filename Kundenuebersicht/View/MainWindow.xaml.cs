using Kundenuebersicht.Model;
using Kundenuebersicht.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kundenuebersicht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Customer> lk = new List<Customer>();

        public MainWindow()
        {
            InitializeComponent();
            lk.Add(new Customer("abc", "def", new DateTime(2041, 11, 25), "street", 4, "city", 1234,"email", "12354687", "DE464854", "Basic", 14.55, new DateTime(2001, 10, 25)));
            lk.Add(new Customer("hey", "ho", new DateTime(2031, 11, 25), "street", 11, "city", 1234, "email", "12354687", "DE464854", "Pro", 14.55, new DateTime(2001, 10, 25)));
            foreach (Customer k in lk)
            {
                listbox_member.Items.Add(k);
            }
            
        }



        private void btnSearchClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnSortClick(object sender, RoutedEventArgs e)
        {

        }

        private void listbox_member_clicked(object sender, MouseButtonEventArgs e)
        {
            var member = (Customer)listbox_member.SelectedItem;
            var id = member.MemberID;

            var window = new MemberDatails(lk, id);
            window.Show();
        }

        
    }
}

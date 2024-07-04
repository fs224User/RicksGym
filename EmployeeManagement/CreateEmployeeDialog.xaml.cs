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

namespace EmployeeManagement
{
    /// <summary>
    /// Interaktionslogik für CreateEmployeeDialog.xaml
    /// </summary>
    public partial class CreateEmployeeDialog : Window
    {
        private MainWindow mainWindow;
        public CreateEmployeeDialog(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CreateEmployee(
                new Employee(
                    Guid.NewGuid(),
                    tbFirstname.Text,
                    tbLastname.Text,
                    DateOnly.FromDateTime(dpHiringDate.SelectedDate ?? DateTime.Now),
                    tbGender.Text,
                    tbEmail.Text,
                    tbPhone.Text,
                    tbJobtitle.Text,
                    tbAddress.Text,
                    tbIban.Text,
                    double.Parse(tbSalary.Text == "" ? "0" : tbSalary.Text),
                    "zip",
                    "street",
                    "house"
                    )
                );
            this.Close();
        }
    }
}

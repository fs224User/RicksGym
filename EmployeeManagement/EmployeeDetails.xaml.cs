using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaktionslogik für EmployeeDetails.xaml
    /// </summary>
    public partial class EmployeeDetails : Window
    {
        private MainWindow mainWindow;
        private Guid employeeID;
        private bool editMode = false;

        public EmployeeDetails(MainWindow mainWindow, Employee employee)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.employeeID = employee.ID ?? Guid.NewGuid();
            tbFirstname.Text = employee.FirstName;
            tbLastname.Text = employee.LastName;
            tbJobtitle.Text = employee.JobTitle;
            tbHiringDate.Text = employee.HiringDate.ToString();
            tbGender.Text = employee.Gender;
            tbEmail.Text = employee.Email;
            tbPhone.Text = employee.Phone;
            tbSalary.Text = employee.Salary.ToString();
            tbIban.Text = employee.IBAN;
        }



        void EmployeeDetails_Closing(object sender, CancelEventArgs e)
        {
            //mainWindow.Refresh();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!editMode)
            {
                tbFirstname.IsEnabled = true;
                tbLastname.IsEnabled = true;
                tbJobtitle.IsEnabled = true;
                tbHiringDate.IsEnabled = true;
                tbGender.IsEnabled = true;
                tbEmail.IsEnabled = true;
                tbPhone.IsEnabled = true;
                tbSalary.IsEnabled = true;
                tbIban.IsEnabled = true;
                btnEdit.Content = "Speichern";
                this.editMode = true;
            }
            else if (editMode)
            {
                btnEdit.Content = "Edit";
                tbFirstname.IsEnabled = false;
                tbLastname.IsEnabled = false;
                tbJobtitle.IsEnabled = false;
                tbHiringDate.IsEnabled = false;
                tbGender.IsEnabled = false;
                tbEmail.IsEnabled = false;
                tbPhone.IsEnabled = false;
                tbSalary.IsEnabled = false;
                tbIban.IsEnabled = false;

                //DbHelper.Update();

                //

                this.editMode = false;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ConfirmDialog confirmDialog = new ConfirmDialog(this);
            bool? result = confirmDialog.ShowDialog();
            if(result == true)
            {
                List<Employee> employees = (List<Employee>)this.mainWindow.lvEmployee.ItemsSource!;
                employees.RemoveAll(e => e.ID == this.employeeID);
                this.mainWindow.lvEmployee.ItemsSource = employees;
                this.mainWindow.lvEmployee.Items.Refresh();
                this.Close();
                //DbHelper.Delete();
            }
        }
    }
}

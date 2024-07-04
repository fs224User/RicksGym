using EmployeeManagement.Helper;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //List<Employee> mock = new List<Employee>();
            //mock.Add(new Employee(Guid.NewGuid(), "Leon", "Disselnmeyer", DateOnly.FromDateTime(DateTime.Now), "m", "leon.d@mail.com", "187420691337", "IT", "iland of nonya", "DE123456789101112", 3, "33106", "nesthauser", "1b"));
            //lvEmployee.ItemsSource = mock;

            lvEmployee.ItemsSource = DatabaseHelper.GetAllEmployees();

        }

        public void CreateEmployee(Employee employee)
        {
            List<Employee> employees = (List<Employee>)lvEmployee.ItemsSource;
            employees.Add(employee);
            lvEmployee.ItemsSource = employees;
            lvEmployee.Items.Refresh();
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployeeDialog dialog = new CreateEmployeeDialog(this);
            dialog.ShowDialog();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV Files (*.csv)|*.csv";
            bool? result = fileDialog.ShowDialog();
            if(result == true)
            {
                lvEmployee.ItemsSource = FileHelper.ImportFromCSV(fileDialog.FileName);
                
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Personal"; // Default file name
            dialog.DefaultExt = ".csv"; // Default file extension
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            bool? result = dialog.ShowDialog();
            if(result == true)
            {
                FileHelper.ExportToCSV(dialog.FileName, (List<Employee>)lvEmployee.ItemsSource);
            }
        }

        private void lvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee employee = (Employee)lvEmployee.SelectedItem;
            if(employee != null)
            {
                EmployeeDetails employeeDetails = new EmployeeDetails(this, employee);
                employeeDetails.ShowDialog();
            }
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                Employee employee = (Employee)lvEmployee.SelectedItem;
                if (employee != null)
                {
                    EmployeeDetails employeeDetails = new EmployeeDetails(this, employee);
                    employeeDetails.ShowDialog();
                }
            }
        }

    }

}

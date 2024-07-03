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

namespace EquipmentPage
{
    /// <summary>
    /// Interaction logic for EquipmentLandingPage.xaml
    /// </summary>
    public partial class EquipmentLandingPage : Window
    {
        public List<Equipment> EquipmentObjects { get; set; }
        public bool SortActive { get; set; } = false;
        public bool StartsWithActive { get; set; } = false;

        public EquipmentLandingPage()
        {
            InitializeComponent();
            EquipmentObjects = Equipment.GetTestData();
            listView_EquipmentGeneralView.ItemsSource = EquipmentObjects;
        }

        //Methods for this window

        private void btn_OrderByName_Click(object sender, RoutedEventArgs e)
        {
            var source = (List<Equipment>)listView_EquipmentGeneralView.ItemsSource;
            listView_EquipmentGeneralView.ItemsSource = source.OrderBy(e => e.Name).ToList();
            SetValues(sender);
        }


        private void btn_OrderByBrand_Click(object sender, RoutedEventArgs e)
        {
            var source = (List<Equipment>)listView_EquipmentGeneralView.ItemsSource;
            listView_EquipmentGeneralView.ItemsSource = source.OrderBy(e => e.Brand).ToList();
            SetValues(sender);
        }

        private void btn_OrderByMuscleGroup_Click(object sender, RoutedEventArgs e)
        {
            var source = (List<Equipment>)listView_EquipmentGeneralView.ItemsSource;
            listView_EquipmentGeneralView.ItemsSource = source.OrderBy(e => e.MuscleGroup).ToList();
            SetValues(sender);
        }

        private void btn_OrderByStatus_Click(object sender, RoutedEventArgs e)
        {
            var source = (List<Equipment>)listView_EquipmentGeneralView.ItemsSource;
            listView_EquipmentGeneralView.ItemsSource = source.OrderBy(e => e.Status).ToList();
            SetValues(sender);
        }

        private void btn_OrderByEquipmentType_Click(object sender, RoutedEventArgs e)
        {
            var source = (List<Equipment>)listView_EquipmentGeneralView.ItemsSource;
            listView_EquipmentGeneralView.ItemsSource = source.OrderBy(e => e.EquipmentType).ToList();
            SetValues(sender);
        }

        private void btn_SearchEquipment_Click(object sender, RoutedEventArgs e)
        {
            listView_EquipmentGeneralView.ItemsSource = EquipmentObjects.Where(e => e.Name.StartsWith(textBox_SearchEquipment.Text)).ToList();
            StartsWithActive = true;
        }

        private void btn_DeleteSearch_Click(object sender, RoutedEventArgs e)
        {
            textBox_SearchEquipment.Text = "Suchen nach";
            StartsWithActive = false;
            if (SortActive)
            {
                var text = label_SortAfter.Content.ToString().Split(":")[1];

                switch(text)
                {
                    case " Name":
                        listView_EquipmentGeneralView.ItemsSource = EquipmentObjects.OrderBy(e => e.Name).ToList();
                        break;
                    case " Marke":
                        listView_EquipmentGeneralView.ItemsSource = EquipmentObjects.OrderBy(e => e.Brand).ToList();
                        break;
                    case " Muskelgruppe":
                        listView_EquipmentGeneralView.ItemsSource = EquipmentObjects.OrderBy(e => e.MuscleGroup).ToList();
                        break;
                    case " Status":
                        listView_EquipmentGeneralView.ItemsSource = EquipmentObjects.OrderBy(e => e.Status).ToList();
                        break;
                    case " Gerätetyp":
                        listView_EquipmentGeneralView.ItemsSource = EquipmentObjects.OrderBy(e => e.EquipmentType).ToList();
                        break;
                }
            }
            else
            {
                listView_EquipmentGeneralView.ItemsSource = EquipmentObjects;
            }
        }

        private void btn_DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            label_SortAfter.Content = $"Sortiert nach:";
            SortActive = false;
            if (StartsWithActive)
            {
                btn_SearchEquipment_Click(null, null);
            }
            else
            {
                listView_EquipmentGeneralView.ItemsSource = EquipmentObjects;
            }
        }

        private void SetValues(object sender)
        {
            var button = (Button)sender;
            label_SortAfter.Content = $"Sortiert nach: {button.Content}";
            SortActive = true;
        }

        //Methods to other windows

        private void btn_AddEquipment_Click(object sender, RoutedEventArgs e)
        {
            var addEquipmentPage = new AddEquipmentPage(EquipmentObjects, this);
            addEquipmentPage.Owner = this;
            addEquipmentPage.ShowDialog();
        }

        private void listView_EquipmentGeneralView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            if(listView_EquipmentGeneralView.SelectedItem is not null)
            {
                var item = (Equipment)listView_EquipmentGeneralView.SelectedItem;
                var detailEquipmentPage = new DetailEquipment(item, EquipmentObjects, this);
                detailEquipmentPage.Owner = this;
                detailEquipmentPage.ShowDialog();
            }
        }

        public void UpdateSource(object sender, RoutedEventArgs e)
        {
            listView_EquipmentGeneralView.ItemsSource = EquipmentObjects.ToList();
            listView_EquipmentGeneralView.SelectedItem = null;
        }
    }
}

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

namespace EquipmentPage
{
    /// <summary>
    /// Interaktionslogik für AddEquipmentPage.xaml
    /// </summary>
    public partial class AddEquipmentPage : Window
    {
        public List<Equipment> EquipmentObjects {  get; set; }

        public AddEquipmentPage(List<Equipment> equipmentObjects)
        {
            InitializeComponent();
            EquipmentObjects = equipmentObjects;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var equipment = new Equipment()
            {
                Id = Guid.NewGuid(),
                Name = textbox_Name.Text,
                Picture = textbox_Picture.Text,
                Brand = textbox_Brand.Text,
                Type = textbox_Type.Text,
                MuscleGroup = textbox_MuscleGroup.Text,
                EquipmentType = textbox_EquipmentType.Text,
                WeightRange = textbox_Weight.Text,
                Location = textbox_Location.Text,
                Dimension = textbox_Dimension.Text,
                AquisitionDate = picker_AquisitionDate.SelectedDate,
                NextMaintenance = picker_NextMaintenance.SelectedDate,
            };
            equipment.AquisitionCost = EquipmentValueConverter.GetPrice(textbox_Price.Text);
            equipment.Status = EquipmentValueConverter.GetEnum(textbox_Status.Text);
            equipment.MaintenanceDuration = EquipmentValueConverter.GetTimeSpan(textbox_MaitenancePeriod.Text);

            EquipmentObjects.Add(equipment);
            //TODO in DB speichern
        }
    }
}

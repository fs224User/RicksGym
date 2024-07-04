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
    /// Interaktionslogik für DetailEquipment.xaml
    /// </summary>
    public partial class DetailEquipment : Window
    {
        public Equipment Equipment { get; set; }
        public List<Equipment> Equipments { get; set; }

        public DetailEquipment(Equipment equipment, List<Equipment> equipments)
        {
            InitializeComponent();
            Equipment = equipment;
            Equipments = equipments;
            SetTextBoxValues();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var detailEquipmentPage = new EditEqupimentPage(Equipment);
            detailEquipmentPage.Owner = this;
            detailEquipmentPage.ShowDialog();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var deleteDialog = new DeleteDialog(Equipment.Id, Equipments, this);
            deleteDialog.Owner = this;
            deleteDialog.ShowDialog();
        }

        private void SetTextBoxValues()
        {
            textbox_Name.Text = Equipment.Name;
            textbox_Picture.Text = Equipment.Picture;
            textbox_Brand.Text = Equipment.Brand;
            textbox_Type.Text = Equipment.Type;
            textbox_MuscleGroup.Text = Equipment.MuscleGroup;
            textbox_EquipmentType.Text = Equipment.EquipmentType;
            textbox_Location.Text = Equipment.Location;
            textbox_Weight.Text = Equipment.WeightRange;
            textbox_Dimension.Text = Equipment.Dimension;
            textbox_AquisitionDate.Text = Equipment.AquisitionDate.ToString();
            textbox_nextMaintenance.Text = Equipment.NextMaintenance.ToString();
            textbox_Price.Text = Equipment.AquisitionCost.ToString();
            textbox_Status.Text = Equipment.Status.ToString();
            textbox_MaitenancePeriod.Text = Equipment.MaintenanceDuration.ToString();
        }
    }
}

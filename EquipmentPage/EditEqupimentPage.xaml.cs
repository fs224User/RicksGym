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
    /// Interaktionslogik für EditEqupimentPage.xaml
    /// </summary>
    public partial class EditEqupimentPage : Window
    {
        public Equipment Equipment { get; set; }
        public EquipmentLandingPage EquipmentLanding { get; set; }
        public DetailEquipment DetailEquipment { get; set; }

        public EditEqupimentPage(Equipment equipment, EquipmentLandingPage equipmentLanding, DetailEquipment detailEquipment)
        {
            InitializeComponent();
            Equipment = equipment; //Order is important
            EquipmentLanding = equipmentLanding;
            DetailEquipment = detailEquipment;
            SetTextBoxValues();
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
            picker_AquisitionDate.SelectedDate = Equipment.AquisitionDate;
            picker_NextMaintenance.SelectedDate = Equipment.NextMaintenance;
            textbox_Price.Text = Equipment.AquisitionCost.ToString();
            textbox_Status.Text = Equipment.Status.ToString();
            textbox_MaitenancePeriod.Text = Equipment.MaintenanceDuration.ToString();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Equipment.Name = textbox_Name.Text;
            Equipment.Picture = textbox_Picture.Text;
            Equipment.Brand = textbox_Brand.Text;
            Equipment.Type = textbox_Type.Text;
            Equipment.MuscleGroup = textbox_MuscleGroup.Text;
            Equipment.EquipmentType = textbox_EquipmentType.Text;
            Equipment.WeightRange = textbox_Weight.Text;
            Equipment.Location = textbox_Location.Text;
            Equipment.Dimension = textbox_Dimension.Text;
            Equipment.AquisitionDate = picker_AquisitionDate.SelectedDate;
            Equipment.NextMaintenance = picker_NextMaintenance.SelectedDate;
            Equipment.AquisitionCost = EquipmentValueConverter.GetPrice(textbox_Price.Text);
            Equipment.Status = EquipmentValueConverter.GetEnum(textbox_Status.Text);
            Equipment.MaintenanceDuration = EquipmentValueConverter.GetTimeSpan(textbox_MaitenancePeriod.Text);
            EquipmentLanding.UpdateSource(null, null);
            DetailEquipment.SetTextBoxValues();
            DetailEquipment.Activate();
            this.Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            EquipmentLanding.UpdateSource(null, null);
            DetailEquipment.Activate();
            this.Close();
        }
    }
}
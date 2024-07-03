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
    /// Interaktionslogik für DeleteDialog.xaml
    /// </summary>
    public partial class DeleteDialog : Window
    {
        public Equipment Equipment { get; set; }
        public List<Equipment> Equipments { get; set; }
        public DetailEquipment DetailEqupimentPage { get; set; }
        public EquipmentLandingPage EquipmentLanding { get; set; }

        public DeleteDialog(Guid id, List<Equipment> equipments, DetailEquipment detailEqupimentPage, EquipmentLandingPage equipmentLanding)
        {
            InitializeComponent();
            Equipments = equipments;
            DetailEqupimentPage = detailEqupimentPage;
            EquipmentLanding = equipmentLanding;
            Equipment = Equipments.Single(e => e.Id == id);
            SetLabel();
        }

        private void SetLabel()
        {
            label_DeleteQuestion.Content = $"Wollen sie sicher das Gerät {Equipment.Name} löschen?";
        }

        private void btn_AcceptDelete_Click(object sender, RoutedEventArgs e)
        {
            Equipments.Remove(Equipment);
            //TODO aus Db löschen
            EquipmentLanding.UpdateSource(null,null);
            EquipmentLanding.Activate();
            DetailEqupimentPage.Close();
            this.Close();
        }
    }
}

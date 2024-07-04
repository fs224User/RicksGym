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
    public partial class MemberDatails_Edit : Window
    {
        public MemberDatails_Edit(List<Customer> lk, Guid id)
        {
            InitializeComponent();   
        }

       
    }
}

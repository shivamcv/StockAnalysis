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

namespace TriggerPoint.Views
{
    /// <summary>
    /// Interaction logic for StochasticDialog.xaml
    /// </summary>
    public partial class StochasticDialog : UserControl
    {
        public StochasticDialog()
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "DateTime")
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy H:mm:ss";
            if (e.PropertyName == "Date")
                (e.Column as DataGridTextColumn).Binding.StringFormat = "d";
            if (e.PropertyName == "Time")
                (e.Column as DataGridTextColumn).Binding.StringFormat = "t";
        }
        
    }
}

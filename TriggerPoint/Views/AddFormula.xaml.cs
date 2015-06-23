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
    /// Interaction logic for AddFormula.xaml
    /// </summary>
    public partial class AddFormula : Page
    {
        public AddFormula()
        {
            InitializeComponent();
        }

     
        private void Close(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow(sender as DependencyObject );
            w.Close();
        }
    }
}

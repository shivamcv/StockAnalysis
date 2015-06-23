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

namespace TriggerPoint
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        public PopupWindow(string path)
        {
            InitializeComponent();

            RootFrame.Navigate(new Uri(path, UriKind.Relative));
            this.Width = RootFrame.Width;
            this.Height = RootFrame.Height;
        }

        private void RootFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Page p = RootFrame.Content as Page;

            if (p != null)
            {
                this.Title = p.Title;
                this.Width = p.Width;
                this.Height = p.Height;
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                return;
                if (e.LeftButton == MouseButtonState.Pressed)
                    DragMove();
            }
            catch
            {

            }
        }
    }
}

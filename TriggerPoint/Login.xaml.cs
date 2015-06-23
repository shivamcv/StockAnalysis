using GalaSoft.MvvmLight.Ioc;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            var vm = SimpleIoc.Default.GetInstance<ViewModel.LoginViewModel>();
            passwordBox.Password = vm.Password;
        }

        private void Password_Changed(object sender, RoutedEventArgs e)
        {
            var vm = SimpleIoc.Default.GetInstance<ViewModel.LoginViewModel>();

            vm.Password = ((PasswordBox)sender).Password;
            vm.Error = string.Empty;
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

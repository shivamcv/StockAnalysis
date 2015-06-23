using System.Windows;
using TriggerPoint.ViewModel;
using System.Data.Entity;
namespace TriggerPoint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
            MainViewModel vm = this.DataContext as MainViewModel;
            vm.Docking_Manager = dockingManager;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Login log = new Login();

            if (log.ShowDialog() == false)
            {
                App.Current.Shutdown();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
     
    }
}
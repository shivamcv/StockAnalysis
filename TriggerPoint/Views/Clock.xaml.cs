using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Clock.xaml
    /// </summary>
    public partial class Clock : UserControl,INotifyPropertyChanged
    {

        public Clock()
        {
            InitializeComponent();
            this.DataContext = this;


            UpdateTime();
        }

        private async Task UpdateTime()
        {
            Time = DateTime.Now.ToLongTimeString();
            Date = DateTime.Now.ToShortDateString();

            await Task.Delay(1000);

            UpdateTime();
        }

        private string time;

        public string Time
        {
            get { return time; }
            set { time = value;
            RaisePropertyChanged("Time");
            }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set { date = value;
            RaisePropertyChanged("Date");
            }
        }
        

        private void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

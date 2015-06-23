using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
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
    /// Interaction logic for StatusBarView.xaml
    /// </summary>
    public partial class StatusBarView : UserControl,INotifyPropertyChanged
    {
        public StatusBarView()
        {
            InitializeComponent();
            this.DataContext = this;

            Messenger.Default.Register<Model.MessageType>(this, OnLogin);
        }

        private void OnLogin(Model.MessageType obj)
        {
            if(obj == Model.MessageType.LoginSuccessful)
            {
                CurrentUser = SimpleIoc.Default.GetInstance<ViewModel.LoginViewModel>().CurrentUser.UserName;

                EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder(Properties.Settings.Default.ConnectionString);
                SqlConnectionStringBuilder c = new SqlConnectionStringBuilder(esb.ProviderConnectionString);

                 DbName=  c.InitialCatalog;
            }
        }


        private string currentUser;

        public string CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value;
            RaisePropertyChanged("CurrentUser");
            }
        }

        private string dbName;

        public string DbName
        {
            get { return dbName; }
            set { dbName = value;
            RaisePropertyChanged("DbName");
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

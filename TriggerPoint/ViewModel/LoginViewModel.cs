using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TriggerPoint.ViewModel
{
   public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
       {
           Username = Properties.Settings.Default.Username;
           Password = Properties.Settings.Default.Password;
       }

        private bool isRememberMe;

        public bool IsRememberMe
        {
            get { return isRememberMe; }
            set { isRememberMe = value;
            RaisePropertyChanged("IsRememberMe");
            }
        }

        public Data.Tbl_User CurrentUser { get; set; }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value;
            RaisePropertyChanged("Username");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
            RaisePropertyChanged("Password");
            }
        }

        private string error;

        public string Error
        {
            get { return error; }
            set { error = value;
            RaisePropertyChanged("Error");
            }
        }
        
       private RelayCommand<FrameworkElement> login;
        public RelayCommand<FrameworkElement> Login
        {
            get
            {
                return login ?? (login = new RelayCommand<FrameworkElement>((f) =>
                    {
                        if (IsLoginCorrect())
                        {
                            Window w = Window.GetWindow(f);
                            w.DialogResult = true;
                            w.Close();

                            MessengerInstance.Send<Model.MessageType>(Model.MessageType.LoginSuccessful);
                        }
                    }, (f) =>
                    {
                        if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(password))
                            return true;

                        return false;
                    }));
            }
        }

        private bool IsLoginCorrect()
        {
            using (var db = new Data.TriggerPointContext())
            {
                
                bool exists=false;

                try
                {
                    exists = db.Database
                         .SqlQuery<int?>(@"
                         SELECT 1 FROM sys.tables AS T
                         INNER JOIN sys.schemas AS S ON T.schema_id = S.schema_id
                         WHERE  T.Name = 'Tbl_User'")
                         .SingleOrDefault() != null;
                }
                catch(Exception ex)
                {

                }

                if(!exists)
                {
                    Properties.Settings.Default.ConnectionString = string.Empty;
                    Properties.Settings.Default.Save();
                    Error = "Invalid Database !!";
                    SimpleIoc.Default.GetInstance<MainViewModel>().ChangeDatabase.Execute(null);
                    //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    //Application.Current.Shutdown();
                    return false;
                }

                var temp = db.Tbl_User.FirstOrDefault(p => string.Compare(p.UserName, Username, true) == 0 && string.Compare(p.Password, Password, false) == 0);

                if (IsRememberMe && temp!= null)
                {
                    Properties.Settings.Default.Username = temp.UserName;
                    Properties.Settings.Default.Password = temp.Password;
                    Properties.Settings.Default.Save();
                }
                if (temp == null)
                {
                    Error = "Invalid Credentials!!";
                    return false;
                }
                else
                    CurrentUser = temp;

            }
            return true;
        }
        
    }
}

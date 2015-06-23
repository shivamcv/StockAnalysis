using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Data;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace TriggerPoint.ViewModel
{
     public class MainViewModel : ViewModelBase
    {
      
        public MainViewModel()
        {
            //Properties.Settings.Default.ConnectionString = string.Empty;
            //Properties.Settings.Default.Save();

            if (DateTime.Now > DateTime.Parse("30/06/2015"))
            {
                MessageBox.Show("Product expired !! Please contact developer.");
                App.Current.Shutdown();
            }

            if(!IsInDesignMode)
            if(string.IsNullOrEmpty(Properties.Settings.Default.ConnectionString))
           {
                if (SimpleIoc.Default.GetInstance<Connection>().loadConnectionString() != true)
                {
                    App.Current.Shutdown();
                }
            }
            
#if DEBUG
            //MessengerInstance.Register<Model.MessageType>(this, (ee) =>
            //    {
            //        if (ee == Model.MessageType.LoginSuccessful)
            //        {
            //            AverageDialogViewModel vm = new AverageDialogViewModel(DateTime.MinValue,
            //                                                                                   DateTime.MaxValue,
            //                                                                                   1,
            //                                                                                   new List<int>() { 1 },
            //                                                                                    5);

            //            Views.AverageDialog dig = new Views.AverageDialog();
            //            dig.DataContext = vm;
            //            AddDialog(dig, "test Dialog");
            //        }
            //    });
#endif
        }

        private RelayCommand exit;

        public RelayCommand Exit
        {
            get
            {
                return exit ?? (exit = new RelayCommand(() =>
                    {
                        App.Current.Shutdown();
                    }));
            }
        }


        private RelayCommand<Type> popupWindow;

        public RelayCommand<Type> PopupWindow
        {
            get
            {
                return popupWindow ?? (popupWindow = new RelayCommand<Type>((t) =>
                    {
                        PopupWindow p = new PopupWindow("Views/" + t.Name + ".xaml");
                        p.ShowDialog();
                    }));
            }
        }

        public DockingManager Docking_Manager { get; set; }
       
        public void AddDialog( UserControl dig, string title)
        {
            var documentPane = Docking_Manager.Layout.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();

            if (documentPane != null)
            {
                LayoutDocument layoutDocument = new LayoutDocument { Title = title };

                layoutDocument.Content = dig;

                documentPane.Children.Add(layoutDocument);
                layoutDocument.IsSelected = true;
            }
        }


         private RelayCommand changeDatabase;

         public RelayCommand ChangeDatabase
         {
             get
             {
                 return changeDatabase ?? (changeDatabase = new RelayCommand(() =>
                     {
                         SimpleIoc.Default.GetInstance<Connection>().loadConnectionString();

                         Login log = new Login();

                         if (log.ShowDialog() == false)
                         {
                             App.Current.Shutdown();
                         }
                     }));
             }
         }
        
    }
}
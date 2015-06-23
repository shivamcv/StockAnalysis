using System.Windows;
using GalaSoft.MvvmLight.Threading;
using System.IO;
using System;

namespace TriggerPoint
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string DataFolder { get; set; }
        static App()
        {
            DispatcherHelper.Initialize();

            DataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TriggerPoint");

            if (!Directory.Exists(DataFolder))
                Directory.CreateDirectory(DataFolder);
        }
    }
}

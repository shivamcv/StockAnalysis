

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace TriggerPoint.ViewModel
{
  
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
            }
            else
            {
            }

            SimpleIoc.Default.Register<MergeSplitViewModel>();
            SimpleIoc.Default.Register<DataDeletionViewModel>();
            SimpleIoc.Default.Register<IndicatorDataViewModel>();
            SimpleIoc.Default.Register<PortfolioMasterViewModel>();
            SimpleIoc.Default.Register<AddFormula>();
            SimpleIoc.Default.Register<RSI>();
            SimpleIoc.Default.Register<MACD>();
            SimpleIoc.Default.Register<Average>();
          //  SimpleIoc.Default.Register<Stochastic>();
            SimpleIoc.Default.Register<BollingerBand>();
            SimpleIoc.Default.Register<Swing>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<Connection>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SettingViewModel>();
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public IndicatorDataViewModel IndicatorData
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IndicatorDataViewModel>();
            }
        }
      
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
          "CA1822:MarkMembersAsStatic",
          Justification = "This non-static member is needed for data binding purposes.")]
        public Connection SqlConnection
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Connection>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        "CA1822:MarkMembersAsStatic",
        Justification = "This non-static member is needed for data binding purposes.")]
        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        "CA1822:MarkMembersAsStatic",
        Justification = "This non-static member is needed for data binding purposes.")]
        public MACD MACD
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MACD>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
      "CA1822:MarkMembersAsStatic",
      Justification = "This non-static member is needed for data binding purposes.")]
        public RSI RSI
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RSI>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
      "CA1822:MarkMembersAsStatic",
      Justification = "This non-static member is needed for data binding purposes.")]
        public Average Average
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Average>();
            }
        }
      //  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
      //"CA1822:MarkMembersAsStatic",
      //Justification = "This non-static member is needed for data binding purposes.")]
      //  public Stochastic Stochastic
      //  {
      //      get
      //      {
      //          return ServiceLocator.Current.GetInstance<Stochastic>();
      //      }
      //  }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
      "CA1822:MarkMembersAsStatic",
      Justification = "This non-static member is needed for data binding purposes.")]
        public Swing Swing
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Swing>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
      "CA1822:MarkMembersAsStatic",
      Justification = "This non-static member is needed for data binding purposes.")]
        public BollingerBand BoilerBand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BollingerBand>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
     "CA1822:MarkMembersAsStatic",
     Justification = "This non-static member is needed for data binding purposes.")]
        public AddFormula AddFormula
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddFormula>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
    "CA1822:MarkMembersAsStatic",
    Justification = "This non-static member is needed for data binding purposes.")]
        public PortfolioMasterViewModel PortfolioMaster
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PortfolioMasterViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public SettingViewModel Settings
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingViewModel>();
            }
        }
        public DataDeletionViewModel DataDeletionVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DataDeletionViewModel>();
            }
        }
        public MergeSplitViewModel MergeSplitVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MergeSplitViewModel>();
            }
        }
        public static void Cleanup()
        {
        }
    }
}
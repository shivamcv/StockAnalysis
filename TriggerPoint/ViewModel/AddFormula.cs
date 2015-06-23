using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;

namespace TriggerPoint.ViewModel
{
   public class AddFormula : ViewModelBase
    {
       public AddFormula()
       {
           IndicatorTypes = new List<string>() { "MACD", "RSI", "Average", "Bollinger Band", "Swing" };
           TimePeriod = new List<string>() {"5","10","15","20","30","45","60","90","120","EOD" };
           IsScript = true;
       }

       private bool isScript= true;

       public bool IsScript
       {
           get { return isScript; }
           set
           {
               isScript = value;
               RaisePropertyChanged("IsScript");

               if(isScript)
               using (var db = new Data.TriggerPointContext())
               {
                   ScriptList = db.Tbl_ScriptMaster.AsEnumerable().Select(p => new KeyValuePair<int, string>(p.ID, p.ScriptName)).OrderBy(p=>p.Value).ToList();
                   SelectedScript = ScriptList.FirstOrDefault();
               }

           }
       }

       private bool isPortfolio;

       public bool IsPortfolio
       {
           get { return isPortfolio; }
           set
           {
               isPortfolio = value;
               RaisePropertyChanged("IsPortfolio");

               if(isPortfolio)
               using (var db = new Data.TriggerPointContext())
               {
                   ScriptList = db.Tbl_Portfolio.AsEnumerable().Select(p => new KeyValuePair<int, string>(p.PortfolioID, p.PortfolioName)).OrderBy(p=>p.Value).ToList();
                   SelectedScript = ScriptList.FirstOrDefault();
               }
           }
       }
       

       private string seletedIndicatorType;
       public string SelectedIndicatorType
       {
           get { return seletedIndicatorType; }
           set { seletedIndicatorType = value;
           LoadIndicators();
                RaisePropertyChanged("SelectedIndicatorType");
           }
       }

       private void LoadIndicators()
       {
           using (var db = new Data.TriggerPointContext())
           {
               switch (SelectedIndicatorType)
               {
                   case "Average":
                       Indicators = db.Tbl_Average.AsEnumerable().Where(p=>p.IsDelete ==false).Select(p => new KeyValuePair<int,string>(p.AverageID, p.AverageName)).ToList();
                       break;
                   case "MACD":
                       Indicators = db.Tbl_MACD.AsEnumerable().Where(p => p.IsDelete == false).Select(p => new KeyValuePair<int, string>(p.MACDID, p.MACDName)).ToList();
                      break;
                   case "Bollinger Band":
                      Indicators = db.Tbl_BollingerBand.AsEnumerable().Where(p => p.IsDelete == false).Select(p => new KeyValuePair<int, string>(p.BollingerBandID, p.BollingerBandName)).ToList();
                       break;
                   case "Stochastic":
                       Indicators = db.Tbl_Stochastic.AsEnumerable().Where(p => p.IsDelete == false).Select(p => new KeyValuePair<int, string>(p.StochasticID, p.StochasticName)).ToList();
                       break;
                   case "RSI":
                       Indicators = db.Tbl_RSI.AsEnumerable().Where(p => p.IsDelete == false).Select(p => new KeyValuePair<int, string>(p.RSIID, p.RSIName)).ToList();
                       break;
                   case "Swing":
                       Indicators = db.Tbl_Swing.AsEnumerable().Where(p => p.IsDelete == false).Select(p => new KeyValuePair<int, string>(p.SwingID, p.SwingName)).ToList();
                       break;
                   default:
                       break;
               }
           }
       }

       private string selectedTimePeriod;
       public string SelectedTimePeriod
       {
           get { return selectedTimePeriod; }
           set { selectedTimePeriod = value;
             RaisePropertyChanged("SelectedTimePeriod");
           }
       }

       private KeyValuePair<int, string> selectedIndicator;

       public KeyValuePair<int, string> SelectedIndicator
       {
           get { return selectedIndicator; }
           set { selectedIndicator = value;
             RaisePropertyChanged("SelectedIndicator");
           }
       }

       private KeyValuePair<int, string> selectedScript;

       public KeyValuePair<int, string> SelectedScript
       {
           get { return selectedScript; }
           set { selectedScript = value;
           RaisePropertyChanged("SelectedScript");
           }
       }

       private IEnumerable<KeyValuePair<int, string>> scriptList;

       public IEnumerable<KeyValuePair<int, string>> ScriptList
       {
           get { return scriptList; }
           set
           {
               scriptList = value;
               RaisePropertyChanged("ScriptList");
           }
       }

       public List<string> TimePeriod { get; set; }

       public List<string> IndicatorTypes { get; set; }

       private IEnumerable<KeyValuePair<int, string>> indicators;

       public IEnumerable<KeyValuePair<int,string>> Indicators
       {
           get { return indicators; }
           set { indicators = value;
           RaisePropertyChanged("Indicators");
           }
       }

       private RelayCommand<DependencyObject> ok;

       public RelayCommand<DependencyObject> Ok
       {
           get
           {
               return ok ?? (ok = new RelayCommand<DependencyObject>((p) =>
                   {
                       List<int> scripts = new List<int>();

                       if (IsScript)
                           scripts.Add(selectedScript.Key);
                       else
                           using(var db = new Data.TriggerPointContext())
                           foreach (var item in db.Tbl_ScriptPortfolio.Where(q=>q.PortfolioID == selectedScript.Key))
                           {
                               scripts.Add(item.ScriptID ?? 0);
                           }

                       UserControl dialog = new UserControl();
                       switch (SelectedIndicatorType)
                       {
                           case "Average":
                               {
                                   AverageDialogViewModel vm = new AverageDialogViewModel(DateTime.MinValue,
                                                                                       DateTime.MaxValue,
                                                                                       SelectedIndicator.Key,
                                                                                       scripts,
                                                                                        int.Parse(SelectedTimePeriod == "EOD" ? "885" : SelectedTimePeriod));

                                   dialog = new Views.AverageDialog();
                                   dialog.DataContext = vm;

                               }
                               break;
                           case "Bollinger Band":
                               {
                                   BollingerDialogViewModel vm = new BollingerDialogViewModel(DateTime.MinValue,
                                                                                       DateTime.MaxValue,
                                                                                       SelectedIndicator.Key,
                                                                                       scripts,
                                                                                        int.Parse(SelectedTimePeriod == "EOD" ? "885" : SelectedTimePeriod));

                                   dialog = new Views.BollingerBandDialog();
                                   dialog.DataContext = vm;
                                  
                               }
                               break;
                           case "MACD":
                               {
                                   MACDDialogViewModel vm = new MACDDialogViewModel(DateTime.MinValue,
                                                                                       DateTime.MaxValue,
                                                                                       SelectedIndicator.Key,
                                                                                       scripts,
                                                                                        int.Parse(SelectedTimePeriod == "EOD" ? "885" : SelectedTimePeriod));
                                   dialog = new Views.MACDDialog();
                                   dialog.DataContext = vm;
                               }
                               break;
                           //case "Stochastic":
                           //    {
                           //        StochasticDialogViewModel vm = new StochasticDialogViewModel(DateTime.MinValue,
                           //                                                            DateTime.MaxValue,
                           //                                                            SelectedIndicator.Key,
                           //                                                            scripts,
                           //                                                             int.Parse(SelectedTimePeriod == "EOD" ? "885" : SelectedTimePeriod));
                                 
                           //        dialog = new Views.StochasticDialog();
                           //        dialog.DataContext = vm;
                           //    }
                           //    break;
                           case "RSI":
                               {
                                   RSIDialogViewModel vm = new RSIDialogViewModel(DateTime.MinValue,
                                                                                       DateTime.MaxValue,
                                                                                       SelectedIndicator.Key,
                                                                                       scripts,
                                                                                        int.Parse(SelectedTimePeriod == "EOD" ? "885" : SelectedTimePeriod));

                                   dialog = new Views.RSIDialog();
                                   dialog.DataContext = vm;
                               }
                               break;
                           case "Swing":
                               {
                                   SwingDialogViewModel vm = new SwingDialogViewModel(DateTime.MinValue,
                                                                                       DateTime.MaxValue,
                                                                                       SelectedIndicator.Key,
                                                                                       scripts,
                                                                                        int.Parse(SelectedTimePeriod == "EOD" ? "885" : SelectedTimePeriod));

                                   dialog = new Views.SwingDialog();
                                   dialog.DataContext = vm;
                               }
                               break;
                           default:
                               return;
                       }

                       var mvm = SimpleIoc.Default.GetInstance<MainViewModel>();
                       mvm.AddDialog(dialog, SelectedScript.Value  + "-" + SelectedIndicator.Value + "(" + selectedTimePeriod +"min)");
                       Window w = Window.GetWindow(p);
                       w.Close();

                   }, (p) =>
                   {
                       if ( SelectedIndicator.Value == null||
                           SelectedScript.Key == 0 ||
                           string.IsNullOrEmpty(SelectedIndicatorType) ||
                           string.IsNullOrEmpty(SelectedTimePeriod))
                           return false;
                       return true;
                   }));
           }
       }

      
        
    }
}

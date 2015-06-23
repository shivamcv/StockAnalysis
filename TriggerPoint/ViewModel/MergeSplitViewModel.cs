using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriggerPoint.Data;
using Xceed.Wpf.Toolkit;

namespace TriggerPoint.ViewModel
{
  public  class MergeSplitViewModel:ViewModelBase
    {
      public MergeSplitViewModel()
      {
          using (var db = new TriggerPointContext())
          {
              Scripts = db.Tbl_ScriptMaster.OrderBy(p=>p.ScriptName).ToList();
          }

          Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      }
        private IEnumerable<Tbl_ScriptMaster> scripts;

        public IEnumerable<Tbl_ScriptMaster> Scripts
        {
            get { return scripts; }
            set { scripts = value;
            RaisePropertyChanged("Scripts");
            }
        }

        private Tbl_ScriptMaster fromScript;

        public Tbl_ScriptMaster FromScript
        {
            get { return fromScript; }
            set { fromScript = value;
            RaisePropertyChanged("FromScript");
            }
        }

        private Tbl_ScriptMaster toScript;
        public Tbl_ScriptMaster ToScript
        {
            get { return toScript; }
            set { toScript = value;
            RaisePropertyChanged("ToScript");
            }
        }

        private Tbl_ScriptMaster splitScript;

        public Tbl_ScriptMaster SplitScript
        {
            get { return splitScript; }
            set { splitScript = value;
            using (var db = new TriggerPointContext())
            {
                var temp = db.Tbl_Script10Min.FirstOrDefault(p => p.Company == splitScript.ID);

                if (temp != null)
                    ScriptValue = temp.OpenReadings??0;
            }
            RaisePropertyChanged("SplitScript");
            }
        }

        private decimal scriptValue;

        public decimal ScriptValue
        {
            get { return scriptValue; }
            set
            {
                scriptValue = Math.Round(value, 2);
                RaisePropertyChanged("ScriptValue");
                CalculateScripFinalValue();
            }
        }

        private void CalculateScripFinalValue()
        {
            if (Numerator == 0 || Denominator == 0) return;

            SplitFactor = (decimal)Numerator / (decimal)Denominator;

            ScriptFinalValue = ScriptValue * SplitFactor;
        }

        private decimal scriptFinalValue;

        public decimal ScriptFinalValue
        {
            get { return scriptFinalValue; }
            set { scriptFinalValue =Math.Round(value,2);

            RaisePropertyChanged("ScriptFinalValue");
            }
        }


        private DateTime effectiveDate = DateTime.Now;

        public DateTime EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value;
            RaisePropertyChanged("EffectiveDate");
            }
        }
        

        public List<int> Numbers { get; set; }
        public decimal SplitFactor { get; set; }

        private int numerator;

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value;
            CalculateScripFinalValue();
            RaisePropertyChanged("Numerator");
            }
        }

        private int denominator;

        public int Denominator
        {
            get { return denominator; }
            set { denominator = value;
            CalculateScripFinalValue();
            RaisePropertyChanged("Denominator");
            }
        }
        

        private RelayCommand merge;

        public RelayCommand Merge
        {
            get
            {
                return merge ?? (merge = new RelayCommand(() =>
                    {
                        try
                        {
                            var response = MessageBox.Show(string.Format("{0} is replaced with {1} \n Are you sure want to merge the record ?", FromScript.ScriptName, ToScript.ScriptName), "Merge Script", System.Windows.MessageBoxButton.YesNoCancel, System.Windows.MessageBoxImage.Question);

                            if(response == System.Windows.MessageBoxResult.Yes)
                            using (var db = new Data.TriggerPointContext())
                            {
                                ObjectParameter result = new ObjectParameter("Result", typeof(int));
                                db.MergeData(FromScript.ID, ToScript.ID, result);

                                int t;
                                int.TryParse(result.Value.ToString(), out t);
                                MessageBox.Show(String.Format("{0} row(s) are effected", t), "Merge Data", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            while (ex.InnerException != null)
                                ex = ex.InnerException;
                            MessageBox.Show(ex.Message, "Exception", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        }
                    }, () =>
                    {
                        if (FromScript == null || ToScript == null || FromScript == ToScript)
                            return false;
                        return true;
                    }));
            }
        }

        private RelayCommand split;

        public RelayCommand Split
        {
            get
            {
                return split ?? (split = new RelayCommand(() =>
                    {
                        try
                        {
                            using (var db = new Data.TriggerPointContext())
                            {
                                ObjectParameter result = new ObjectParameter("Result", typeof(int));
                                db.SplitData(SplitScript.ID,EffectiveDate ,  (decimal)SplitFactor, result);

                                int t;
                                int.TryParse(result.Value.ToString(), out t);
                                MessageBox.Show(String.Format("{0} row(s) are effected", t), "Split Data", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                            }
                        }catch (Exception ex)
                        {
                            while (ex.InnerException != null)
                                ex = ex.InnerException;
                            MessageBox.Show(ex.Message, "Exception", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        }
                    }, () =>
                    {
                        if(splitScript == null && SplitFactor <0)
                                return false;
                        return true;
                    }));
            }
        }
        
        
    }
}

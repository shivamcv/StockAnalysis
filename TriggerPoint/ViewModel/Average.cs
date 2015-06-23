using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.ViewModel
{
   public class Average:ViewModelBase
    {
       public Average()
       {
           AverageIndicators = new ObservableCollection<Model.AverageIndicator>();
           using (var db = new Data.TriggerPointContext())
           {
               var t = db.Tbl_Average.Where(p => p.IsDelete == false).ToList();
               foreach (var item in t)
               {
                   var temp = db.Tbl_AverageParameters.AsEnumerable().FirstOrDefault(p => p.AverageID == item.AverageID);

                   if (temp != null)
                       AverageIndicators.Add(new Model.AverageIndicator()
                       {
                           CalculatedOn = (Model.CalculateTypes)temp.Type,
                           Id = item.AverageID,
                           IsExponential = temp.IsExposional??false,
                           Name = item.AverageName,
                           TimePeriod = (int)temp.Period,
                       });
               }
           }
       }

       public ObservableCollection<Model.AverageIndicator> AverageIndicators { get; set; }

       private int timePeriod;
       public int TimePeriod
       {
           get { return timePeriod; }
           set { timePeriod = value;
           RaisePropertyChanged("TimePeriod");
           }
       }

       private string name;

       public string Name
       {
           get { return name; }
           set { name = value;
           RaisePropertyChanged("Name");
           }
       }

       private Model.CalculateTypes calculatedOn;

       public Model.CalculateTypes CalculatedOn
       {
           get { return calculatedOn; }
           set { calculatedOn = value;
           RaisePropertyChanged("CalculatedOn");
           }
       }

       private bool isEMA;

       public bool IsEMA
       {
           get { return isEMA; }
           set { isEMA = value;
           RaisePropertyChanged("IsEMA");
           }
       }

       private bool isSMA=true;

       public bool IsSMA
       {
           get { return isSMA; }
           set { isSMA = value;
           RaisePropertyChanged("IsSMA");
           }
       }

       private Model.AverageIndicator  selectedIndicator;

       public Model.AverageIndicator  SelectedIndicator
       {
           get { return selectedIndicator; }
           set {
               if (value == null) return;
               selectedIndicator = value;

           RaisePropertyChanged("SelectedIndicator");
               Name = selectedIndicator.Name;
               IsEMA = selectedIndicator.IsExponential;
               CalculatedOn = selectedIndicator.CalculatedOn;
               TimePeriod = selectedIndicator.TimePeriod;
               id = selectedIndicator.Id;
           }
       }

       int id = 0;

       private RelayCommand submit;

       public RelayCommand Submit
       {
           get
           {
               return submit ?? (submit = new RelayCommand(() =>
                   {
                       using (var db = new Data.TriggerPointContext())
                       {
                           if (id == 0)
                           {
                               var temp = db.Tbl_Average.Add(new Data.Tbl_Average()
                                 {
                                     AverageName = Name,
                                     IsDelete = false

                                 });

                               db.SaveChanges();

                               if (temp != null)
                               {
                                   db.Tbl_AverageParameters.Add(new Data.Tbl_AverageParameters()
                                   {
                                       AverageID = temp.AverageID,
                                       IsExposional = IsEMA,
                                       Period = TimePeriod,
                                       Type = (int)CalculatedOn
                                   });
                               }

                               db.SaveChanges();

                               AverageIndicators.Add(new Model.AverageIndicator()
                               {
                                   CalculatedOn = CalculatedOn,
                                   Id = temp.AverageID,
                                   IsExponential = IsEMA,
                                   Name = Name,
                                   TimePeriod = TimePeriod,
                               });
                           }
                           else
                           {
                               db.Tbl_Average.First(p => p.AverageID == id).AverageName = name;
                               var temp=  db.Tbl_AverageParameters.First(p => p.AverageID == id);
                               temp.IsExposional = IsEMA;
                               temp.Period = timePeriod;
                               temp.Type = (int)CalculatedOn;
                               db.SaveChanges();

                               AverageIndicators.Remove(selectedIndicator);
                               AverageIndicators.Add(new Model.AverageIndicator()
                               {
                                   CalculatedOn = CalculatedOn,
                                   Id = id,
                                   IsExponential = IsEMA,
                                   Name = Name,
                                   TimePeriod = TimePeriod,
                               });
                           }

                           Reset.Execute(null);
                       }
                   }, () =>
                   {
                       if (string.IsNullOrEmpty(Name) || TimePeriod <= 0)
                           return false;
                       return true;
                   }));
           }
       }

       private RelayCommand reset;

       public RelayCommand Reset
       {
           get
           {
               return reset ?? (reset = new RelayCommand(() =>
                   {
                       Name = string.Empty;
                       TimePeriod = 0;
                       CalculatedOn = Model.CalculateTypes.Close;
                       IsSMA = true;
                       id = 0;
                   }));
           }
       }

       private RelayCommand delete;

       public RelayCommand Delete
       {
           get
           {
               return delete ?? (delete = new RelayCommand(() =>
                   {
                       using (var db = new Data.TriggerPointContext())
                       {
                           var t = db.Tbl_Average.Where(p => p.AverageID == SelectedIndicator.Id).First();
                           t.IsDelete = true;

                           db.SaveChanges();
                           AverageIndicators.Remove(SelectedIndicator);
                       }
                   }, () =>
                   {
                       if (SelectedIndicator == null)
                           return false;
                       return true;
                   }));
           }
       }
        
        
    }
}

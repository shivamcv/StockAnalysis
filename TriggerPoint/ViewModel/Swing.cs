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
  public  class Swing:ViewModelBase
    {
      public Swing()
       {
           SwingIndicators = new ObservableCollection<Model.SwingIndicator>();
           using (var db = new Data.TriggerPointContext())
           {
               var t = db.Tbl_Swing.Where(p => p.IsDelete == false).ToList();
               foreach (var item in t)
               {
                   var temp = db.Tbl_SwingParameters.AsEnumerable().FirstOrDefault(p => p.SwingID == item.SwingID);

                   if (temp != null)
                       SwingIndicators.Add(new Model.SwingIndicator()
                       {
                           Id = item.SwingID,
                           Name = item.SwingName,
                           LimitMove = (float)temp.LimitMove,
                           TimePeriod = temp.TimePeriod ?? 0,
                           BandTimePeriod = temp.SwingBandTimePeriod ??0,
                       });
               }
           }
       }

       public ObservableCollection<Model.SwingIndicator> SwingIndicators { get; set; }

       
      private int timePeriod;

       public int TimePeriod
       {
           get { return timePeriod; }
           set { timePeriod = value;
           RaisePropertyChanged("TimePeriod");

           }
       }
       private int bandTimePeriod;

      public int BandTimePeriod
       {
           get { return bandTimePeriod; }
           set
           {
               bandTimePeriod = value;
           RaisePropertyChanged("BandTimePeriod");

           }
       }
       

       private float limitMove;
       public float LimitMove
       {
           get { return limitMove; }
           set
           {
               limitMove = value;
               RaisePropertyChanged("LimitMove");
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

      
      

       private Model.SwingIndicator  selectedIndicator;

       public Model.SwingIndicator  SelectedIndicator
       {
           get { return selectedIndicator; }
           set {
               if (value == null) return;
               selectedIndicator = value;

           RaisePropertyChanged("SelectedIndicator");
               Name = selectedIndicator.Name;
               LimitMove = selectedIndicator.LimitMove;
               TimePeriod = selectedIndicator.TimePeriod;
               BandTimePeriod = selectedIndicator.BandTimePeriod;
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
                               var temp = db.Tbl_Swing.Add(new Data.Tbl_Swing()
                                 {
                                     SwingName = Name,
                                     IsDelete = false

                                 });

                               db.SaveChanges();

                               if (temp != null)
                               {
                                   db.Tbl_SwingParameters.Add(new Data.Tbl_SwingParameters()
                                   {
                                       SwingID = temp.SwingID,
                                       LimitMove = LimitMove,
                                       TimePeriod = TimePeriod,
                                       SwingBandTimePeriod = BandTimePeriod,
                                   });
                               }

                               db.SaveChanges();

                               SwingIndicators.Add(new Model.SwingIndicator()
                               {
                                   Id = temp.SwingID,
                                   Name = Name,
                                   LimitMove = LimitMove,
                                   TimePeriod = TimePeriod,
                                   BandTimePeriod = BandTimePeriod
                               });
                           }
                           else
                           {
                               db.Tbl_Swing.First(p => p.SwingID == id).SwingName = name;
                               var temp=  db.Tbl_SwingParameters.First(p => p.SwingID == id);
                               temp.LimitMove = LimitMove;
                               temp.TimePeriod = TimePeriod;
                               db.SaveChanges();

                               SwingIndicators.Remove(selectedIndicator);
                               SwingIndicators.Add(new Model.SwingIndicator()
                               {
                                   Id = id,
                                   Name = Name,
                                   LimitMove = LimitMove,
                                   TimePeriod = TimePeriod,
                                   BandTimePeriod = BandTimePeriod,
                               });
                           }

                           Reset.Execute(null);
                       }
                   }, () =>
                   {
                       if (string.IsNullOrEmpty(Name) || LimitMove <= 0)
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
                       limitMove = 0;
                       id = 0;
                       TimePeriod = 5;
                       BandTimePeriod = 5;
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
                           SwingIndicators.Remove(SelectedIndicator);
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

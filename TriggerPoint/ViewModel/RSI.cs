using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.ViewModel
{
  public  class RSI:ViewModelBase
    {
      
       public RSI()
       {
           RSIIndicators = new ObservableCollection<Model.RSIIndicator>();
           setDefaultParameter();
           using (var db = new Data.TriggerPointContext())
           {
               var t = db.Tbl_RSI.Where(p => p.IsDelete == false).ToList();
               foreach (var item in t)
               {
                   var parameters = db.Tbl_RSIParameters.AsEnumerable().Where(p => p.RSIID == item.RSIID);

                   if (parameters != null)
                       RSIIndicators.Add(new Model.RSIIndicator()
                       {
                           Id = item.RSIID,
                           Name = item.RSIName,
                           FastPeriod =(int)(parameters.ElementAt(0).Value ??0),
                           SlowPeriod = (int)(parameters.ElementAt(1).Value ?? 0),
                           LowerLimit = (int)(parameters.ElementAt(2).Value ?? 0),
                           UpperLimit = (int)(parameters.ElementAt(3).Value ?? 0),
                       });
               }
           }
       }

       private void setDefaultParameter()
       {
           para1 = ConfigurationManager.AppSettings["RSIPara1"];
           para2 = ConfigurationManager.AppSettings["RSIPara2"];
           para3 = ConfigurationManager.AppSettings["RSIPara3"];
           para4 = ConfigurationManager.AppSettings["RSIPara4"];

       }

       #region Properties

       private string name;

       public string Name
       {
           get { return name; }
           set { name = value;
           RaisePropertyChanged("Name");
           }
       }

       private string _para1;

       public string para1
       {
           get { return _para1; }
           set { _para1 = value;
           RaisePropertyChanged("para1");
           }
       }

       private string _para2;

       public string para2
       {
           get { return _para2; }
           set
           {
               _para2 = value;
               RaisePropertyChanged("para2");
           }
       }

       private string _para3;

       public string para3
       {
           get { return _para3; }
           set
           {
               _para3 = value;
               RaisePropertyChanged("para3");
           }
       }

       private string _para4;

       public string para4
       {
           get { return _para4; }
           set
           {
               _para4 = value;
               RaisePropertyChanged("para4");
           }
       }

       private int _value1;

       public int value1
       {
           get { return _value1; }
           set { _value1 = value;
           RaisePropertyChanged("value1");
           }
       }

       private int _value2;

       public int value2
       {
           get { return _value2; }
           set
           {
               _value2 = value;
               RaisePropertyChanged("value2");
           }
       }

       private int _value3;

       public int value3
       {
           get { return _value3; }
           set
           {
               _value3 = value;
               RaisePropertyChanged("value3");
           }
       }

       private int _value4;

       public int value4
       {
           get { return _value4; }
           set
           {
               _value4 = value;
               RaisePropertyChanged("value4");
           }
       }

       public ObservableCollection<Model.RSIIndicator> RSIIndicators { get; set; }

       private Model.RSIIndicator selectedIndicator;

       public Model.RSIIndicator SelectedIndicator
       {
           get { return selectedIndicator; }
           set {
               if(value == null) return;
               selectedIndicator = value;
           RaisePropertyChanged("SelectedIndicator");
           
           Name = SelectedIndicator.Name;
               value1 = SelectedIndicator.FastPeriod;
               value2 = selectedIndicator.SlowPeriod;
               value3 = selectedIndicator.LowerLimit;
               value4 = selectedIndicator.UpperLimit;
               id = selectedIndicator.Id;
           }
       }
       int id = 0;
       #endregion

       #region Commands

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
                           var m = db.Tbl_RSI.Add(new Data.Tbl_RSI()
                                {
                                    RSIName = Name,
                                    IsDelete = false,
                                });

                           db.SaveChanges();

                           db.Tbl_RSIParameters.Add(new Data.Tbl_RSIParameters()
                               {
                                   RSIID = m.RSIID,
                                   Name = para1,
                                   Value = value1,
                               });
                           db.Tbl_RSIParameters.Add(new Data.Tbl_RSIParameters()
                           {
                               RSIID = m.RSIID,
                               Name = para2,
                               Value = value2,
                           });
                           db.Tbl_RSIParameters.Add(new Data.Tbl_RSIParameters()
                           {
                               RSIID = m.RSIID,
                               Name = para3,
                               Value = value3,
                           });
                           db.Tbl_RSIParameters.Add(new Data.Tbl_RSIParameters()
                           {
                               RSIID = m.RSIID,
                               Name = para4,
                               Value = value4,
                           });

                           db.SaveChanges();

                           RSIIndicators.Add(new Model.RSIIndicator()
                            {
                                Id = m.RSIID,
                                Name = Name,
                                FastPeriod = value1,
                                SlowPeriod = value2,
                                LowerLimit = value3,
                                UpperLimit = value4,
                            });
                       }
                       else
                       {
                           db.Tbl_RSI.First(p => p.RSIID == id).RSIName = name;

                           var pm = db.Tbl_RSIParameters.Where(p => p.RSIID == id);

                           foreach (var item in pm)
                               db.Tbl_RSIParameters.Remove(item);


                           db.Tbl_RSIParameters.Add(new Data.Tbl_RSIParameters()
                           {
                               RSIID = id,
                               Name = para1,
                               Value = value1,
                           });
                           db.Tbl_RSIParameters.Add(new Data.Tbl_RSIParameters()
                           {
                               RSIID = id,
                               Name = para2,
                               Value = value2,
                           });
                           db.Tbl_RSIParameters.Add(new Data.Tbl_RSIParameters()
                           {
                               RSIID = id,
                               Name = para3,
                               Value = value3,
                           });
                           db.Tbl_RSIParameters.Add(new Data.Tbl_RSIParameters()
                           {
                               RSIID = id,
                               Name = para4,
                               Value = value4,
                           });


                           db.SaveChanges();

                           RSIIndicators.Remove(selectedIndicator);

                           RSIIndicators.Add(new Model.RSIIndicator()
                           {
                               Id =id,
                               Name = Name,
                               FastPeriod = value1,
                               SlowPeriod = value2,
                               LowerLimit = value3,
                               UpperLimit = value4,
                           });
                       }

                       Reset.Execute(null);
                   }
               }, () =>
               {
                   if (string.IsNullOrEmpty(Name) )
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
                   value1 = value2 = value3=value4 = 0;
                   setDefaultParameter();
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
                       var t = db.Tbl_RSI.Where(p => p.RSIID == SelectedIndicator.Id).First();
                       t.IsDelete = true;

                       db.SaveChanges();
                       RSIIndicators.Remove(SelectedIndicator);
                   }
               }, () =>
               {
                   if (SelectedIndicator == null)
                       return false;
                   return true;
               }));
           }
       }

       #endregion

      
    }
}

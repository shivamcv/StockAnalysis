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
  public  class Stochastic : ViewModelBase
    {

      public Stochastic()
      {
          StochasticIndicators = new ObservableCollection<Model.StochasticIndicator>();
          setDefaultParameter();
          using (var db = new Data.TriggerPointContext())
          {
              var t = db.Tbl_Stochastic.Where(p => p.IsDelete == false).ToList();
              foreach (var item in t)
              {
                  var parameters = db.Tbl_StochasticParameters.AsEnumerable().Where(p => p.StochasticID == item.StochasticID);

                  if (parameters != null)
                      StochasticIndicators.Add(new Model.StochasticIndicator()
                      {
                          Id = item.StochasticID,
                          Name = item.StochasticName,
                          FastPeriod = (int)(parameters.ElementAt(0).Value ?? 0),
                          SlowPeriod = (int)(parameters.ElementAt(1).Value ?? 0),
                          LowerLimit = (int)(parameters.ElementAt(2).Value ?? 0),
                          UpperLimit = (int)(parameters.ElementAt(3).Value ?? 0),
                      });
              }
          }
      }

       private void setDefaultParameter()
       {
           para1 = ConfigurationManager.AppSettings["StochasticPara1"];
           para2 = ConfigurationManager.AppSettings["StochasticPara2"];
           para3 = ConfigurationManager.AppSettings["StochasticPara3"];
           para4 = ConfigurationManager.AppSettings["StochasticPara4"];

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

       public ObservableCollection<Model.StochasticIndicator> StochasticIndicators { get; set; }

       private Model.StochasticIndicator selectedIndicator;

       int id = 0;
       public Model.StochasticIndicator SelectedIndicator
       {
           get { return selectedIndicator; }
           set {
               if (value == null) return;
               selectedIndicator = value;
           RaisePropertyChanged("SelectedIndicator");

           Name = selectedIndicator.Name;
           value1 = SelectedIndicator.FastPeriod;
           value2 = selectedIndicator.SlowPeriod;
           value3 = selectedIndicator.LowerLimit;
           value4 = selectedIndicator.UpperLimit;
           id = selectedIndicator.Id;

           }
       }
       
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
                           var m = db.Tbl_Stochastic.Add(new Data.Tbl_Stochastic()
                                {
                                    StochasticName = Name,
                                    IsDelete = false,
                                });

                           db.SaveChanges();

                           db.Tbl_StochasticParameters.Add(new Data.Tbl_StochasticParameters()
                               {
                                   StochasticID = m.StochasticID,
                                   Name = para1,
                                   Value = value1,
                               });
                           db.Tbl_StochasticParameters.Add(new Data.Tbl_StochasticParameters()
                           {
                               StochasticID = m.StochasticID,
                               Name = para2,
                               Value = value2,
                           });
                           db.Tbl_StochasticParameters.Add(new Data.Tbl_StochasticParameters()
                           {
                               StochasticID = m.StochasticID,
                               Name = para3,
                               Value = value3,
                           });
                           db.Tbl_StochasticParameters.Add(new Data.Tbl_StochasticParameters()
                           {
                               StochasticID = m.StochasticID,
                               Name = para4,
                               Value = value4,
                           });

                           db.SaveChanges();

                           StochasticIndicators.Add(new Model.StochasticIndicator()
                            {
                                Id = m.StochasticID,
                                Name = Name,
                                FastPeriod = value1,
                                SlowPeriod = value2,
                                LowerLimit = value3,
                                UpperLimit = value4,
                            });
                       }
                       else
                       {
                           db.Tbl_Stochastic.First(p => p.StochasticID == id).StochasticName = name;

                           var pm = db.Tbl_StochasticParameters.Where(p => p.StochasticID == id);

                           foreach (var item in pm)
                               db.Tbl_StochasticParameters.Remove(item);

                           db.Tbl_StochasticParameters.Add(new Data.Tbl_StochasticParameters()
                           {
                               StochasticID = id,
                               Name = para1,
                               Value = value1,
                           });
                           db.Tbl_StochasticParameters.Add(new Data.Tbl_StochasticParameters()
                           {
                               StochasticID = id,
                               Name = para2,
                               Value = value2,
                           });
                           db.Tbl_StochasticParameters.Add(new Data.Tbl_StochasticParameters()
                           {
                               StochasticID = id,
                               Name = para3,
                               Value = value3,
                           });
                           db.Tbl_StochasticParameters.Add(new Data.Tbl_StochasticParameters()
                           {
                               StochasticID = id,
                               Name = para4,
                               Value = value4,
                           });

                           db.SaveChanges();

                           StochasticIndicators.Remove(selectedIndicator);

                           StochasticIndicators.Add(new Model.StochasticIndicator()
                           {
                               Id = id,
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
                       var t = db.Tbl_Stochastic.Where(p => p.StochasticID == SelectedIndicator.Id).First();
                       t.IsDelete = true;

                       db.SaveChanges();
                       StochasticIndicators.Remove(SelectedIndicator);
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

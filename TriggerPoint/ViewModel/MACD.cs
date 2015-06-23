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
   public class MACD: ViewModelBase
   {
       public MACD()
       {
           MACDIndicators = new ObservableCollection<Model.MACDIndicator>();
           setDefaultParameter();
           using (var db = new Data.TriggerPointContext())
           {
               var t = db.Tbl_MACD.Where(p => p.IsDelete == false).ToList();
               foreach (var item in t)
               {
                   var parameters = db.Tbl_MACDParameters.AsEnumerable().Where(p => p.MACDID == item.MACDID);
                   var filter = db.Tbl_MACDFilters.AsEnumerable().FirstOrDefault(p => p.MACDID == item.MACDID);

                   if (parameters != null)
                       MACDIndicators.Add(new Model.MACDIndicator()
                       {
                           Id = item.MACDID,
                           Name = item.MACDName,
                           EMA1 =(int)(parameters.ElementAt(0).Value ??0),
                           EMA2 = (int)(parameters.ElementAt(1).Value ?? 0),
                           Signal = (int)(parameters.ElementAt(2).Value ?? 0),
                            IsBaseLine = filter.IsBaseLine??false,
                            Filter = filter.PercentageValue ??0,
                       });
               }
           }
       }

       private void setDefaultParameter()
       {
           para1 = ConfigurationManager.AppSettings["MACDPara1"];
           para2 = ConfigurationManager.AppSettings["MACDPara2"];
           para3 = ConfigurationManager.AppSettings["MACDPara3"];
       }

       #region Properties

       int id = 0;

       private bool isBaseline;

       public bool IsBaseline
       {
           get { return isBaseline; }
           set { isBaseline = value;
           RaisePropertyChanged("IsBaseline");
           }
       }

       private bool isPercentage=true;

       public bool IsPercentage
       {
           get { return isPercentage; }
           set { isPercentage = value;
           RaisePropertyChanged("IsPercentage");
           }
       }

       private bool isFixedValue;

       public bool IsFixedValue
       {
           get { return isFixedValue; }
           set { isFixedValue = value;
           RaisePropertyChanged("IsFixedValue");
           }
       }

       private double filter;

       public double Filter
       {
           get { return filter; }
           set { filter = value;
           RaisePropertyChanged("Filter");
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

       public ObservableCollection<Model.MACDIndicator> MACDIndicators { get; set; }

       private Model.MACDIndicator selectedIndicator;

       public Model.MACDIndicator SelectedIndicator
       {
           get { return selectedIndicator; }
           set 
           {
               if (value == null) return;

               selectedIndicator = value;
           RaisePropertyChanged("SelectedIndicator");
           id = selectedIndicator.Id;
           Name = SelectedIndicator.Name;
           value1 = SelectedIndicator.EMA1;
           value2 = selectedIndicator.EMA2;
           value3 = selectedIndicator.Signal;
           IsBaseline = selectedIndicator.IsBaseLine;
           Filter = selectedIndicator.Filter;
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
                           var m = db.Tbl_MACD.Add(new Data.Tbl_MACD()
                                {
                                    MACDName = Name,
                                    IsDelete = false,
                                });

                           db.SaveChanges();

                           db.Tbl_MACDFilters.Add(new Data.Tbl_MACDFilters()
                               {
                                   IsBaseLine = IsBaseline,
                                   MACDID = m.MACDID,
                                   IsPercentage = isPercentage,
                                   PercentageValue = filter,

                               });

                           db.Tbl_MACDParameters.Add(new Data.Tbl_MACDParameters()
                               {
                                   MACDID = m.MACDID,
                                   Name = para1,
                                   Value = value1,
                               });
                           db.Tbl_MACDParameters.Add(new Data.Tbl_MACDParameters()
                           {
                               MACDID = m.MACDID,
                               Name = para2,
                               Value = value2,
                           });
                           db.Tbl_MACDParameters.Add(new Data.Tbl_MACDParameters()
                           {
                               MACDID = m.MACDID,
                               Name = para3,
                               Value = value3,
                           });

                           db.SaveChanges();

                           MACDIndicators.Add(new Model.MACDIndicator()
                            {
                                Id = m.MACDID,
                                Name = Name,
                                EMA1 = value1,
                                EMA2 = value2,
                                Signal = value3,
                                IsBaseLine = IsBaseline,
                                Filter = Filter,
                            });
                       }
                       else
                       {
                           db.Tbl_MACD.First(p => p.MACDID == id).MACDName = name;
                           var f = db.Tbl_MACDFilters.First(p => p.MACDID == id);
                           f.IsBaseLine = IsBaseline;
                           f.IsPercentage = IsPercentage;
                           f.PercentageValue = Filter;

                           var pm= db.Tbl_MACDParameters.Where(p => p.MACDID == id);

                           foreach (var item in pm)
                               db.Tbl_MACDParameters.Remove(item);

                           db.Tbl_MACDParameters.Add(new Data.Tbl_MACDParameters()
                           {
                               MACDID = id,
                               Name = para1,
                               Value = value1,
                           });
                           db.Tbl_MACDParameters.Add(new Data.Tbl_MACDParameters()
                           {
                               MACDID = id,
                               Name = para2,
                               Value = value2,
                           });
                           db.Tbl_MACDParameters.Add(new Data.Tbl_MACDParameters()
                           {
                               MACDID = id,
                               Name = para3,
                               Value = value3,
                           });


                           db.SaveChanges();

                           MACDIndicators.Remove(SelectedIndicator);

                           MACDIndicators.Add(new Model.MACDIndicator()
                           {
                               Id = id,
                               Name = Name,
                               EMA1 = value1,
                               EMA2 = value2,
                               Signal = value3,
                               IsBaseLine = IsBaseline,
                               Filter = Filter,
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
                   IsBaseline = false;
                   value1 = value2 = value3 = 0;
                      Filter= 0;
                   IsPercentage = true;
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
                       var t = db.Tbl_MACD.Where(p => p.MACDID == SelectedIndicator.Id).First();
                       t.IsDelete = true;

                       db.SaveChanges();
                       MACDIndicators.Remove(SelectedIndicator);
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

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
    public class BollingerBand : ViewModelBase
    {
        public BollingerBand()
        {
            BollingerIndicators = new ObservableCollection<Model.BollingerIndicator>();
            using (var db = new Data.TriggerPointContext())
            {
                var t = db.Tbl_BollingerBand.Where(p => p.IsDelete == false).ToList();
                foreach (var item in t)
                {
                        BollingerIndicators.Add(new Model.BollingerIndicator()
                        {
                            Id = item.BollingerBandID,
                            Name = item.BollingerBandName,
                            TimePeriod = (int)item.Period,
                        });
                }
            }
        }

        public ObservableCollection<Model.BollingerIndicator> BollingerIndicators { get; set; }


        private String name;

        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }


        private int timePeriod;

        public int TimePeriod
        {
            get { return timePeriod; }
            set 
            { 
                
                timePeriod = value;
                RaisePropertyChanged("TimePeriod");
            }
        }


        private float standardDeviation;

        public float StandardDeviation
        {
            get { return standardDeviation; }
            set
            { 
                standardDeviation = value;
                RaisePropertyChanged("StandardDeviation");
            }
        }

        private RelayCommand submit;

        public RelayCommand Submit
        {
            get
            {
                return submit ?? (submit = new RelayCommand(() =>
                {
                    using (var db = new Data.TriggerPointContext())
                    {
                        Data.Tbl_BollingerBand temp;
                        if (id == 0)
                        {
                            temp = db.Tbl_BollingerBand.Add(new Data.Tbl_BollingerBand()
                            {
                                BollingerBandName = Name,
                                IsDelete = false,
                                Period = TimePeriod,
                                StdDiv = StandardDeviation,
                            });

                            db.SaveChanges();

                        }
                        else
                        {
                             temp = db.Tbl_BollingerBand.First(p => p.BollingerBandID == id);

                            temp.BollingerBandName = name;
                            temp.Period = TimePeriod;
                            temp.StdDiv = StandardDeviation;

                            db.SaveChanges();

                            BollingerIndicators.Remove(SelectedIndicator);

                            
                        }

                        BollingerIndicators.Add(new Model.BollingerIndicator()
                        {
                            Id = temp.BollingerBandID,
                            Name = Name,
                            TimePeriod = TimePeriod,
                            StandDeviation = StandardDeviation
                        });
                        Reset.Execute(null);
                    }
                }, () =>
                {
                    if (string.IsNullOrEmpty(Name) || TimePeriod <= 0 || StandardDeviation <=0)
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
                    StandardDeviation = 0;
                    id = 0;
                }));
            }
        }

        int id = 0;
        private RelayCommand delete;

        public RelayCommand Delete
        {
            get
            {
                return delete ?? (delete = new RelayCommand(() =>
                {
                    using (var db = new Data.TriggerPointContext())
                    {
                        var t = db.Tbl_BollingerBand.Where(p => p.BollingerBandID == SelectedIndicator.Id).First();
                        t.IsDelete = true;

                        db.SaveChanges();
                        BollingerIndicators.Remove(SelectedIndicator);
                    }
                }, () =>
                {
                    if (SelectedIndicator == null)
                        return false;
                    return true;
                }));
            }
        }


        private Model.BollingerIndicator selectedIndicator;

        public Model.BollingerIndicator SelectedIndicator
        {
            get { return selectedIndicator; }
            set
            {
                if (value == null) return;
                selectedIndicator = value;
                RaisePropertyChanged("SelectedIndicator");
                id = SelectedIndicator.Id;
                Name = selectedIndicator.Name;
                StandardDeviation = selectedIndicator.StandDeviation;
                TimePeriod = SelectedIndicator.TimePeriod;
            }
        }
       

    }
}

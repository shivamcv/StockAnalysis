using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TriggerPoint.Data;
using TriggerPoint.HelperClasses;
using TriggerPoint.Model;

namespace TriggerPoint.ViewModel
{
  public class StochasticDialogViewModel:ViewModelBase
    {
        DateTime startTime, endTime;
        List<int> ScriptIds;
        int TimePeriod;
        string notificationQuery;
        StochasticIndicator currentIndicator;

        public ObservableCollection<Model.StochasticData> ScriptData { get; set; }

        public StochasticDialogViewModel(DateTime startDate, DateTime endDate, int StochasticId, List<int> scriptId, int recordMinutes)
        {
            ScriptIds = scriptId;
            startTime = startDate;
            endTime = endDate;
            TimePeriod = recordMinutes;

            ScriptData = new ObservableCollection<StochasticData>();

            using (var db = new TriggerPointContext())
            {
                //Initialise
                var para = db.Tbl_StochasticParameters.Where(p => p.StochasticID == StochasticId).AsEnumerable();

                currentIndicator = new StochasticIndicator()
                {
                    FastPeriod = (int)(para.ElementAt(0).Value ??0),
                    SlowPeriod = (int)(para.ElementAt(1).Value ??0),
                    LowerLimit = (int)(para.ElementAt(2).Value ??0),
                    UpperLimit = (int)(para.ElementAt(3).Value ??0)
                };

                currentIndicator.Name = db.Tbl_Stochastic.First(p => p.StochasticID == StochasticId).StochasticName;
                //
            }

            Task.Factory.StartNew(() =>
            {
                LoadInitialData();
            });
        }

        private void LoadInitialData()
        {
            IsLoading = true;
            using (var db = new Data.TriggerPointContext())
            {
                List<Model.StochasticData> temp = new List<Model.StochasticData>();

                 progressCtr = 0;
                switch (TimePeriod)
                {
                    //"5","10","15","20","30","45","60","90","120","EOD" 
                    case 5:
                        {
                            var cc = db.Tbl_Script5Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new StochasticData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 10:
                        {
                            var cc = db.Tbl_Script10Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new StochasticData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 15:
                        {
                            var cc = db.Tbl_Script15Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new StochasticData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 20:
                        {
                            var cc = db.Tbl_Script20Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new StochasticData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 30:
                        {
                            var cc = db.Tbl_Script30Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new StochasticData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 45:
                        {
                            var cc = db.Tbl_Script45Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new StochasticData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 60:
                        {
                            var cc = db.Tbl_Script60Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new StochasticData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 90:
                        {
                            var cc = db.Tbl_Script90Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new StochasticData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 120:
                        {
                            var cc = db.Tbl_Script120Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new StochasticData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    default:
                        {
                            var cc = db.Tbl_ScriptEOD.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new StochasticData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                }


                notificationQuery = "SELECT Company FROM dbo.Tbl_Script where Company IN (" + string.Join(",", ScriptIds) + ")";

                if (temp.Any())
                {
                    CalculateStochastic(temp);
                }

                DispatcherHelper.UIDispatcher.BeginInvoke((Action)delegate
                {
                    temp.Reverse();
                    foreach (var item in temp)
                    {
                        item.StochasticDataId = temp.Count - ScriptData.Count();
                        ScriptData.Add(item);
                    }
                });
            }

            try
            {
                SqlDependency.Start(ViewModel.Connection.getProviderConnectionstring());
                startNotifier();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service Broker for database is not enabled, so changes will not be sync");
                ErrorReporting.Report(ex, "Service broker");
            }
            IsLoading = false;
        }

        private void startNotifier()
        {
            SqlConnection connection = new SqlConnection(ViewModel.Connection.getProviderConnectionstring());

            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            using (SqlCommand command = new SqlCommand(
                notificationQuery,
                connection))
            {

                SqlDependency dependency = new SqlDependency(command);

                dependency.OnChange += new
                   OnChangeEventHandler(OnDependencyChange);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                }

            }
            connection.Close();
        }

        DateTime timeMark = DateTime.Now.Date;
        private void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info == SqlNotificationInfo.Insert)
                using (var db = new Data.TriggerPointContext())
                {

                    foreach (var id in ScriptIds)
                    {
                        var temp = db.Tbl_Script.Where(p => p.Company == id && p.Datetime > timeMark).AsEnumerable()
                                           .GroupBy(p => groupScript(p, TimeSpan.FromMinutes(TimePeriod)))
                                                      .Select(p => new StochasticData()
                                                      {
                                                          ScriptId = p.First().Company ?? 0,
                                                          ScriptName = getScriptName(p.First().Company),
                                                          Open = p.Where(q => q.Datetime == p.Min(w => w.Datetime)).First().LowReadings ?? 0,
                                                          Low = p.Min(q => q.LowReadings) ?? 0,
                                                          High = p.Max(q => q.LowReadings) ?? 0,
                                                          DateTime = (DateTime)p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
                                                          DateTimeSlot = DateTime.Now.Date + TimeSpan.FromMinutes(p.Key),
                                                          Close = p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().LowReadings ?? 0,
                                                          RecordId = p.First().ID,
                                                      }).OrderBy(p => p.DateTime).ToList();

                        if (temp.Any())
                            DispatcherHelper.UIDispatcher.BeginInvoke((Action)delegate
                            {
                                var grps = ScriptData.GroupBy(p => p.ScriptId).ToList();
                                foreach (var item in temp)
                                {
                                    var lastValue = ScriptData.First(p => p.ScriptId == item.ScriptId && (p.DateTimeSlot != item.DateTimeSlot || p.DateTimeSlot == null));

                                    item.HighestHigh_MiddlePeriod = Math.Round( lastValue.HighestHigh_MiddlePeriod > item.High ? lastValue.HighestHigh_MiddlePeriod : item.High , 2);
                                    item.LowestLow_MiddlePeriod = Math.Round(lastValue.LowestLow_MiddlePeriod > item.Low ? lastValue.LowestLow_MiddlePeriod : item.Low, 2);
                                    if ((item.HighestHigh_MiddlePeriod - item.LowestLow_MiddlePeriod) == 0)
                                    {
                                        item.StochasticOscillator_MiddlePeriod = 0;
                                    }
                                    else
                                    {
                                       item.StochasticOscillator_MiddlePeriod = Math.Round(((item.Close) - item.LowestLow_MiddlePeriod) / (item.HighestHigh_MiddlePeriod - item.LowestLow_MiddlePeriod) * 100, 2);
                                    }


                                    item.HighestHigh_UpperPeriod = Math.Round(lastValue.HighestHigh_UpperPeriod > item.High ? lastValue.HighestHigh_UpperPeriod : item.High, 2);
                                    item.LowestLow_UpperPeriod = Math.Round(lastValue.LowestLow_UpperPeriod > item.Low ? lastValue.LowestLow_UpperPeriod : item.Low, 2);
                                    if ((item.HighestHigh_UpperPeriod - item.LowestLow_UpperPeriod) == 0)
                                    {
                                        item.StochasticOscillator_UpperPeriod = 0;
                                    }
                                    else
                                    {
                                        item.StochasticOscillator_UpperPeriod = Math.Round(((item.Close) - item.LowestLow_UpperPeriod) / (item.HighestHigh_UpperPeriod - item.LowestLow_UpperPeriod) * 100, 2);
                                    }

                                    var lastEntry = ScriptData.FirstOrDefault(p => p.DateTimeSlot == timeMark && p.ScriptId == id);

                                    if (lastEntry != null)
                                    {
                                        lastEntry.Open = item.Open;
                                        lastEntry.High = item.High;
                                        lastEntry.Low = item.Low;
                                        lastEntry.Close = item.Close;
                                        lastEntry.DateTime = item.DateTime;
                                        lastEntry.LowestLow_UpperPeriod = item.LowestLow_UpperPeriod;
                                        lastEntry.LowestLow_MiddlePeriod = item.LowestLow_MiddlePeriod;
                                        lastEntry.HighestHigh_UpperPeriod = item.HighestHigh_UpperPeriod;
                                        lastEntry.HighestHigh_MiddlePeriod = item.HighestHigh_MiddlePeriod;
                                        lastEntry.StochasticOscillator_MiddlePeriod = item.StochasticOscillator_MiddlePeriod;
                                        lastEntry.StochasticOscillator_UpperPeriod = item.StochasticOscillator_UpperPeriod;
                                    }
                                    else
                                        ScriptData.Insert(0, item);
                                }

                           
                            });
                    }

                    timeMark = DateTime.Now.Date + TimeSpan.FromMinutes((int)(DateTime.Now.TimeOfDay.TotalMinutes / TimePeriod) * TimePeriod);
                }
            startNotifier();

        }

        int progressCtr = 0;
        private int getRecordId(int p, int length)
        {
            Progress = (float)progressCtr++ / (float)length;
            return p;
        }
        private float progress;
        public float Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                RaisePropertyChanged("Progress");
            }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }
      
        public static double groupScript(Tbl_Script p, TimeSpan t)
        {
            return (int)(p.Datetime.Value.TimeOfDay.TotalMinutes / t.TotalMinutes) * t.TotalMinutes;
        }

        private string getScriptName(int? scriptid)
        {
            using (var db = new Data.TriggerPointContext())
            {
                return db.Tbl_ScriptMaster.FirstOrDefault(p => p.ID == scriptid).ScriptName;
            }
        }

        private void CalculateStochastic(List<StochasticData> temp)
        {
            using (var db = new TriggerPointContext())
            {
                var grps = temp.GroupBy(p => p.ScriptId);
                foreach (var scriptData in grps)
                {
                    for (int i = currentIndicator.SlowPeriod - 1; i < scriptData.Count(); i++)
                    {
                        scriptData.ElementAt(i).HighestHigh_MiddlePeriod = Math.Round( scriptData.Skip(i - (currentIndicator.SlowPeriod - 1)).Take(currentIndicator.SlowPeriod).Max(s => (s.High)),2);
                        scriptData.ElementAt(i).LowestLow_MiddlePeriod = Math.Round( scriptData.Skip(i - (currentIndicator.SlowPeriod - 1)).Take(currentIndicator.SlowPeriod).Min(s => (s.Low)),2);
                        if ((scriptData.ElementAt(i).HighestHigh_MiddlePeriod - scriptData.ElementAt(i).LowestLow_MiddlePeriod) == 0)
                        {
                            scriptData.ElementAt(i).StochasticOscillator_MiddlePeriod = 0;
                        }
                        else
                        {
                            scriptData.ElementAt(i).StochasticOscillator_MiddlePeriod = Math.Round(((scriptData.ElementAt(i).Close ) - scriptData.ElementAt(i).LowestLow_MiddlePeriod) / (scriptData.ElementAt(i).HighestHigh_MiddlePeriod - scriptData.ElementAt(i).LowestLow_MiddlePeriod) * 100,2);
                        }
                    }
                    // / ============= For Middle Period ============= 

                    // ============= For Upper Period ============= 
                    for (int i = currentIndicator.FastPeriod - 1; i < scriptData.Count(); i++)
                    {
                        scriptData.ElementAt(i).HighestHigh_UpperPeriod =Math.Round( scriptData.Skip(i - (currentIndicator.FastPeriod - 1)).Take(currentIndicator.FastPeriod).Max(s => (s.High)),2);
                        scriptData.ElementAt(i).LowestLow_UpperPeriod =Math.Round( scriptData.Skip(i - (currentIndicator.FastPeriod - 1)).Take(currentIndicator.FastPeriod).Min(s => (s.Low )),2);
                        if ((scriptData.ElementAt(i).HighestHigh_UpperPeriod - scriptData.ElementAt(i).LowestLow_UpperPeriod) == 0)
                        {
                            scriptData.ElementAt(i).StochasticOscillator_UpperPeriod = 0;
                        }
                        else
                        {
                            scriptData.ElementAt(i).StochasticOscillator_UpperPeriod = Math.Round( ((scriptData.ElementAt(i).Close) - scriptData.ElementAt(i).LowestLow_UpperPeriod) / (scriptData.ElementAt(i).HighestHigh_UpperPeriod - scriptData.ElementAt(i).LowestLow_UpperPeriod) * 100,2);
                        }
                    }

                }
            }


        }
    }
}

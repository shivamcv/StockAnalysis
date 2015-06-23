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
using TriggerPoint.HelperClasses;
using TriggerPoint.Model;

namespace TriggerPoint.ViewModel
{
    public class BollingerDialogViewModel :ViewModelBase
    {
        DateTime startTime, endTime;
        CalculateTypes CalType;
        int  TimePeriod, bollingerPeriod;
        double stdDiv;
        List<int> ScriptIds;

        string notificationQuery;

        public ObservableCollection<Model.BollingerData> ScriptData { get; set; }

        public BollingerDialogViewModel(DateTime startDate, DateTime endDate, int bollingerId, List<int> scriptId, int recordMinutes)
        {
            startTime = startDate;
            endTime = endDate;

            ScriptIds = scriptId;
            TimePeriod = recordMinutes;

            ScriptData = new ObservableCollection<Model.BollingerData>();

            using (var db = new Data.TriggerPointContext())
            {
                var parameter = db.Tbl_BollingerBand.FirstOrDefault(p => p.BollingerBandID == bollingerId);

                if (parameter == null)
                {
                    ErrorReporting.Report(new InvalidOperationException(), "Bollingerid not found");
                    return;
                }
                else
                {
                    bollingerPeriod = parameter.Period == null ? 0 : (int)parameter.Period;
                    stdDiv = parameter.StdDiv??0;
                }

            }


            Task.Factory.StartNew(() =>
            {
                LoadInitialData();
            });
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
      

        private void LoadInitialData()
        {
            IsLoading = true;
            using (var db = new Data.TriggerPointContext())
            {
                List<Model.BollingerData> temp = new List<Model.BollingerData>();

                progressCtr = 0;
                switch (TimePeriod)
                {
                    //"5","10","15","20","30","45","60","90","120","EOD" 
                    case 5:
                        {
                            var cc = db.Tbl_Script5Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new BollingerData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 10:
                        {
                            var cc = db.Tbl_Script10Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new BollingerData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 15:
                        {
                            var cc = db.Tbl_Script15Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new BollingerData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 20:
                        {
                            var cc = db.Tbl_Script20Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new BollingerData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 30:
                        {
                            var cc = db.Tbl_Script30Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new BollingerData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 45:
                        {
                            var cc = db.Tbl_Script45Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new BollingerData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 60:
                        {
                            var cc = db.Tbl_Script60Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new BollingerData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 90:
                        {
                            var cc = db.Tbl_Script90Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new BollingerData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 120:
                        {
                            var cc = db.Tbl_Script120Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new BollingerData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    default:
                        {
                            var cc = db.Tbl_ScriptEOD.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new BollingerData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                }

                notificationQuery = "SELECT Company FROM dbo.Tbl_Script where Company IN (" + string.Join(",", ScriptIds) + ")";

                if (temp.Any())
                   CalculateBollingerBand(temp);

                DispatcherHelper.UIDispatcher.BeginInvoke((Action)delegate
                {
                    temp.Reverse();
                    foreach (var item in temp)
                    {
                        item.id = temp.Count - ScriptData.Count();
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

        private void CalculateBollingerBand(List<BollingerData> scriptData)
        {
             var grps = scriptData.GroupBy(p => p.ScriptId);
             foreach (var grp in grps)
             {
                 for (int i = bollingerPeriod - 1; i < grp.Count(); i++)
                 {
                     // Calculation of SMA
                     grp.ElementAt(i).SMA = Math.Round(grp.Skip(i - (bollingerPeriod - 1)).Take(bollingerPeriod).Average(s => (s.Close )), 2);

                     // Calculation of Standard Deviation
                     grp.ElementAt(i).StandardDeviation = Math.Round(grp.Skip(i - (bollingerPeriod - 1)).Take(bollingerPeriod).Select(s => (s.Close )).StandardDeviation(), 2);

                     // Calculation of Deviations
                     grp.ElementAt(i).Deviations = Math.Round(grp.ElementAt(i).StandardDeviation * (decimal)stdDiv, 2);

                     // Calculation of Upper Band
                     grp.ElementAt(i).UpperBand = Math.Round(grp.ElementAt(i).SMA + grp.ElementAt(i).Deviations, 2);

                     // Calculation of Lower Band
                     grp.ElementAt(i).LowerBand = Math.Round(grp.ElementAt(i).SMA - grp.ElementAt(i).Deviations, 2);
                 }
             }
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
                                                                .GroupBy(p =>AverageDialogViewModel.groupScript(p, TimeSpan.FromMinutes(TimePeriod)))
                                                                           .Select(p => new BollingerData()
                                                                           {
                                                                               ScriptId = p.First().Company ?? 0,
                                                                               ScriptName = getScriptName(p.First().Company),
                                                                               Open = p.Where(q => q.Datetime == p.Min(w => w.Datetime)).First().LowReadings ?? 0,
                                                                               Low = p.Min(q => q.LowReadings) ?? 0,
                                                                               High = p.Max(q => q.LowReadings) ?? 0,
                                                                               DateTimeSlot = DateTime.Now.Date + TimeSpan.FromMinutes(p.Key),
                                                                               DateTime = p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
                                                                               Date= p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime ?? new DateTime(),
                                                                               Time = p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime ?? new DateTime(),
                                                                               Close = p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().LowReadings ?? 0,
                                                                               RecordId = p.First().ID,
                                                                           }).OrderBy(p => p.DateTime).ToList();

                        if (temp.Any())
                            DispatcherHelper.UIDispatcher.BeginInvoke((Action)delegate
                            {
                                var grps = ScriptData.GroupBy(p => p.ScriptId).ToList();
                                for (int i = 0; i < temp.Count; i++)
                                {
                                    var oldData = grps.First(p => p.Key == temp[i].ScriptId);
                                    temp[i].id = ScriptData.Count() + 1;

                                    // Calculation of SMA
                                    temp[i].SMA = Math.Round(oldData.Take(bollingerPeriod).Average(s => (s.Close)), 2);

                                    // Calculation of Standard Deviation
                                    temp[i].StandardDeviation = Math.Round(oldData.Take(bollingerPeriod).Select(s => (s.Close)).StandardDeviation(), 2);

                                    // Calculation of Deviations
                                    temp[i].Deviations = Math.Round(temp[i].StandardDeviation * (decimal)stdDiv, 2);

                                    // Calculation of Upper Band
                                    temp[i].UpperBand = Math.Round(temp[i].SMA + temp[i].Deviations, 2);

                                    // Calculation of Lower Band
                                    temp[i].LowerBand = Math.Round(temp[i].SMA - temp[i].Deviations, 2);


                                    var lastEntry = ScriptData.FirstOrDefault(p => p.DateTimeSlot == timeMark && p.ScriptId == id);

                                    if (lastEntry != null)
                                    {
                                        lastEntry.SMA = temp[i].SMA;
                                        lastEntry.StandardDeviation = temp[i].StandardDeviation;
                                        lastEntry.Deviations = temp[i].Deviations;
                                        lastEntry.UpperBand = temp[i].UpperBand;
                                        lastEntry.LowerBand = temp[i].LowerBand;
                                        lastEntry.Open = temp[i].Open;
                                        lastEntry.High = temp[i].High;
                                        lastEntry.Low = temp[i].Low;
                                        lastEntry.Close = temp[i].Close;
                                        lastEntry.DateTime = temp[i].DateTime;
                                        lastEntry.Date= temp[i].DateTime ?? new DateTime();
                                        lastEntry.Time = temp[i].DateTime ?? new DateTime();
                                        
                                    }
                                    else
                                        ScriptData.Insert(0, temp[i]);

                                }
                            });
                    }
                    timeMark = DateTime.Now.Date + TimeSpan.FromMinutes((int)(DateTime.Now.TimeOfDay.TotalMinutes / TimePeriod) * TimePeriod);

                }
            startNotifier();

        }


        private string getScriptName(int? scriptid)
        {
            using (var db = new Data.TriggerPointContext())
            {
                return db.Tbl_ScriptMaster.FirstOrDefault(p => p.ID == scriptid).ScriptName;
            }
        }
    }
}

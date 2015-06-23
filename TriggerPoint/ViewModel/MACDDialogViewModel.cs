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
    public class MACDDialogViewModel : ViewModelBase
    {
        DateTime startTime, endTime;
        List<int> ScriptIds;
        int TimePeriod;
        string notificationQuery;
        MACDIndicator currentIndicator;

        public ObservableCollection<Model.MACDData> ScriptData { get; set; }

        public MACDDialogViewModel(DateTime startDate, DateTime endDate, int macdId, List<int> scriptId, int recordMinutes)
        {
            ScriptIds = scriptId;
            startTime = startDate;
            endTime = endDate;
            TimePeriod = recordMinutes;

            ScriptData = new ObservableCollection<MACDData>();

            using (var db = new TriggerPointContext())
            {
                //Initialise
                var para = db.Tbl_MACDParameters.Where(p => p.MACDID == macdId).AsEnumerable();

                currentIndicator = new MACDIndicator()
                {
                    EMA1 = (int)(para.ElementAt(0).Value ?? 0),
                    EMA2 = (int)(para.ElementAt(1).Value ?? 0),
                    Signal = (int)(para.ElementAt(2).Value ?? 0),
                };

                var filter = db.Tbl_MACDFilters.First(p => p.MACDID == macdId);

                currentIndicator.IsBaseLine = filter.IsBaseLine ?? false;
                currentIndicator.Filter = filter.PercentageValue ?? 0;
                currentIndicator.Name = db.Tbl_MACD.First(p => p.MACDID == macdId).MACDName;
                //
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
                List<Model.MACDData> temp = new List<Model.MACDData>();

                progressCtr = 0;
                switch (TimePeriod)
                {
                    //"5","10","15","20","30","45","60","90","120","EOD" 
                    case 5:
                        {
                            var cc = db.Tbl_Script5Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new MACDData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 10:
                        {
                            var cc = db.Tbl_Script10Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new MACDData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
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
                            temp = cc.Select(p => new MACDData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
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
                            temp = cc.Select(p => new MACDData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
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
                            temp = cc.Select(p => new MACDData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
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
                            temp = cc.Select(p => new MACDData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
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
                            temp = cc.Select(p => new MACDData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
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
                            temp = cc.Select(p => new MACDData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
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
                            temp = cc.Select(p => new MACDData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
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
                            temp = cc.Select(p => new MACDData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
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
                    CalculateMACD(temp);
                }

                DispatcherHelper.UIDispatcher.BeginInvoke((Action)delegate
                {
                    temp.Reverse();
                    foreach (var item in temp)
                    {
                        item.MACDDataId = temp.Count - ScriptData.Count();
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
                                                      .Select(p => new MACDData()
                                                      {
                                                          ScriptId = p.First().Company ?? 0,
                                                          ScriptName = getScriptName(p.First().Company),
                                                          Open = p.Where(q => q.Datetime == p.Min(w => w.Datetime)).First().LowReadings ?? 0,
                                                          Low = p.Min(q => q.LowReadings) ?? 0,
                                                          High = p.Max(q => q.LowReadings) ?? 0,
                                                          DateTime = (DateTime)p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
                                                          Time = (DateTime)p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
                                                          Date = (DateTime)p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
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
                                        item.MACDDataId = ScriptData.Count() + 1;

                                        var lastValue = ScriptData.First(p => p.ScriptId == item.ScriptId && (p.DateTimeSlot != item.DateTimeSlot || p.DateTimeSlot==null));

                                        item.EMA1 = Math.Round((((item.Close ?? 0) * (2 / (decimal)(currentIndicator.EMA1 + 1))) + (lastValue.EMA1 * (1 - (2 / (decimal)(currentIndicator.EMA1 + 1))))), 2);

                                        item.EMA2 = Math.Round(((item.Close ?? 0) * (2 / (decimal)(currentIndicator.EMA2 + 1)) + lastValue.EMA2 * (1 - (2 / (decimal)(currentIndicator.EMA2 + 1)))), 2);

                                        if (item.EMA2 > 0)
                                        {
                                            // MACD = EMA1 - EMA2
                                            item.MACD = Math.Round(item.EMA1 - item.EMA2, 2);
                                        }
                                        else
                                        {
                                            item.MACD = 0;
                                        }
                                        // --------- Calculation of EMA2 & MACD

                                        if (item.MACD != 0)
                                        {
                                            // Calculation of Signal
                                            item.Signal = Math.Round(
                                                     (item.MACD * (2 / (decimal)(currentIndicator.Signal + 1)) +
                                                      lastValue.Signal * (1 - (2 / (decimal)(currentIndicator.Signal + 1)))), 2);

                                            // --------- Calculation of Signal

                                            // Calculation of % Percentage
                                            item.Percentage = Math.Round(100 * (item.MACD / (item.Close ?? 1)), 2);
                                            // --------- Calculation of % Percentage

                                            // Calculation of Histogram
                                            item.Histogram = item.MACD - item.Signal;
                                            // --------- Calculation of Histogram

                                            // Calculation of TragetGen [i.e. Call Generation]
                                            if (currentIndicator.IsBaseLine)
                                            {
                                                if (Math.Sign(item.Histogram) != Math.Sign(lastValue.Histogram) &&
                                                    Math.Sign(item.Histogram) != Math.Sign(item.Signal) &&
                                                    Math.Abs(item.Percentage) >= Math.Abs((decimal)currentIndicator.Filter))
                                                {
                                                    item.BuySellPrice = null;
                                                    if (Math.Sign(item.Histogram) > 0)
                                                    {
                                                        item.TragetGen = CallTypes.BuyCall;
                                                        item.BuySellPrice = item.Close;
                                                    }
                                                    else if (Math.Sign(item.Histogram) < 0)
                                                    {
                                                        item.TragetGen = CallTypes.SellCall;
                                                        item.BuySellPrice = item.Close;
                                                    }
                                                }
                                            }

                                        }
                                        var lastEntry = ScriptData.FirstOrDefault(p => p.DateTimeSlot == timeMark && p.ScriptId == id);

                                        if (lastEntry != null)
                                        {
                                            lastEntry.EMA2 = item.EMA2;
                                            lastEntry.EMA1 = item.EMA1;
                                            lastEntry.Signal = item.Signal;
                                            lastEntry.TragetGen = item.TragetGen;
                                            lastEntry.Percentage = item.Percentage;
                                            lastEntry.BuySellPrice = item.BuySellPrice;
                                            lastEntry.Histogram = item.Histogram;
                                            lastEntry.Open = item.Open;
                                            lastEntry.High = item.High;
                                            lastEntry.Low = item.Low;
                                            lastEntry.Close = item.Close;
                                            lastEntry.DateTime = item.DateTime;
                                            lastEntry.Date = item.Date;
                                            lastEntry.Time = item.Time;
                                            lastEntry.MACD = item.MACD;
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

        private void CalculateMACD(List<MACDData> temp)
        {
            using (var db = new TriggerPointContext())
            {
                var grps = temp.GroupBy(p => p.ScriptId);
                foreach (var scriptData in grps)
                {
                    decimal EMA1_Sum = 0, EMA1_lastValue = 0;
                    decimal EMA2_Sum = 0, EMA2_lastValue = 0;
                    decimal Signal_Sum = 0, Signal_lastValue = 0;

                    for (int i = 0; i < scriptData.Count(); i++)
                    {
                        // Calculation of EMA1

                        if (i < currentIndicator.EMA1 - 1)
                        {
                            // Adding to sum for average of first top FastStrategy_Days CloseReadings
                            EMA1_Sum += (scriptData.ElementAt(i).Close ?? 0);
                            scriptData.ElementAt(i).EMA1 = 0;
                        }
                        else if (i == currentIndicator.EMA1 - 1)
                        {
                            // Calculating average of first top FastStrategy_Days CloseReadings
                            EMA1_Sum += (scriptData.ElementAt(i).Close ?? 0);
                            scriptData.ElementAt(i).EMA1 = Math.Round(EMA1_Sum / (decimal)currentIndicator.EMA1, 2);
                            EMA1_lastValue = scriptData.ElementAt(i).EMA1;
                        }
                        else
                        {
                            // EMA1 = Close * (2 / (FastStrategy_Days + 1)) + EMA1_lastValue * (1 - (2 / (FastStrategy_Days + 1))))
                            scriptData.ElementAt(i).EMA1 =
                                Math.Round(
                                    (((scriptData.ElementAt(i).Close ?? 0) * (2 / (decimal)(currentIndicator.EMA1 + 1))) +
                                     (EMA1_lastValue * (1 - (2 / (decimal)(currentIndicator.EMA1 + 1))))), 2);
                            EMA1_lastValue = scriptData.ElementAt(i).EMA1;
                        }
                        // --------- Calculation of EMA1


                        // Calculation of EMA2 & MACD

                        if (i < currentIndicator.EMA2 - 1)
                        {
                            // Adding to sum for average of first top SlowStrategy_Days CloseReadings
                            EMA2_Sum += (scriptData.ElementAt(i).Close ?? 0);
                            scriptData.ElementAt(i).EMA2 = 0;
                        }
                        else if (i == currentIndicator.EMA2 - 1)
                        {
                            // Calculating average of first top SlowStrategy_Days CloseReadings
                            EMA2_Sum += (scriptData.ElementAt(i).Close ?? 0);
                            scriptData.ElementAt(i).EMA2 = Math.Round(EMA2_Sum / (decimal)currentIndicator.EMA2, 2);
                            EMA2_lastValue = scriptData.ElementAt(i).EMA2;
                        }
                        else
                        {
                            // EMA2 = Close * (2 / (SlowStrategy_Days + 1)) + EMA2_lastValue * (1 - (2 / (SlowStrategy_Days + 1))))
                            scriptData.ElementAt(i).EMA2 =
                                Math.Round(
                                    ((scriptData.ElementAt(i).Close ?? 0) * (2 / (decimal)(currentIndicator.EMA2 + 1)) +
                                     EMA2_lastValue * (1 - (2 / (decimal)(currentIndicator.EMA2 + 1)))), 2);
                            EMA2_lastValue = scriptData.ElementAt(i).EMA2;
                        }

                        if (scriptData.ElementAt(i).EMA2 > 0)
                        {
                            // MACD = EMA1 - EMA2
                            scriptData.ElementAt(i).MACD = Math.Round(scriptData.ElementAt(i).EMA1 - scriptData.ElementAt(i).EMA2, 2);
                        }
                        else
                        {
                            scriptData.ElementAt(i).MACD = 0;
                        }
                        // --------- Calculation of EMA2 & MACD


                        if (scriptData.ElementAt(i).MACD != 0)
                        {
                            // Calculation of Signal

                            if (i < (currentIndicator.EMA2 + currentIndicator.Signal - 2))
                            {
                                Signal_Sum += scriptData.ElementAt(i).MACD;
                                scriptData.ElementAt(i).Signal = 0;
                            }
                            else if (i == (currentIndicator.EMA2 + currentIndicator.Signal - 2))
                            {
                                Signal_Sum += scriptData.ElementAt(i).MACD;
                                scriptData.ElementAt(i).Signal = Math.Round(Signal_Sum / (decimal)currentIndicator.Signal, 2);
                                Signal_lastValue = scriptData.ElementAt(i).Signal;
                            }
                            else
                            {
                                scriptData.ElementAt(i).Signal =
                                    Math.Round(
                                        (scriptData.ElementAt(i).MACD * (2 / (decimal)(currentIndicator.Signal + 1)) +
                                         Signal_lastValue * (1 - (2 / (decimal)(currentIndicator.Signal + 1)))), 2);
                                Signal_lastValue = scriptData.ElementAt(i).Signal;
                            }
                            // --------- Calculation of Signal

                            // Calculation of % Percentage
                            scriptData.ElementAt(i).Percentage = Math.Round(100 * (scriptData.ElementAt(i).MACD / (scriptData.ElementAt(i).Close ?? 1)), 2);
                            // --------- Calculation of % Percentage

                            // Calculation of Histogram
                            scriptData.ElementAt(i).Histogram = scriptData.ElementAt(i).MACD - scriptData.ElementAt(i).Signal;
                            // --------- Calculation of Histogram

                            // Calculation of TragetGen [i.e. Call Generation]
                            if (currentIndicator.IsBaseLine)
                            {
                                if (Math.Sign(scriptData.ElementAt(i).Histogram) != Math.Sign(scriptData.ElementAt(i - 1).Histogram) &&
                                    Math.Sign(scriptData.ElementAt(i).Histogram) != Math.Sign(scriptData.ElementAt(i).Signal) &&
                                    Math.Abs(scriptData.ElementAt(i).Percentage) >= Math.Abs((decimal)currentIndicator.Filter))
                                {
                                    scriptData.ElementAt(i).BuySellPrice = null;
                                    if (Math.Sign(scriptData.ElementAt(i).Histogram) > 0)
                                    {
                                        scriptData.ElementAt(i).TragetGen = CallTypes.BuyCall;
                                        scriptData.ElementAt(i).BuySellPrice = scriptData.ElementAt(i).Close;
                                    }
                                    else if (Math.Sign(scriptData.ElementAt(i).Histogram) < 0)
                                    {
                                        scriptData.ElementAt(i).TragetGen = CallTypes.SellCall;
                                        scriptData.ElementAt(i).BuySellPrice = scriptData.ElementAt(i).Close;
                                    }
                                }
                            }
                        }
                    }

                }
            }


        }
    }
}

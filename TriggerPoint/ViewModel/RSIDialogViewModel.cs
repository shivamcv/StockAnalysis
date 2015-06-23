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
   public class RSIDialogViewModel:ViewModelBase
    {
        DateTime startTime, endTime;
        List<int> ScriptIds;
        int TimePeriod;
        string notificationQuery;
        RSIIndicator currentIndicator;

        public ObservableCollection<Model.RSIData> ScriptData { get; set; }

        public RSIDialogViewModel(DateTime startDate, DateTime endDate, int rsiId, List<int> scriptId, int recordMinutes)
        {
            ScriptIds = scriptId;
            startTime = startDate;
            endTime = endDate;
            TimePeriod = recordMinutes;

            ScriptData = new ObservableCollection<RSIData>();

            using (var db = new TriggerPointContext())
            {
                //Initialise
                var para = db.Tbl_RSIParameters.Where(p => p.RSIID == rsiId).AsEnumerable();

                currentIndicator = new RSIIndicator()
                {
                    FastPeriod = (int)(para.ElementAt(0).Value ??0),
                    SlowPeriod = (int)(para.ElementAt(1).Value ??0),
                    LowerLimit = (int)(para.ElementAt(2).Value ??0),
                    UpperLimit = (int)(para.ElementAt(3).Value ??0)
                };

                currentIndicator.Name = db.Tbl_RSI.First(p => p.RSIID == rsiId).RSIName;
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
                List<Model.RSIData> temp = new List<Model.RSIData>();

                progressCtr = 0;
                switch (TimePeriod)
                {
                    //"5","10","15","20","30","45","60","90","120","EOD" 
                    case 5:
                        {
                            var cc = db.Tbl_Script5Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new RSIData()
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
                            temp = cc.Select(p => new RSIData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 15:
                        {
                            var cc = db.Tbl_Script15Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new RSIData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 20:
                        {
                            var cc = db.Tbl_Script20Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new RSIData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 30:
                        {
                            var cc = db.Tbl_Script30Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new RSIData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 45:
                        {
                            var cc = db.Tbl_Script45Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new RSIData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 60:
                        {
                            var cc = db.Tbl_Script60Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new RSIData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 90:
                        {
                            var cc = db.Tbl_Script90Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new RSIData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 120:
                        {
                            var cc = db.Tbl_Script120Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new RSIData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    default:
                        {
                            var cc = db.Tbl_ScriptEOD.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new RSIData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Time = p.Datetime ?? new DateTime(),
                                Date = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                }


                notificationQuery = "SELECT Company FROM dbo.Tbl_Script where Company IN (" + string.Join(",", ScriptIds) + ")";

                if (temp.Any())
                {
                    CalculateRSI(temp);
                }

                DispatcherHelper.UIDispatcher.BeginInvoke((Action)delegate
                {
                    temp.Reverse();
                    foreach (var item in temp)
                    {
                        item.RSIDataId = temp.Count - ScriptData.Count();
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
                                                      .Select(p => new RSIData()
                                                      {
                                                          ScriptId = p.First().Company ?? 0,
                                                          ScriptName = getScriptName(p.First().Company),
                                                          Open = p.Where(q => q.Datetime == p.Min(w => w.Datetime)).First().LowReadings ?? 0,
                                                          Low = p.Min(q => q.LowReadings) ?? 0,
                                                          High = p.Max(q => q.LowReadings) ?? 0,
                                                          Time = (DateTime)p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
                                                          Date = (DateTime)p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
                                                          DateTime = (DateTime)p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
                                                          DateTimeSlot = DateTime.Now.Date + TimeSpan.FromMinutes(p.Key),
                                                          Close = p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().LowReadings ?? 0,
                                                          RecordId = p.First().ID,
                                                      }).OrderBy(p => p.DateTime).ToList();

                        if (temp.Any())
                            DispatcherHelper.UIDispatcher.BeginInvoke((Action)delegate
                            {
                                var grps = ScriptData.GroupBy(p => p.ScriptId).ToList();
                                CallTypes SuspectCall = CallTypes.None;
                                foreach (var item in temp)
                                {
                                    item.RSIDataId = ScriptData.Count() + 1;

                                    var lastValue = ScriptData.First(p => p.ScriptId == item.ScriptId && (p.DateTimeSlot != item.DateTimeSlot || p.DateTimeSlot == null));

                                    var scriptData = ScriptData.Where(p => p.ScriptId == item.ScriptId && (p.DateTimeSlot != item.DateTimeSlot || p.DateTimeSlot == null));
                                  
                                    item.Change = item.Close - lastValue.Close;
                                    // --------- Calculation of Change

                                    // ============= For Slow Strategy ============= 
                                    // Calculation of Avg-Gain & Avg-Loss
                                    
                                        // Calculation of Avg-Gain, For Slow Strategy at (this.SlowStrategy_Days - 1)th row
                                        scriptData.ElementAt(currentIndicator.SlowPeriod - 1).AvgGain_Slow =Math.Round( scriptData.Take(currentIndicator.SlowPeriod).Average(x => x.Advance),2);

                                        // Calculation of Avg-Loss, For Slow Strategy at (this.SlowStrategy_Days - 1)th row
                                        scriptData.ElementAt(currentIndicator.SlowPeriod - 1).AvgLoss_Slow =Math.Round( scriptData.Take(currentIndicator.SlowPeriod).Average(x => x.Decline),2);

                                        // AvgGain = ((Advance_lastvalue * (SlowStrategy_Days-1))+scriptData.ElementAt(i).Advance)/SlowStrategy_Days
                                        item.AvgGain_Slow = Math.Round(((((lastValue).AvgGain_Slow * (currentIndicator.SlowPeriod - 1)) + item.Advance) / currentIndicator.SlowPeriod), 2);

                                        // AvgLoss = ((Decline_lastvalue * (SlowStrategy_Days-1))+scriptData.ElementAt(i).Decline)/SlowStrategy_Days
                                        item.AvgLoss_Slow = Math.Round((((lastValue.AvgLoss_Slow * (currentIndicator.SlowPeriod - 1)) + item.Decline) / currentIndicator.SlowPeriod), 2);
                                    
                                    // --------- Calculation of Avg-Gain & Avg-Loss
                                    // / ============= For Slow Strategy ============= 


                                    //// ============= For Fast Strategy ============= 
                                    // Calculation of Avg-Gain & Avg-Loss
                                   
                                        // Calculation of Avg-Gain, For Fast Strategy at (currentIndicator.FastPeriod - 1)th row
                                        scriptData.ElementAt(currentIndicator.FastPeriod - 1).AvgGain_Fast =
                                          Math.Round(  scriptData.Take(currentIndicator.FastPeriod).Average(x => x.Advance),2);

                                        // Calculation of Avg-Loss, For Fast Strategy at (currentIndicator.FastPeriod - 1)th row
                                        scriptData.ElementAt(currentIndicator.FastPeriod - 1).AvgLoss_Fast =
                                          Math.Round(  scriptData.Take(currentIndicator.FastPeriod).Average(x => x.Decline),2);

                                        // AvgGain = ((Advance_lastvalue * (FastStrategy_Days-1))+scriptData.ElementAt(i).Advance)/FastStrategy_Days
                                        item.AvgGain_Fast =
                                            Math.Round((((lastValue.AvgGain_Fast * (currentIndicator.FastPeriod - 1)) + item.Advance) /
                                                currentIndicator.FastPeriod), 2);

                                        // AvgLoss = ((Decline_lastvalue * (FastStrategy_Days-1))+scriptData.ElementAt(i).Decline)/FastStrategy_Days
                                        item.AvgLoss_Fast =
                                            Math.Round((((lastValue.AvgLoss_Fast * (currentIndicator.FastPeriod - 1)) + item.Decline) /
                                                currentIndicator.FastPeriod), 2);
                                    
                                    // --------- Calculation of Avg-Gain & Avg-Loss

                                    // Calculation of TragetGen [i.e. Call Generation] and Target
                                    if (lastValue.RSI_Fast > 0)
                                    {
                                        if (SuspectCall == CallTypes.None)
                                        {
                                            if (lastValue.RSI_Fast > currentIndicator.UpperLimit)
                                            {
                                                SuspectCall = CallTypes.SellCall;
                                                lastValue.TargetFast = lastValue.Close;
                                            }
                                            else if (lastValue.RSI_Fast < currentIndicator.LowerLimit)
                                            {
                                                SuspectCall = CallTypes.BuyCall;
                                            }
                                        }
                                        else
                                        {
                                            if (SuspectCall == CallTypes.SellCall && lastValue.RSI_Fast < currentIndicator.UpperLimit)
                                            {
                                                lastValue.TargetGenFast = CallTypes.SellCall;
                                                lastValue.BuySellPriceFast = lastValue.Close;
                                                SuspectCall = CallTypes.None;
                                            }
                                            else if (SuspectCall == CallTypes.BuyCall && lastValue.RSI_Fast > currentIndicator.LowerLimit)
                                            {
                                                lastValue.TargetGenFast = CallTypes.BuyCall;
                                                lastValue.BuySellPriceFast = lastValue.Close;
                                                SuspectCall = CallTypes.None;
                                            }
                                        }
                                        // --------- Calculation of TragetGen [i.e. Call Generation] and Target
                                        //// / ============= For Fast Strategy ============= 
                                    }
                                    //
                                    var lastEntry = ScriptData.FirstOrDefault(p => p.DateTimeSlot == timeMark && p.ScriptId == id);

                                    if (lastEntry != null)
                                    {
                                        lastEntry.TargetFast = item.TargetFast;
                                        lastEntry.RSI_Slow = item.RSI_Slow;
                                        lastEntry.RSI_Fast = item.RSI_Fast;
                                        lastEntry.RS_Slow = item.RS_Slow;
                                        lastEntry.RS_Fast = item.RS_Fast;
                                        lastEntry.Advance = item.Advance;
                                        lastEntry.AvgGain_Fast = item.AvgGain_Fast;
                                        lastEntry.BuySellPriceFast = item.BuySellPriceFast;
                                        lastEntry.Change = item.Change;
                                        lastEntry.Decline = item.Decline;
                                        lastEntry.AvgLoss_Slow = item.AvgLoss_Slow;
                                        lastEntry.AvgLoss_Fast = item.AvgLoss_Fast;
                                        lastEntry.AvgGain_Slow = item.AvgGain_Slow;
                                        lastEntry.Open = item.Open;
                                        lastEntry.High = item.High;
                                        lastEntry.Low = item.Low;
                                        lastEntry.Close = item.Close;
                                        lastEntry.DateTime = item.DateTime;
                                        lastEntry.Date = item.Date;
                                        lastEntry.Time = item.Time;
                                        lastEntry.TargetGenFast = item.TargetGenFast;
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

        private void CalculateRSI(List<RSIData> temp)
        {
            using (var db = new TriggerPointContext())
            {
                var grps = temp.GroupBy(p => p.ScriptId);
                foreach (var scriptData in grps)
                {
                    CallTypes SuspectCall= CallTypes.None;
                    for (int i = 0; i < scriptData.Count(); i++)
                    {
                        // Calculation of Change
                        if (i > 0)
                        {
                            scriptData.ElementAt(i).Change = scriptData.ElementAt(i).Close -scriptData.ElementAt(i - 1).Close;
                        }
                        // --------- Calculation of Change

                        // ============= For Slow Strategy ============= 
                        // Calculation of Avg-Gain & Avg-Loss
                        if (i > currentIndicator.SlowPeriod - 1)
                        {
                            // Calculation of Avg-Gain, For Slow Strategy at (this.SlowStrategy_Days - 1)th row
                            scriptData.ElementAt(currentIndicator.SlowPeriod- 1).AvgGain_Slow = Math.Round(scriptData.Take(currentIndicator.SlowPeriod).Average(x => x.Advance),2);

                            // Calculation of Avg-Loss, For Slow Strategy at (this.SlowStrategy_Days - 1)th row
                            scriptData.ElementAt(currentIndicator.SlowPeriod- 1).AvgLoss_Slow = Math.Round( scriptData.Take(currentIndicator.SlowPeriod).Average(x => x.Decline),2);

                            // AvgGain = ((Advance_lastvalue * (SlowStrategy_Days-1))+scriptData.ElementAt(i).Advance)/SlowStrategy_Days
                            scriptData.ElementAt(i).AvgGain_Slow = Math.Round((((scriptData.ElementAt(i - 1).AvgGain_Slow * (currentIndicator.SlowPeriod - 1)) + scriptData.ElementAt(i).Advance) /currentIndicator.SlowPeriod), 2);

                            // AvgLoss = ((Decline_lastvalue * (SlowStrategy_Days-1))+scriptData.ElementAt(i).Decline)/SlowStrategy_Days
                            scriptData.ElementAt(i).AvgLoss_Slow = Math.Round((((scriptData.ElementAt(i - 1).AvgLoss_Slow * (currentIndicator.SlowPeriod - 1)) + scriptData.ElementAt(i).Decline) /currentIndicator.SlowPeriod), 2);
                        }
                        // --------- Calculation of Avg-Gain & Avg-Loss
                        // / ============= For Slow Strategy ============= 


                        //// ============= For Fast Strategy ============= 
                        // Calculation of Avg-Gain & Avg-Loss
                        if (i > currentIndicator.FastPeriod - 1)
                        {
                            // Calculation of Avg-Gain, For Fast Strategy at (currentIndicator.FastPeriod - 1)th row
                            scriptData.ElementAt(currentIndicator.FastPeriod - 1).AvgGain_Fast =
                               Math.Round( scriptData.Take(currentIndicator.FastPeriod).Average(x => x.Advance),2);

                            // Calculation of Avg-Loss, For Fast Strategy at (currentIndicator.FastPeriod - 1)th row
                            scriptData.ElementAt(currentIndicator.FastPeriod - 1).AvgLoss_Fast =
                               Math.Round( scriptData.Take(currentIndicator.FastPeriod).Average(x => x.Decline),2);

                            // AvgGain = ((Advance_lastvalue * (FastStrategy_Days-1))+scriptData.ElementAt(i).Advance)/FastStrategy_Days
                            scriptData.ElementAt(i).AvgGain_Fast =
                                Math.Round((((scriptData.ElementAt( i - 1).AvgGain_Fast * (currentIndicator.FastPeriod - 1)) + scriptData.ElementAt(i).Advance) /
                                    currentIndicator.FastPeriod), 2);

                            // AvgLoss = ((Decline_lastvalue * (FastStrategy_Days-1))+scriptData.ElementAt(i).Decline)/FastStrategy_Days
                            scriptData.ElementAt(i).AvgLoss_Fast =
                                Math.Round((((scriptData.ElementAt( i - 1).AvgLoss_Fast * (currentIndicator.FastPeriod - 1)) + scriptData.ElementAt(i).Decline) /
                                    currentIndicator.FastPeriod), 2);
                        }
                        // --------- Calculation of Avg-Gain & Avg-Loss

                        // Calculation of TragetGen [i.e. Call Generation] and Target
                        if (i > 0 && scriptData.ElementAt(i - 1).RSI_Fast > 0)
                        {
                            if (SuspectCall == CallTypes.None)
                            {
                                if (scriptData.ElementAt(i - 1).RSI_Fast > currentIndicator.UpperLimit)
                                {
                                    SuspectCall = CallTypes.SellCall;
                                    scriptData.ElementAt( i - 1).TargetFast = scriptData.ElementAt( i - 1).Close;
                                }
                                else if (scriptData.ElementAt(i - 1).RSI_Fast < currentIndicator.LowerLimit)
                                {
                                    SuspectCall = CallTypes.BuyCall;
                                }
                            }
                            else
                            {
                                if (SuspectCall == CallTypes.SellCall && scriptData.ElementAt( i - 1).RSI_Fast < currentIndicator.UpperLimit)
                                {
                                    scriptData.ElementAt( i - 1).TargetGenFast = CallTypes.SellCall;
                                    scriptData.ElementAt( i - 1).BuySellPriceFast = scriptData.ElementAt( i - 1).Close;
                                    SuspectCall = CallTypes.None;
                                }
                                else if (SuspectCall == CallTypes.BuyCall && scriptData.ElementAt( i - 1).RSI_Fast > currentIndicator.LowerLimit)
                                {
                                    scriptData.ElementAt( i - 1).TargetGenFast = CallTypes.BuyCall;
                                    scriptData.ElementAt( i - 1).BuySellPriceFast = scriptData.ElementAt( i - 1).Close;
                                    SuspectCall = CallTypes.None;
                                }
                            }
                            // --------- Calculation of TragetGen [i.e. Call Generation] and Target
                            //// / ============= For Fast Strategy ============= 
                        }
                    }


                }
            }


        }
    }
}

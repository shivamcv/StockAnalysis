using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TriggerPoint.Data;
using TriggerPoint.HelperClasses;
using TriggerPoint.Model;

namespace TriggerPoint.ViewModel
{
    public class SwingDialogViewModel : ViewModelBase
    {

        DateTime startTime, endTime;
        int  TimePeriod,swingPeriod,BandPeriod;
        Decimal LimitMove;
        List<int> ScriptIds;

        string notificationQuery;


        public ObservableCollection<Model.SwingData> ScriptData { get; set; }

        public SwingDialogViewModel(DateTime startDate, DateTime endDate, int swingId, List<int> scriptId, int recordMinutes)
        {
            startTime = startDate;
            endTime = endDate;

            ScriptIds = scriptId;
            TimePeriod = recordMinutes;

            ScriptData = new ObservableCollection<Model.SwingData>();

            using (var db = new Data.TriggerPointContext())
            {
                var swingParameter = db.Tbl_SwingParameters.FirstOrDefault(p => p.SwingID == swingId);

                if (swingParameter == null)
                {
                    ErrorReporting.Report(new InvalidOperationException(), "Swingid not found");
                    return;
                }
                else
                {
                    LimitMove = swingParameter.LimitMove == null ? 100000 : (decimal)swingParameter.LimitMove;
                    swingPeriod = swingParameter.TimePeriod??10;
                    BandPeriod = swingParameter.SwingBandTimePeriod ?? 10;
                }
            }


            Task.Factory.StartNew(() =>
            {
                LoadInitialData();
            });

        }

        private string getScriptName(int? scriptid)
        {
            using (var db = new Data.TriggerPointContext())
            {
                return db.Tbl_ScriptMaster.FirstOrDefault(p => p.ID == scriptid).ScriptName;
            }
        }

        private void LoadInitialData()
        {
            IsLoading = true;
            using (var db = new Data.TriggerPointContext())
            {
                List<Model.SwingData> temp = new List<Model.SwingData>();
                Console.WriteLine(DateTime.Now);

                progressCtr = 0;
                switch (TimePeriod)
                {
                    //"5","10","15","20","30","45","60","90","120","EOD" 
                    case 5:
                        {
                            var cc = db.Tbl_Script5Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new SwingData()
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
                            temp = cc.Select(p => new SwingData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
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
                            temp = cc.Select(p => new SwingData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 20:
                        {
                            var cc = db.Tbl_Script20Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new SwingData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 30:
                        {
                            var cc = db.Tbl_Script30Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new SwingData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 45:
                        {
                            var cc = db.Tbl_Script45Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new SwingData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 60:
                        {
                            var cc = db.Tbl_Script60Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new SwingData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 90:
                        {
                            var cc = db.Tbl_Script90Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new SwingData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    case 120:
                        {
                            var cc = db.Tbl_Script120Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new SwingData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                    default:
                        {
                            var cc = db.Tbl_ScriptEOD.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                            int length = cc.Count();
                            temp = cc.Select(p => new SwingData()
                            {
                                ScriptId = p.Company ?? 0,
                                ScriptName = getScriptName(p.Company),
                                Open = p.OpenReadings ?? 0,
                                Low = p.LowReadings ?? 0,
                                High = p.HighReadings ?? 0,
                                DateTime = p.Datetime ?? new DateTime(),
                                Close = p.CloseReadings ?? 0,
                                Date = p.Datetime ?? new DateTime(),
                                Time = p.Datetime ?? new DateTime(),
                                RecordId = getRecordId(p.ID, length),
                            }).OrderBy(p => p.DateTime).ToList();
                        }
                        break;
                }

                notificationQuery = "SELECT Company FROM dbo.Tbl_Script where Company IN (" + string.Join(",", ScriptIds) + ")";
                Console.WriteLine(DateTime.Now);
                if (temp.Any())
                        CalculateSwingIndex(temp);

                DispatcherHelper.UIDispatcher.BeginInvoke((Action)delegate
                {
                    temp.Reverse();
                    foreach (var item in temp)
                    {
                        item.SwingDataId = temp.Count - ScriptData.Count();
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

        private void CalculateSwingIndex(List<SwingData> temp)
        {
            var grps = temp.GroupBy(p => p.ScriptId);
            foreach (var grp in grps)
            {
                for (int i = 1; i < grp.Count(); i++)
                {
                    var ctr = Math.Max(swingPeriod, BandPeriod);

                    grp.ElementAt(i).SwingDataId = i;
                    var t = getSwingIndex(grp.ElementAt(i), grp.ElementAt(i - 1), grp.Skip(i-ctr + 1).Take(ctr).ToList());
                    grp.ElementAt(i).SwingIndex = t[1];
                    grp.ElementAt(i).ATR = t[0];
                    grp.ElementAt(i).LowerBand = t[2];
                    grp.ElementAt(i).UpperBand = t[3];
                    grp.ElementAt(i).ATRAvg = t[4];
                    grp.ElementAt(i).AvgLowerBand = t[5];
                    grp.ElementAt(i).AvgUpperBand = t[6];

                    if(i>1)
                    GenerateCall( grp.ElementAt(i - 2),  grp.ElementAt(i - 1),  grp.ElementAt(i));
                }
            }
        }

        Dictionary<int, CallTypes> lastCalls = new Dictionary<int, CallTypes>();
        private void GenerateCall(SwingData previous, SwingData current, SwingData next)
        {
             var diffUp = current.AvgUpperBand - next.Close;
             var diffLow = previous.AvgLowerBand - current.Close;

             current.DiffUp = diffUp;
             current.DiffLow = diffLow;

             Debug.WriteLine(string.Format("[{2}] DiffUP from {0} to {1}", current.AvgUpperBand, next.Close, current.DateTime));
             Debug.WriteLine(string.Format("[{2}] Difflow from {0} to {1}", previous.AvgLowerBand, current.Close, current.DateTime));

             if (!lastCalls.ContainsKey(current.ScriptId))
             {
                 if (previous.DiffLow < 0 && current.DiffLow > 0)
                 {
                     current.Call = CallTypes.SellCall;
                     current.SwingIndex = current.AvgLowerBand;
                     lastCalls.Add(current.ScriptId, CallTypes.SellCall);
                 }
                 else if (previous.DiffUp > 0 && current.DiffUp < 0)
                 {
                     current.Call = CallTypes.BuyCall;
                     current.SwingIndex = current.AvgUpperBand;
                     lastCalls.Add(current.ScriptId, CallTypes.BuyCall);
                 }
             }
             else
             {
                 current.DiffUp = current.Close - previous.SwingIndex;
                 if (lastCalls[current.ScriptId] == CallTypes.BuyCall)
                 {
                     if (current.Close - previous.SwingIndex < 0)
                     {
                         current.Call = CallTypes.SellCall;
                         current.SwingIndex = current.AvgUpperBand;
                         lastCalls[current.ScriptId] = CallTypes.SellCall;
                     }
                     else
                         current.SwingIndex = current.AvgLowerBand;
                 }
                 else
                 {
                     if (current.Close - previous.SwingIndex > 0)
                     {
                         current.Call = CallTypes.BuyCall;
                         current.SwingIndex = current.AvgLowerBand;
                         lastCalls[current.ScriptId] = CallTypes.BuyCall;
                     }
                     else 
                     current.SwingIndex = current.AvgUpperBand;
                 }

                 //current close - last swing index
             }

        }

        private decimal[] getSwingIndex(SwingData current, SwingData previous,List<SwingData> previousIndexes, bool isLive=false)
        {
            var CY = previous.Close;
            var C = current.Close;
            var OY = previous.Open;
            var O = current.Open;
            var T = LimitMove == 0 ? 100000 : LimitMove;
            var H = current.High;
            var L = current.Low;
            var K = Math.Max(H - CY, L - CY);
            decimal swingIndex = 0;

            var O1 = L-CY;
            var O2 = H-CY;
            var O3 = H - L;

            var atr = Math.Max(O1, Math.Max(O2, O3));
            var temp = previousIndexes.Where(p=>p.ATR >0).Select(p => p.ATR).Take(swingPeriod).ToList();
            temp.Add(atr);
            var atrAvg = temp.Average();
            
          //  Debug.WriteLine(string.Format("{0} : Avg From {1} to {2}", current.SwingDataId, previousIndexes.First().SwingDataId, previousIndexes.Last().SwingDataId));
           // Debug.WriteLine(string.Format("start: {0} End: {1}", temp.First(), temp.Last()));
           
            var UpperBand = (H + L) / 2 + (atrAvg * LimitMove);
            var LowerBand = (H + L) / 2 - (atrAvg * LimitMove);

            var result = new decimal[7];

            if (previous.SwingIndex == 0)
                swingIndex = UpperBand;
            else
            {
                if (C > previous.SwingIndex)
                    swingIndex = LowerBand;
                else 
                    swingIndex = previous.SwingIndex;
            }

            decimal avgUpperBand=0, avgLowerBand=0;
            if(isLive)
                temp = previousIndexes.Where(p => p.UpperBand > 0).Select(p => p.UpperBand).Take(BandPeriod - 1).ToList();
            else
                 temp = previousIndexes.Where(p => p.UpperBand > 0).Select(p => p.UpperBand).Reverse().Take(BandPeriod-1).ToList();

             temp.Add(UpperBand);
             avgUpperBand = temp.Min();

            if(isLive)
                 temp = previousIndexes.Where(p => p.LowerBand > 0).Select(p => p.LowerBand).Take(BandPeriod-1).ToList();
            else
                temp = previousIndexes.Where(p => p.LowerBand > 0).Select(p => p.LowerBand).Reverse().Take(BandPeriod - 1).ToList();

             temp.Add(LowerBand);
             avgLowerBand = temp.Max();

           

            result[0] = atr;
            result[1] = swingIndex;
            result[2] = LowerBand;
            result[3] = UpperBand;
            result[4] = atrAvg;
            result[5] = avgLowerBand;
            result[6] = avgUpperBand;

            return result;
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
                                                      .Select(p => new SwingData()
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
                                for (int i = 0; i < temp.Count; i++)
                                {
                                    var grps = ScriptData.GroupBy(p => p.ScriptId).ToList();
                                    var item = temp[i];

                                    var oldData = grps.First(p => p.Key == item.ScriptId);
                                    item.SwingDataId = ScriptData.Count() + 1;

                                    var ctr = Math.Max(swingPeriod, BandPeriod);

                                    var t = getSwingIndex(item, oldData.Where(p=>p.RecordId!=item.RecordId).First(), oldData.Skip(i - ctr + 1).Take(swingPeriod).ToList(),true);
                                    
                                    item.SwingIndex = t[1];
                                    item.ATR = t[0];
                                    item.LowerBand = t[2];
                                    item.UpperBand = t[3];
                                    item.ATRAvg = t[4];
                                    item.AvgLowerBand = t[5];
                                    item.AvgUpperBand = t[6];

                                    GenerateCall(oldData.ElementAt(2), oldData.First(), item);

                                    var lastEntry = ScriptData.FirstOrDefault(p => p.DateTimeSlot == timeMark && p.ScriptId == id);

                                    if (lastEntry != null)
                                    {
                                        lastEntry.SwingIndex = item.SwingIndex;
                                        lastEntry.Open = item.Open;
                                        lastEntry.High = item.High;
                                        lastEntry.Low = item.Low;
                                        lastEntry.Close = item.Close;
                                        lastEntry.DateTime = item.DateTime;
                                        lastEntry.Date = item.Date;
                                        lastEntry.Time = item.Time;
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


        public static decimal getValue(AverageData item, CalculateTypes ctype)
        {
            switch (ctype)
            {
                case CalculateTypes.Open: return item.Open;
                case CalculateTypes.Low: return item.Low;
                case CalculateTypes.High: return item.High;
                default: return item.Close;
            }
        }
    }

}

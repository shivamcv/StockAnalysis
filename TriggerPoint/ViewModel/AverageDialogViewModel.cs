using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TriggerPoint.Model;
using TriggerPoint.HelperClasses;
using System.Data.SqlClient;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using TriggerPoint.Data;
namespace TriggerPoint.ViewModel
{
  public  class AverageDialogViewModel:ViewModelBase
    {

      DateTime startTime, endTime;
      CalculateTypes CalType;
      int AvgPeriod,TimePeriod;
      List<int> ScriptIds;
      bool IsExponential;

      string notificationQuery;
      

      public ObservableCollection<Model.AverageData> ScriptData { get; set; }

      public AverageDialogViewModel(DateTime startDate, DateTime endDate, int averageId, List<int> scriptId, int recordMinutes)
          {
              startTime = startDate;
              endTime = endDate;

              ScriptIds = scriptId;
              TimePeriod = recordMinutes;

              ScriptData = new ObservableCollection<Model.AverageData>();

              using (var db = new Data.TriggerPointContext())
              {
                  var avgParameter = db.Tbl_AverageParameters.FirstOrDefault(p => p.AverageID == averageId);

                  if (avgParameter == null)
                  {
                      ErrorReporting.Report(new InvalidOperationException(), "avgid not found");
                      return;
                  }
                  else
                  {
                      IsExponential = avgParameter.IsExposional ?? false;
                      AvgPeriod = avgParameter.Period == null ? 0 : (int)avgParameter.Period;
                      CalType = (CalculateTypes)avgParameter.Type;
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
                      List<Model.AverageData> temp = new List<Model.AverageData>();
                      Console.WriteLine(DateTime.Now);

                      progressCtr = 0;
                      switch(TimePeriod)
                      {
                              //"5","10","15","20","30","45","60","90","120","EOD" 
                          case 5:
                              {
                                  var cc = db.Tbl_Script5Min.Where(p => ScriptIds.Contains(p.Company??0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                                  int length = cc.Count();
                                    temp=cc.Select(p => new AverageData()
                                        {
                                            ScriptId = p.Company??0,
                                            ScriptName = getScriptName(p.Company),
                                            Open = p.OpenReadings ?? 0,
                                            Low = p.LowReadings ?? 0,
                                            High = p.HighReadings ?? 0,
                                            Date = p.Datetime ?? new DateTime(),
                                            Time = p.Datetime ?? new DateTime(),
                                            DateTime = p.Datetime ?? new DateTime(),
                                            Close = p.CloseReadings ?? 0,
                                            RecordId = getRecordId( p.ID,length),
                                        }).OrderByDescending(p=>p.Date).ToList();
                              }
                              break;
                          case 10:
                              {
                                  var cc = db.Tbl_Script10Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                                  int length = cc.Count();
                                  temp=     cc.Select(p => new AverageData()
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
                                        }).OrderByDescending(p=>p.Date).ToList();
                              }
                              break;
                          case 15:
                              {
                                  var cc = db.Tbl_Script15Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                                  int length = cc.Count();
                                      temp=    cc.Select(p => new AverageData()
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
                                          }).OrderByDescending(p => p.Date).ToList();
                              }
                              break;
                          case 20:
                              {
                                  var cc = db.Tbl_Script20Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                                  int length = cc.Count();
                                        temp=   cc.Select(p => new AverageData()
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
                                           }).OrderByDescending(p => p.Date).ToList();
                              }
                              break;
                          case 30:
                              {
                                  var cc = db.Tbl_Script30Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                                  int length = cc.Count();
                                        temp=cc.Select(p => new AverageData()
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
                                          }).OrderByDescending(p => p.Date).ToList();
                              }
                              break;
                          case 45:
                              {
                                  var cc = db.Tbl_Script45Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                                  int length = cc.Count();
                                          temp= cc.Select(p => new AverageData()
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
                                           }).OrderByDescending(p => p.Date).ToList();
                              }
                              break;
                          case 60:
                              {
                                  var cc = db.Tbl_Script60Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                                  int length = cc.Count();
                                          temp=cc.Select(p => new AverageData()
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
                                           }).OrderByDescending(p => p.Date).ToList();
                              }
                              break;
                          case 90:
                              {
                                  var cc = db.Tbl_Script90Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                                  int length = cc.Count();
                                         temp= cc.Select(p => new AverageData()
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
                                          }).OrderByDescending(p => p.Date).ToList();
                              }
                              break;
                          case 120:
                              {
                                  var cc = db.Tbl_Script120Min.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                                  int length = cc.Count();
                                         temp= cc.Select(p => new AverageData()
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
                                          }).OrderByDescending(p => p.Date).ToList();
                              }
                              break;
                          default:
                              {
                                  var cc = db.Tbl_ScriptEOD.Where(p => ScriptIds.Contains(p.Company ?? 0) && p.Datetime >= startTime && p.Datetime <= endTime).AsEnumerable();
                                  int length = cc.Count();
                                          temp=cc.Select(p => new AverageData()
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
                                          }).OrderByDescending(p => p.Date).ToList();
                              }
                              break;
                      }

                      notificationQuery = "SELECT Company FROM dbo.Tbl_Script where Company IN (" + string.Join(",", ScriptIds) + ")";
                      Console.WriteLine(DateTime.Now);
                      if(temp.Any())
                      if (IsExponential)
                          CalculateExponentialAverage(temp);
                      else
                          CalculateSimpleAverage(temp);

                      DispatcherHelper.UIDispatcher.BeginInvoke((Action)delegate
                      {
                          foreach (var item in temp)
                          {
                              item.AverageDataId = temp.Count - ScriptData.Count();
                              ScriptData.Add(item);
                          }
                      });
                  }

                  try
                  {
                      SqlDependency.Start(ViewModel.Connection.getProviderConnectionstring());
                      startNotifier();
                  }catch(Exception ex)
                  {
                      MessageBox.Show("Service Broker for database is not enabled, so changes will not be sync");
                      ErrorReporting.Report(ex,"Service broker");
                  }
                  IsLoading = false;
      }

    

      private void CalculateExponentialAverage(List<AverageData> temp)
      {
          temp.Reverse();

          var grps = temp.GroupBy(p => p.ScriptId);
          foreach (var grp in grps)
          {
              decimal k = 2 / (decimal)(AvgPeriod + 1);
              grp.ElementAt(0).Average = grp.ElementAt(0).Close;
              for (int i = 1; i < grp.Count(); i++)
              {
                  grp.ElementAt(i).Average = Math.Round(getValue(grp.ElementAt(i), CalType) * k + grp.ElementAt(i - 1).Average * (1 - k), 2);
              }
          }
         temp.Reverse();
         Console.WriteLine(DateTime.Now);

      }

      private void CalculateSimpleAverage(List<AverageData> temp)
      {
          var grps = temp.GroupBy(p => p.ScriptId);
          foreach (var grp in grps)
          {
              for (int i = 0; i < grp.Count(); i++)
              {
                  grp.ElementAt(i).Average = Math.Round(grp.Skip(i).Take(AvgPeriod).Average(p => getValue(p, CalType)), 2);
              }
             
          }

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
          set { progress = value;
          RaisePropertyChanged("Progress");
          }
      }

      private bool isLoading;
      public bool IsLoading
      {
          get { return isLoading; }
          set { isLoading = value;
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
         
          if(e.Info == SqlNotificationInfo.Insert)
              using (var db = new Data.TriggerPointContext())
              {
                
                  foreach (var id in ScriptIds)
                  {
                      var temp = db.Tbl_Script.Where(p => p.Company == id && p.Datetime > timeMark).AsEnumerable()
                                         .GroupBy(p=> groupScript(p,TimeSpan.FromMinutes(TimePeriod)))
                                                    .Select(p => new AverageData()
                                                    {
                                                        ScriptId = p.First().Company ?? 0,
                                                        ScriptName = getScriptName(p.First().Company),
                                                        Open = p.Where(q=>q.Datetime == p.Min(w=>w.Datetime)).First().LowReadings??0,
                                                        Low = p.Min(q=>q.LowReadings) ?? 0,
                                                        High = p.Max(q => q.LowReadings) ?? 0,

                                                        Date = (DateTime)p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
                                                        Time = (DateTime)p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
                                                        DateTime = (DateTime)p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().Datetime,
                                                        DateTimeSlot = DateTime.Now.Date + TimeSpan.FromMinutes(p.Key),
                                                        Close = p.Where(q => q.Datetime == p.Max(w => w.Datetime)).First().LowReadings ?? 0,
                                                        RecordId = p.First().ID,
                                                    }).OrderBy(p => p.Date).ToList();

                      if (temp.Any())
                          DispatcherHelper.UIDispatcher.BeginInvoke((Action)delegate
                                  {
                                      var grps = ScriptData.GroupBy(p => p.ScriptId).ToList();
                                      foreach (var item in temp)
                                      {
                                          var oldData = grps.First(p => p.Key == item.ScriptId);
                                          item.AverageDataId = ScriptData.Count() + 1;

                                          if (IsExponential)
                                          {
                                              decimal k = 2 / (decimal)(AvgPeriod + 1);
                                              item.Average = Math.Round(getValue(item, CalType) * k + oldData.First().Average * (1 - k), 2);
                                          }
                                          else
                                          {
                                              var tempVal = oldData.Take(AvgPeriod - 1).ToList();
                                              tempVal.Add(item);
                                              item.Average = Math.Round(tempVal.Average(p => getValue(p,CalType)),2);
                                          }

                                          var lastEntry = ScriptData.FirstOrDefault(p => p.DateTimeSlot == timeMark && p.ScriptId == id);

                                          if (lastEntry != null)
                                          {
                                              lastEntry.Average = item.Average;
                                              lastEntry.Open = item.Open;
                                              lastEntry.High = item.High;
                                              lastEntry.Low = item.Low;
                                              lastEntry.Close = item.Close;
                                              lastEntry.Date = item.Date;
                                              lastEntry.DateTime = item.DateTime;
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
          switch(ctype)
          {
              case CalculateTypes.Open: return item.Open;
              case CalculateTypes.Low: return item.Low;
              case CalculateTypes.High: return item.High;
             default: return item.Close;
          }
      }
    }
}

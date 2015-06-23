using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
   public class AverageData:INotifyPropertyChanged
   {
       public int AverageDataId { get; set; }
       public int ScriptId { get; set; }
       public String ScriptName { get; set; }

       public DateTime? DateTimeSlot { get; set; }

       private DateTime dateTime;

       public DateTime DateTime
       {
           get { return dateTime; }
           set { dateTime = value;
           RaisePropertyChanged("DateTime");
           }
       }
       

       private DateTime date;
       public DateTime Date
       {
           get { return date; }
           set
           {
               date = value;
               RaisePropertyChanged("Date");
           }
       }

       private DateTime time;

       public DateTime Time
       {
           get { return time; }
           set { time = value;
           RaisePropertyChanged("Time");
           }
       }
       
       private decimal open;

       public decimal Open
       {
           get { return open; }
           set { open = value;
           RaisePropertyChanged("Open");
           }
       }
       

       private decimal high;

       public decimal High
       {
           get { return high; }
           set { high = value;
           RaisePropertyChanged("High");
           }
       }
       

       private decimal low;

       public decimal Low
       {
           get { return low; }
           set { low = value;
           RaisePropertyChanged("Low");
           }
       }
       

       private decimal average;

       public decimal Average
       {
           get { return average; }
           set 
           { 
               average = value;
            RaisePropertyChanged("Average");
           }
       }

       private decimal close;

       public decimal Close
       {
           get { return close; }
           set
           {
               close = value;
               RaisePropertyChanged("Close");
           }
       }
       private void RaisePropertyChanged(string p)
       {
           if (PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs(p));
       }
       

       public int RecordId { get; set; }

       public event PropertyChangedEventHandler PropertyChanged;
   }


}

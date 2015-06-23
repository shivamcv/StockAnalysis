using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
  public class RSIData:INotifyPropertyChanged
   {
       public int RSIDataId { get; set; }
       public int ScriptId { get; set; }
       public String ScriptName { get; set; }

       public DateTime? DateTimeSlot { get; set; }
      
       private DateTime dateTime;

       public DateTime DateTime
       {
           get { return dateTime; }
           set
           {
               dateTime = value;
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
           set
           {
               time = value;
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


       private decimal _change;
       public decimal Change
       {
           get
           {
               return _change;
           }
           set
           {
               this._change = value;
               this.Advance = (value > 0 ? value : 0);
               this.Decline = (value < 0 ? value : 0);
               RaisePropertyChanged("Change");
           }
       }

       private decimal advance;

       public decimal Advance
       {
           get { return advance; }
           set { advance = value;
           RaisePropertyChanged("Advance");
           }
       }

       private decimal decline;

       public decimal Decline
       {
           get { return decline; }
           set { decline = value;
           RaisePropertyChanged("Decline");
           }
       }

       private decimal avgGain_Slow;

       public decimal AvgGain_Slow
       {
           get { return avgGain_Slow; }
           set { avgGain_Slow = value;
           RaisePropertyChanged("AvgGain_Slow");
           }
       }

       private decimal _avgLoss_Slow;
       public decimal AvgLoss_Slow
       {
           get
           {
               return _avgLoss_Slow;
           }
           set
           {
               this._avgLoss_Slow = value;
               this.RS_Slow =Math.Round((value == 0 ? 0 : Math.Abs(this.AvgGain_Slow / value)),2);
               RaisePropertyChanged("AvgLoss_Slow");
           }
       }

       private decimal _rs_Slow;
       public decimal RS_Slow
       {
           get
           {
               return _rs_Slow;
           }
           set
           {
               this._rs_Slow = value;
               this.RSI_Slow =Math.Round( 100 - (100 / (1 + value)),2);

               RaisePropertyChanged("RS_Slow");
           }
       }
       private decimal rSI_Slow;

       public decimal RSI_Slow
       {
           get { return rSI_Slow; }
           set { rSI_Slow = value;
           RaisePropertyChanged("RSI_Slow");
           }
       }


       private decimal avgGain_Fast;

       public decimal AvgGain_Fast
       {
           get { return avgGain_Fast; }
           set { avgGain_Fast = value;
           RaisePropertyChanged("AvgGain_Fast");
           }
       }
       

       private decimal _avgLoss_Fast;
       public decimal AvgLoss_Fast
       {
           get
           {
               return _avgLoss_Fast;
           }
           set
           {
               this._avgLoss_Fast = value;
               this.RS_Fast = Math.Round((value == 0 ? 0 : Math.Abs(this.AvgGain_Fast / value)),2);
               RaisePropertyChanged("AvgLoss_Fast");

           }
       }

       private decimal _rs_Fast;
       public decimal RS_Fast
       {
           get
           {
               return _rs_Fast;
           }
           set
           {
               this._rs_Fast = value;
               this.RSI_Fast =Math.Round(100 - (100 / (1 + value)),2);
               RaisePropertyChanged("RS_Fast");
           }
       }

       private decimal rSI_Fast;

       public decimal RSI_Fast
       {
           get { return rSI_Fast; }
           set { rSI_Fast = value;
           RaisePropertyChanged("RSI_Fast");
           }
       }

       private CallTypes targetGenFast;

       public CallTypes TargetGenFast
       {
           get { return targetGenFast; }
           set { targetGenFast = value;
           RaisePropertyChanged("TargetGenFast");
           }
       }

       private decimal? buySellPriceFast;

       public decimal? BuySellPriceFast
       {
           get { return buySellPriceFast; }
           set { buySellPriceFast = value;
           RaisePropertyChanged("BuySellPriceFast");
           }
       }

       private decimal? targetFast;

       public decimal? TargetFast
       {
           get { return targetFast; }
           set { targetFast = value;
           RaisePropertyChanged("TargetFast");
           }
       }
       
       
       

       public event PropertyChangedEventHandler PropertyChanged;
   }

}

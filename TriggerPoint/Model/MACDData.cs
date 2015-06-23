using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
    public class MACDData : INotifyPropertyChanged
    {
        public int MACDDataId { get; set; }

        public int ScriptId { get; set; }
        public int RecordId { get; set; }
        public string ScriptName { get; set; }
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
            set
            {
                open = value;
                RaisePropertyChanged("Open");
            }
        }


        private decimal high;
        public decimal High
        {
            get { return high; }
            set
            {
                high = value;
                RaisePropertyChanged("High");
            }
        }


        private decimal low;
        public decimal Low
        {
            get { return low; }
            set
            {
                low = value;
                RaisePropertyChanged("Low");
            }
        }


        private decimal? close;
        public decimal? Close
        {
            get { return close; }
            set
            {
                close = value;
                RaisePropertyChanged("Close");
            }
        }

        private decimal ema1;
        public decimal EMA1
        {
            get { return ema1; }
            set { ema1 = value;
            RaisePropertyChanged("EMA1");
            }
        }

        private decimal ema2;
        public decimal EMA2
        {
            get { return ema2; }
            set
            {
                ema2 = value;
                RaisePropertyChanged("EMA2");
            }
        }
        
        private decimal macd;
        public decimal MACD
        {
            get { return macd; }
            set
            {
                macd = value;
                RaisePropertyChanged("MACD");
            }
        }

        private decimal signal;
        public decimal Signal
        {
            get { return signal; }
            set { signal = value;
            RaisePropertyChanged("Signal");
            }
        }

        private decimal percentage;
        public decimal Percentage
        {
            get { return percentage; }
            set { percentage = value;
            RaisePropertyChanged("Percentage");
            }
        }

        private decimal hist;
        public decimal Histogram
        {
            get { return hist; }
            set { hist = value;
            RaisePropertyChanged("Histogram");
            }
        }

        private CallTypes trgt;
        public CallTypes TragetGen
        {
            get { return trgt; }
            set { trgt = value;
            RaisePropertyChanged("TragetGen");
            }
        }

        private decimal? bsPrice;
        public decimal? BuySellPrice
        {
            get { return bsPrice; }
            set { bsPrice = value;
            RaisePropertyChanged("BuySellPrice");
            }
        }
        

       
        
        private void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

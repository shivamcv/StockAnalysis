using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
    public class SwingData : INotifyPropertyChanged
    {
        public int SwingDataId { get; set; }
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

        private decimal swingIndex;

        public decimal SwingIndex
        {
            get { return swingIndex; }
            set
            {
                swingIndex = Math.Round(value,2);
                RaisePropertyChanged("SwingIndex");
            }
        }

        private decimal atr;
        public decimal ATR
        {
            get { return atr; }
            set
            {
                atr = Math.Round(value, 2);
            RaisePropertyChanged("ATR");
            }
        }

        private decimal atrAvg;
        public decimal ATRAvg
        {
            get { return atrAvg; }
            set
            {
                atrAvg = Math.Round(value, 2);
                RaisePropertyChanged("ATRAvg");
            }
        }

        private decimal upperBand;
        public decimal UpperBand
        {
            get { return upperBand; }
            set
            {
                upperBand = Math.Round(value, 2);
            RaisePropertyChanged("UpperBand");
            }
        }

        private decimal lowerBand;
        public decimal LowerBand
        {
            get { return lowerBand; }
            set
            {
                lowerBand = Math.Round(value, 2);
            RaisePropertyChanged("LowerBand");

            }
        }

        private decimal avgLowerBand;

        public decimal AvgLowerBand
        {
            get { return avgLowerBand; }
            set
            {
                avgLowerBand = Math.Round(value, 2);
            RaisePropertyChanged("AvgLowerBand");
            }
        }

        private decimal avgUpperBand;
        public decimal AvgUpperBand
        {
            get { return avgUpperBand; }
            set { avgUpperBand = Math.Round(value, 2);
            RaisePropertyChanged("AvgUpperBand");
            }
        }

        private decimal diffUP ;
        public decimal DiffUp
        {
            get { return diffUP; }
            set
            {
                diffUP = value;
                RaisePropertyChanged("DiffUp");
            }
        }

        private decimal diffLow;
        public decimal DiffLow
        {
            get { return diffLow; }
            set
            {
                diffLow = value;
                RaisePropertyChanged("DiffLow");
            }
        }

        private void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        private CallTypes call;

        public CallTypes Call
        {
            get { return call; }
            set { call = value;
            RaisePropertyChanged("Call");
            }
        }
        

        public int RecordId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}

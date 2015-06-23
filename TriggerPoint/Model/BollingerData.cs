using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
   
        public class BollingerData:INotifyPropertyChanged
        {
            public int id { get; set; }
            public int RecordId { get; set; }
            public int ScriptId { get; set; }
            
            
            public DateTime? DateTimeSlot { get; set; }

            private DateTime? datetime;

            public DateTime? DateTime
            {
                get { return datetime; }
                set { datetime = value;
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
            private void RaisePropertyChanged(string p)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(p));
            }


            private decimal sma;

            public decimal SMA
            {
                get { return sma; }
                set { sma = value;
                RaisePropertyChanged("SMA");
                }
            }


            private decimal standardDeviation;

            public decimal StandardDeviation
            {
                get { return standardDeviation; }
                set { standardDeviation = value;
                RaisePropertyChanged("StandardDeviation");
                }
            }


            private decimal deviations;

            public decimal Deviations
            {
                get { return deviations; }
                set { deviations = value;
                RaisePropertyChanged("Deviations");
                }
            }

            private decimal lowerBand;

            public decimal LowerBand
            {
                get { return lowerBand; }
                set { lowerBand = value;
                RaisePropertyChanged("LowerBand");
                }
            }

            private decimal upperBand;

            public decimal UpperBand
            {
                get { return upperBand; }
                set { upperBand = value;
                RaisePropertyChanged("UpperBand");
                }
            }
            

            public string ScriptName { get; set; }


            public event PropertyChangedEventHandler PropertyChanged;
        }
    
}

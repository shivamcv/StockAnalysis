using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
    public class StochasticData : INotifyPropertyChanged
    {
        public int StochasticDataId { get; set; }
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



        public int RecordId { get; set; }

        private decimal highestHigh_MiddlePeriod;

        public decimal HighestHigh_MiddlePeriod
        {
            get { return highestHigh_MiddlePeriod; }
            set { highestHigh_MiddlePeriod = value;
            RaisePropertyChanged("HighestHigh_MiddlePeriod");
            }
        }

        private decimal lowestLow_MiddlePeriod;

        public decimal LowestLow_MiddlePeriod
        {
            get { return lowestLow_MiddlePeriod; }
            set { lowestLow_MiddlePeriod = value;
            RaisePropertyChanged("LowestLow_MiddlePeriod");
            }
        }

        private decimal stochasticOscillator_MiddlePeriod;

        public decimal StochasticOscillator_MiddlePeriod
        {
            get { return stochasticOscillator_MiddlePeriod; }
            set { stochasticOscillator_MiddlePeriod = value;
            RaisePropertyChanged("StochasticOscillator_MiddlePeriod");
            }
        }

        private decimal highestHigh_UpperPeriod;

        public decimal HighestHigh_UpperPeriod
        {
            get { return highestHigh_UpperPeriod; }
            set { highestHigh_UpperPeriod = value;
            RaisePropertyChanged("HighestHigh_UpperPeriod");
            }
        }


        private decimal lowestLow_UpperPeriod;

        public decimal LowestLow_UpperPeriod
        {
            get { return lowestLow_UpperPeriod; }
            set { lowestLow_UpperPeriod = value;
            RaisePropertyChanged("LowestLow_UpperPeriod");
            }
        }

        private decimal stochasticOscillator_UpperPeriod;

        public decimal StochasticOscillator_UpperPeriod
        {
            get { return stochasticOscillator_UpperPeriod; }
            set { stochasticOscillator_UpperPeriod = value;
            RaisePropertyChanged("StochasticOscillator_UpperPeriod");
            }
        }
        


        public event PropertyChangedEventHandler PropertyChanged;
    }

}

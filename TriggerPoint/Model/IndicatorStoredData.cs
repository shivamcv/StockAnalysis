using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TriggerPoint.Model
{
   public class IndicatorStoredData
    {
        public List<IndicatorProfile> AverageProfiles { get; set; }
        public List<IndicatorProfile> RSIProfiles { get; set; }
        public List<IndicatorProfile> BollingerProfiles { get; set; }
        public List<IndicatorProfile> SwingProfiles { get; set; }
        public List<IndicatorProfile> MACDProfiles { get; set; }

        private IndicatorProfile[] serialisabelActiveProfiles;

        public IndicatorProfile[] SerialisabelActiveProfiles
        {
            get { return serialisabelActiveProfiles; }
            set
            {
                serialisabelActiveProfiles = value;

                DeseariliseActiveProfile();
            }
        }

        private void DeseariliseActiveProfile()
        {
            ActiveProfiles = new Dictionary<IndicatorEnum, IndicatorProfile>();
            ActiveProfiles[IndicatorEnum.Average] = serialisabelActiveProfiles[0];
            ActiveProfiles[IndicatorEnum.BollingerBand] = serialisabelActiveProfiles[1];
            ActiveProfiles[IndicatorEnum.MACD] = serialisabelActiveProfiles[2];
            ActiveProfiles[IndicatorEnum.RSI] = serialisabelActiveProfiles[3];
            ActiveProfiles[IndicatorEnum.Swing] = serialisabelActiveProfiles[4];
        }
        

        [XmlIgnore]
        public Dictionary<IndicatorEnum,IEnumerable<string>> AllColumns { get; set; }
        [XmlIgnore]
        public Dictionary<IndicatorEnum, IndicatorProfile> ActiveProfiles { get; set; }

      

       public List<IndicatorProfile> GetProfiles(IndicatorEnum indicatorType)
        {
            switch(indicatorType)
            {
                case IndicatorEnum.Average: return AverageProfiles;
                case IndicatorEnum.BollingerBand: return BollingerProfiles;
                case IndicatorEnum.MACD: return MACDProfiles;
                case IndicatorEnum.RSI: return RSIProfiles;
                case IndicatorEnum.Swing: return SwingProfiles;
                default: return AverageProfiles;
            }
        }

        public IndicatorStoredData()
        {
            AllColumns = new Dictionary<IndicatorEnum, IEnumerable<string>>();
            
            AllColumns.Add(IndicatorEnum.Average, new string[] { "AverageDataId", "ScriptId", "ScriptName", "DateTimeSlot", "DateTime","Date","Time", "Open", "High", "Low", "Average", "Close", "RecordId" });
            AllColumns.Add(IndicatorEnum.BollingerBand, new string[] { "id", "RecordId", "ScriptId", "DateTimeSlot", "DateTime", "Date", "Time", "Open", "High", "Low", "Close", "SMA", "StandardDeviation", "Deviations", "LowerBand", "UpperBand", "ScriptName" });
            AllColumns.Add(IndicatorEnum.MACD, new string[] { "MACDDataId", "ScriptId", "RecordId", "ScriptName", "DateTimeSlot", "DateTime", "Date", "Time", "Open", "High", "Low", "Close", "EMA1", "EMA2", "MACD", "Signal", "Percentage", "Histogram", "TragetGen", "BuySellPrice" });
            AllColumns.Add(IndicatorEnum.RSI, new string[] { "RSIDataId", "ScriptId", "ScriptName", "DateTimeSlot", "DateTime", "Date", "Time", "Open", "High", "Low", "Close", "RecordId", "Change", "Advance", "Decline", "AvgGain_Slow", "AvgLoss_Slow", "RS_Slow", "RSI_Slow", "AvgGain_Fast", "AvgLoss_Fast", "RS_Fast", "RSI_Fast", "TargetGenFast", "BuySellPriceFast", "TargetFast" });
            //AllColumns.Add(IndicatorEnum.Stochastic, new string[] { });
            AllColumns.Add(IndicatorEnum.Swing, new string[] { "SwingDataId", "ScriptId", "ScriptName", "DateTimeSlot", "DateTime", "Date", "Time", "Open", "High", "Low", "Close", "SwingIndex", "ATR", "ATRAvg", "UpperBand", "LowerBand", "AvgLowerBand", "AvgUpperBand", "DiffUp", "DiffLow", "Call", "RecordId" });

            AverageProfiles = new List<IndicatorProfile>();
            RSIProfiles = new List<IndicatorProfile>();
            MACDProfiles = new List<IndicatorProfile>();
            BollingerProfiles = new List<IndicatorProfile>();
            SwingProfiles = new List<IndicatorProfile>();

            ActiveProfiles = new Dictionary<IndicatorEnum, IndicatorProfile>();
        }

        internal void SerialiseActiveProfile()
        {
            serialisabelActiveProfiles = new IndicatorProfile[5];

            if (ActiveProfiles.ContainsKey(IndicatorEnum.Average))
                serialisabelActiveProfiles[0] = ActiveProfiles[IndicatorEnum.Average];
            if (ActiveProfiles.ContainsKey(IndicatorEnum.BollingerBand))
                serialisabelActiveProfiles[1] = ActiveProfiles[IndicatorEnum.BollingerBand];
            if (ActiveProfiles.ContainsKey(IndicatorEnum.MACD))
                serialisabelActiveProfiles[2] = ActiveProfiles[IndicatorEnum.MACD];
            if (ActiveProfiles.ContainsKey(IndicatorEnum.RSI))
                serialisabelActiveProfiles[3] = ActiveProfiles[IndicatorEnum.RSI];
            if (ActiveProfiles.ContainsKey(IndicatorEnum.Swing))
                serialisabelActiveProfiles[4] = ActiveProfiles[IndicatorEnum.Swing];
        }
    }

    public class IndicatorProfile
    {
        public string Name { get; set; }
        public List<string> ColumnList { get; set; }
        public HelperClasses.SerializableFont font { get; set; }
    }
}

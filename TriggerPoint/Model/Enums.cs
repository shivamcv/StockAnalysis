using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
    public enum CalculateTypes
    {
        Open = 1,
        Close = 2,
        Low = 3,
        High = 4
    }

    public enum MessageType
    {
        LoginSuccessful,
        LoginFailed,
    }

    public enum CallTypes
    {
        None,
        BuyCall,
        SellCall
    }

    public enum IndicatorEnum
    {
        MACD, RSI, Average, Stochastic, BollingerBand, Swing
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
     public class RSIIndicator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SlowPeriod { get; set; }
        public int FastPeriod { get; set; }
        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }
    }
}

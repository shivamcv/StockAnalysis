using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
   public class MACDIndicator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EMA1 { get; set; }
        public int EMA2 { get; set; }
        public int Signal { get; set; }
        public double Filter { get; set; }
        public bool IsBaseLine { get; set; }
    }
}

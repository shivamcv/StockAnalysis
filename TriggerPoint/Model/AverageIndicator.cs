using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
   public class AverageIndicator
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int TimePeriod { get; set; }
        public bool IsExponential { get; set; }
        public CalculateTypes CalculatedOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
  public  class BollingerIndicator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimePeriod { get; set; }
        public float StandDeviation { get; set; }
    }
}

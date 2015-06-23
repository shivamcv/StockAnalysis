using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.Model
{
    public class SwingIndicator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float LimitMove { get; set; }
        public int TimePeriod { get; set; }
        public int BandTimePeriod { get; set; }
    }
}

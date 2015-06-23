using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerPoint.HelperClasses
{
    public static class StandardDeviationExtention
    {
        public static decimal StandardDeviation(this IEnumerable<decimal> data)
        {
            decimal average = data.Average();
            var individualDeviations = data.Select(num => Math.Pow(Convert.ToDouble(num - average), 2.0));
            return Convert.ToDecimal(Math.Sqrt(individualDeviations.Average()));
        }
    }
}

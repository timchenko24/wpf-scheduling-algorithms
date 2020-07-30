using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingAlgorithms
{
    public class JobByRemainingComparer : IComparer<Job>
    {
        JobByArrivalTimeComparer c;

        public JobByRemainingComparer()
        {
            c = new JobByArrivalTimeComparer();
        }
        public int Compare(Job x, Job y)
        {
            if (x.RemainingTime.Equals(y.RemainingTime))
            {
                return c.Compare(x, y);
            }
            else
                return x.RemainingTime.CompareTo(y.RemainingTime);
        }
    }
}

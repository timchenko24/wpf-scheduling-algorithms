using System.Collections.Generic;

namespace SchedulingAlgorithms
{
    public class JobByBurstComparer : IComparer<Job>
    {
        JobByArrivalTimeComparer c;

        public JobByBurstComparer()
        {
            c = new JobByArrivalTimeComparer();
        }
        public int Compare(Job x, Job y)
        {
            if (x.Burst.Equals(y.Burst))
            {
                return c.Compare(x, y);
            }
            else
                return x.Burst.CompareTo(y.Burst);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingAlgorithms
{
    class JobByPriorityComparer : IComparer<Job>
    {
        JobByArrivalTimeComparer c;

        public JobByPriorityComparer()
        {
            c = new JobByArrivalTimeComparer();
        }
        public int Compare(Job x, Job y)
        {
            if (x.Priority.Equals(y.Priority))
            {
                return c.Compare(x, y);
            }
            else
                return x.Priority.CompareTo(y.Priority);
        }
    }
}

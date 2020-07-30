using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingAlgorithms
{
    public class JobByJobNumberComparer : IComparer<Job>
    {
        public int Compare(Job x, Job y)
        {
            return x.JobNumber.CompareTo(y.JobNumber);
        }
    }
}

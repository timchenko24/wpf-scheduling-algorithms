using System.Collections.Generic;

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

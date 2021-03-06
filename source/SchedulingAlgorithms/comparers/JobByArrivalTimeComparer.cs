﻿using System.Collections.Generic;

namespace SchedulingAlgorithms
{
    public class JobByArrivalTimeComparer : IComparer<Job>
    {
        JobByJobNumberComparer c;

        public JobByArrivalTimeComparer()
        {
            c = new JobByJobNumberComparer();
        }
        public int Compare(Job x, Job y)
        {
            if (x.ArrivalTime.Equals(y.ArrivalTime))
            {
                return c.Compare(x, y);
            }
            else
                return x.ArrivalTime.CompareTo(y.ArrivalTime);
            
        }

    }
}

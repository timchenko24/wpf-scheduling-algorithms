using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingAlgorithms
{
    public class FCFS : SchedulingAlgorithm
    {
        public FCFS(JobQueue workQueue) : base(workQueue, new JobByArrivalTimeComparer()) { }

        public override Job NextStep(int simulationTime)
        {
            UpdateReadyQueue(simulationTime);
            if (!isBusy)
            {
                if (readyQueue.IsEmpty())
                {
                    return null;
                }
                isBusy = true;
                SetCurrentJob();
            }
            return WorkInCPU(simulationTime);
        }

        protected override Job WorkInCPU(int simulationTime)
        {
            currentJob.JobWorked(simulationTime);
            if (currentJob.RemainingTime == 0)
            {
                isBusy = false;
            }
            return currentJob;
        }
    }
}



namespace SchedulingAlgorithms
{
    public class SJF : SchedulingAlgorithm
    {
        public SJF(JobQueue workQueue) : base(workQueue, new JobByArrivalTimeComparer()) { }

        public override Job NextStep(int simulationTime)
        {
            UpdateReadyQueue(simulationTime);
            if (simulationTime != 0 && currentJob.RemainingTime != 0)
            {
                readyQueue.AddJob(currentJob);
            }
            if (readyQueue.GetSize() > 1)
            {
                readyQueue.Sort(new JobByRemainingComparer());
            }
            if (readyQueue.IsEmpty())
            {
                return null;
            }
            SetCurrentJob();
            return WorkInCPU(simulationTime);
        }
    }
}

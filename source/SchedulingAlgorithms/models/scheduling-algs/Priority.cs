

namespace SchedulingAlgorithms
{
    public class Priority : SchedulingAlgorithm
    {
        public Priority(JobQueue workQueue) : base(workQueue, new JobByArrivalTimeComparer()) { }

        public override Job NextStep(int simulationTime)
        {
            UpdateReadyQueue(simulationTime);
            if (simulationTime != 0 && currentJob.RemainingTime != 0)
            {
                readyQueue.AddJob(currentJob);
            }
            if (readyQueue.GetSize() > 1)
            {
                readyQueue.Sort(new JobByPriorityComparer());
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

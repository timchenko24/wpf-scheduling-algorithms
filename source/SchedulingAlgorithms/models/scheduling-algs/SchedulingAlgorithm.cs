using System.Collections.Generic;

namespace SchedulingAlgorithms
{
    public abstract class SchedulingAlgorithm
    {
        protected JobQueue jobList;
        protected JobQueue readyQueue;
        protected Job currentJob;
        protected bool isBusy;
        protected IComparer<Job> comparer;

        public SchedulingAlgorithm(JobQueue jobList, IComparer<Job> comparer)
        {
            readyQueue = new JobQueue();
            currentJob = new Job(1000, 0, 0, 0);
            isBusy = false;
            this.jobList = jobList.GetCopy();
            this.comparer = comparer;
            jobList.Sort(this.comparer);
        }

        public abstract Job NextStep(int tick);

        protected virtual Job WorkInCPU(int tick)
        {
            currentJob.JobWorked(tick);
            return currentJob;
        }

        public bool IsFinished()
        {
            return (jobList.IsEmpty() && readyQueue.IsEmpty() && !isBusy && currentJob.RemainingTime == 0);
        }

        protected void UpdateReadyQueue(int simulationTime)
        {
            for (int i = 0; i < jobList.GetSize(); i++)
            {
                Job temp = jobList.GetJobById(i);
                if (temp.ArrivalTime == simulationTime)
                {
                    readyQueue.AddJob(temp);
                    jobList.Remove(i);
                    i--;
                }
            }
        }

        protected void SetCurrentJob()
        {
            currentJob = readyQueue.GetJobById(0);
            readyQueue.Remove(0);
        }
    }
}

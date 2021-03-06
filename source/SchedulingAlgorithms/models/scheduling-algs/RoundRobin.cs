﻿

namespace SchedulingAlgorithms
{
    public class RoundRobin : SchedulingAlgorithm
    {
        public int Quantum { get; set; }
        private int m_processTime;

        public RoundRobin(JobQueue workQueue, int quantum = 0) : base(workQueue, new JobByArrivalTimeComparer())
        {
            Quantum = quantum;
        }

        public override Job NextStep(int simulationTime)
        {
            UpdateReadyQueue(simulationTime);
            if (!isBusy)
            {
                if (simulationTime != 0 && currentJob.RemainingTime != 0)
                {
                    readyQueue.AddJob(currentJob);
                }
                if (readyQueue.IsEmpty())
                {
                    return null;
                }
                m_processTime = Quantum;
                isBusy = true;
                SetCurrentJob();
            }
            return WorkInCPU(simulationTime);
        }

        protected override Job WorkInCPU(int simulationTime)
        {
            currentJob.JobWorked(simulationTime);
            m_processTime--;
            if (m_processTime == 0 || currentJob.RemainingTime == 0)
            {
                isBusy = false;
            }
            return currentJob;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingAlgorithms
{
    public class RoundRobin : SchedulingAlgorithm
    {
        public int Quantum { get; set; }
        private int m_processTime;

        public RoundRobin(JobQueue workQueue, IComparer<Job> comparer, int quantum = 0) : base(workQueue, comparer)
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

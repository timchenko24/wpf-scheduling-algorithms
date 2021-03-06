﻿

namespace SchedulingAlgorithms
{
    public class Job
    {
        public int JobNumber { get; set; }
        public int ArrivalTime { get; set; }
        public int Burst { get; set; }
        public int Priority { get; set; } = 0;
        public int StartTime { get; set; }
        public bool IsFinished { get; set; }
        public int FinishTime { get; set; }
        public int RemainingTime { get; set; }

        public Job(int jobNumber, int arrivalTime, int burst, int priority)
        {
            JobNumber = jobNumber;
            ArrivalTime = arrivalTime;
            Burst = burst;
            RemainingTime = burst;
            Priority = priority;
            IsFinished = false;
            FinishTime = 0;
        }

        public void JobWorked(int tick)
        {
            if (Burst == RemainingTime)
            {
                StartTime = tick;
            }
            RemainingTime--;

            if (RemainingTime == 0)
            {
                FinishTime = tick + 1;
                IsFinished = true;
            }
        }

        public int GetComplitionPercent()
        {
            return ((Burst - RemainingTime) * 100) / Burst;
        }

        public int GetTurnaroundTime(int tick)
        {
            if (IsFinished)
            {
                return (FinishTime - ArrivalTime);
            }
            if (tick > ArrivalTime)
            {
                return (tick - ArrivalTime);
            }
            return 0;
        }

        public int GetWaitingTime(int tick)
        {
            return (GetTurnaroundTime(tick) - (Burst - RemainingTime));
        }

        public void Clear()
        {
            StartTime = 0;
            IsFinished = false;
            FinishTime = 0;
            RemainingTime = Burst;
        }
    }
}

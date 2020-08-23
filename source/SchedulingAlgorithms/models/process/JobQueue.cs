using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SchedulingAlgorithms
{
    public class JobQueue : IEnumerable
    {
        public List<Job> JobList { get; set; }

        public JobQueue()
        {
            JobList = new List<Job>();
        }

        public JobQueue(List<Job> list)
        {
            JobList = new List<Job>();
            JobList.AddRange(list);
        }

        public Job GetJobById(int id)
        {
            return JobList.ElementAt(id);
        }

        public void Remove(int id)
        {
            JobList.RemoveAt(id);
        }

        public void AddJob(Job job)
        {
            JobList.Add(job);
        }

        public bool IsEmpty()
        {
            return (JobList.Count == 0);
        }

        public int GetSize()
        {
            return JobList.Count;
        }

        public void Sort(IComparer<Job> comparer)
        {
            JobList.Sort(comparer);
        }

        public void Clear()
        {
            foreach (var item in JobList)
            {
                item.Clear();
            }
        }

        public IEnumerator GetEnumerator()
        {
            return JobList.GetEnumerator();
        }

        public JobQueue GetCopy()
        {
            return new JobQueue(JobList);
        }

        public double GetAverageWaitingTime(int tick)
        {
            double average = 0;
            foreach (var item in JobList)
            {
                average += item.GetWaitingTime(tick);
            }
            return average / JobList.Count;
        }

        public double GetAverageTurnaroundTime(int tick)
        {
            double average = 0;
            foreach (var item in JobList)
            {
                average += item.GetTurnaroundTime(tick);
            }
            return average / JobList.Count;
        }
    }
}

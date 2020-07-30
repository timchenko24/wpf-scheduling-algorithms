using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerator GetEnumerator()
        {
            return JobList.GetEnumerator();
        }
    }
}

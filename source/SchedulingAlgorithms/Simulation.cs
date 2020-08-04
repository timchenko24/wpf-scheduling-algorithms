using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingAlgorithms
{
    public class Simulation
    {
        public SchedulingAlgorithm Algorithm { get; set; }
        public int Time { get; set; } = 0;
        public int Quantum { get; set; } = 0;
        public bool Finished { get; set; } = false;
        public bool Stoped { get; set; } = true;

        public void Reset()
        {
            Time = 0;
            Finished = false;
        }

        public Job WorkStep()
        {
            Job job = Algorithm.NextStep(Time);
            if (Algorithm.IsFinished()) { Finished = true; }
            return job;
        }
    }
}

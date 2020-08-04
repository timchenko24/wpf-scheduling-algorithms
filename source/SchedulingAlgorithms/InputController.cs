using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingAlgorithms
{
    public class InputController : IDataErrorInfo
    {
        public int JobNumber { get; set; }
        public int ArrivalTime { get; set; }
        public int Burst { get; set; }
        public int Priority { get; set; } = 0;

        public InputController() { }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "JobNumber":
                        if ((JobNumber < 0) || (JobNumber > 90))
                        {
                            error = "Номер процесса должна быть больше 0 и меньше 90";
                        }
                        break;
                    case "ArrivalTime":
                        if ((ArrivalTime < 1) || (ArrivalTime > 90))
                        {
                            error = "Такт появления должен быть больше 0 и меньше 100";
                        }
                        break;
                    case "Burst":
                        if ((Burst <= 0) || (Burst > 24))
                        {
                            error = "CPU Burst должен быть больше 0 и меньше 24";
                        }
                        break;
                    case "Priority":
                        if ((Priority < 0) || (Priority > 15))
                        {
                            error = "Приоритет должен быть больше 0 и меньше 15";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { return String.Empty; }
        }
    }
}

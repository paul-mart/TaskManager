using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    // Interface for tasks
    public interface ITask
    {

            string TaskName { get; set; }
            string TaskDescription { get; set; }
            DateTime DueDate { get; set; }
            bool IsFinished { get; set; }

    }
}

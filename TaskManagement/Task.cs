/******************************
 * Paul Martin
 * Task Management
 * 12/22/23
 * CSI 255
 * Task management system that allows the user to create and remove
 * specific tasks.
 * ******************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    [Serializable]
    public abstract class Task : ITask, IComparable<Task>
    {
        private enum DateComparisonResult
        {
            Earlier = -1,
            Later = 1,
            TheSame = 0
        };

        // Instance variables
        private string taskName;
        private string taskDescription;
        private DateTime dueDate;
        private bool isFinished;

        // Constructors
        public Task(bool finished = false)
        {
            TaskName = "unnamedTask";
            TaskDescription = string.Empty;
            dueDate = DateTime.Now.AddDays(1);
            IsFinished = finished;
        }
        public Task(string taskTitle, string taskInfo, DateTime date, bool status)
        {
            TaskName = taskTitle;
            TaskDescription = taskInfo;
            DueDate = date;
            IsFinished = status;
        }

        // Properties
        public string TaskName
        {
            get { return taskName; }
            set {
                // Throw exceptions if value is null, empty, or exceeds character limit.
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException($"taskName is null or empty. {taskName}");
                if (value.Length > 26)
                    throw new ArgumentOutOfRangeException("taskName length needs to be 25 characters or less.");
               
                taskName = value;
            }
        }
        public string TaskDescription
        { get { return taskDescription; }
          set { taskDescription = value; }

        }
        public DateTime DueDate
        { 
            get { return dueDate; } 
            set { 
                if(value.CompareTo(DateTime.Now) != (int)DateComparisonResult.Later)
                    throw new ArgumentException($"A task's due date must be later than the current time. {value} is not later than {DateTime.Now}");
                
                dueDate = value;
            } 
        }

        public bool IsFinished
        {  get { return isFinished; } set {  isFinished = value; } }

        public override string ToString()
        {
            return $"{TaskName}: {TaskDescription}. Due: {DueDate} , Status: {(IsFinished? "Finished" : "Ongoing")}";
        }

        public int CompareTo(Task other)
        {
            if (other is null)
                return 1;
            return Compare() - other.Compare();
        }

        // Base (Task)
        public virtual int Compare()
        {
            return DueDate.Year * 1000 + (dueDate.Month+1) * 100 + (dueDate.Day+1);
        }
    }
}

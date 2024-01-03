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
    public enum PriorityLevel { Low=0, Medium=1, High=2 }

    [Serializable]
    public class WorkTask : Task
    {
        static void Main()
        {
            DateTime date = new DateTime(2023, 12, 23);

            WorkTask task1 = new WorkTask("Project2", "Yearly Project", date, false, PriorityLevel.High, 1000000m);

            Console.WriteLine(task1);
        }

        // Instance Variables
        private PriorityLevel priorityLevel;
        private decimal budget;
        
        public WorkTask(string taskTitle, string taskInfo, DateTime date, bool finished = false, 
            PriorityLevel urgency = PriorityLevel.Medium, decimal budgetAmt = 0m )
            :base(taskTitle, taskInfo, date, finished) 
        { 
            PriorityLevel = urgency;
            Budget = budgetAmt;
        }

        // Properties
        public PriorityLevel PriorityLevel
        {
            get { return priorityLevel; }
            set { priorityLevel = value; }
        }

        // Budget Property
        public decimal Budget { get { return budget; }
            set
            {
                // Only allow positive budget amount
                if (value < 1)
                    throw new ArgumentOutOfRangeException($"Budget value must be a positive number: {budget:C2}");
                budget = value;
            }
        }

        // Overriding base class ToString and adding derived class unique instance variables
        public override string ToString()
        {
            return base.ToString() + $" Priority Level: {priorityLevel}, Budget: {budget:C2}";
        }

        // Work
        public override int Compare()
        {
            int m = base.Compare() - ((int)PriorityLevel + 1) * 7;
            Console.WriteLine(this.TaskName + " " + m.ToString());
            return base.Compare() - ((int)PriorityLevel+1)*7;
        }
    }
}

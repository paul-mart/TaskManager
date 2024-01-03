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

    // enum for categories for personal task categories
    public enum Category { Housework, Errands, Leisure, General}
    [Serializable]
    public class PersonalTask : Task
    {

        private Category category;

        public PersonalTask(string taskTitle, string taskInfo, DateTime date, bool finished = false, Category taskCategory = Category.General)
            :base(taskTitle, taskInfo, date, finished)
        {
            Category = taskCategory;
        }

        // Property for category
        public Category Category { get { return category; } set { category = value; } }

        public override string ToString()
        {
            return $"[{Category}] " + base.ToString();
        }

        public override int Compare()
        {
            return base.Compare();
        }

    }
}

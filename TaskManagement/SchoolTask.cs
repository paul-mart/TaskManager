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
    // enum for school subjects
    public enum SchoolSubject { History, Math, English, Science}
    public enum AssignmentType { Essay, Homework, Project, Slideshow, QuestionSet, Reading}

    [Serializable]
    public class SchoolTask : Task
    {
        // Instance variables
        private SchoolSubject subject;
        private AssignmentType assignmentType;
        private decimal assignmentWeight;
        public SchoolTask(string taskTitle, string taskInfo, DateTime date, bool finished = false,
            SchoolSubject schoolSubject = SchoolSubject.English, AssignmentType typeOfAssignment = AssignmentType.Essay, 
            decimal weight = 10m, bool isFinished = false) 
            :base(taskTitle, taskInfo, date, finished) 
        {
            Subject = schoolSubject;
            assignmentType = typeOfAssignment;
            AssignmentWeight = weight;
            
        }

        //Properties
        public AssignmentType AssignmentType {
            get { return assignmentType; }
            set { 
                assignmentType = value; 
            }
        }

        public SchoolSubject Subject 
        { 
            get {  return subject; } 
            set { subject = value; }
        }

        // Add restrictions on setting (< 0 and >100)
        public decimal AssignmentWeight { get {  return assignmentWeight; } set {  assignmentWeight = value; } }

        // Overriding ToString for school task
        public override string ToString()
        {
            return base.ToString() + $" Subject: {Subject}, Type: {AssignmentType}, Assignment Weight: {AssignmentWeight}%.";
        }

        // School
        public override int Compare()
        {
            return base.Compare() + (int)AssignmentWeight;
        }

    }
}

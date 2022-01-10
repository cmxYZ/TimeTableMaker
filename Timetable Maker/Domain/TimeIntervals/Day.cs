using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public class Day
    {
        public DateTime Date;
        public List<ITask> taskList { get; }
        public List<ITask> unplacedTasks { get; set; }


        public Day(List<ITask> taskList, List<ITask> unplacedTasks, DateTime date)
        {
            Date = date;
            this.taskList = taskList;
            this.unplacedTasks = unplacedTasks;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public class Week
    {
        public readonly DateTime StartDate;
        public readonly DateTime EndDate;
        public List<Day> dayList { get; }
        public List<ITask> unplacedTasks { get; set; }

        public Week(List<Day> dayList, List<ITask> unplacedTasks, DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            this.dayList = dayList;
            this.unplacedTasks = unplacedTasks;
        }
    }
}

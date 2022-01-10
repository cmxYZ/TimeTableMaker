using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public class WeekGenerator : IGenerator<Week>
    {
        private List<DateTime> weekDates = new List<DateTime>();

        private List<Day> days;
        private List<ITask> unplacedTasks;

        public Week Generate(TaskCollector taskCollector)
        {
            var taskList = taskCollector.taskList;
            days = new List<Day>();
            unplacedTasks = new List<ITask>();
            FindDates(taskList);
            foreach(var date in weekDates)
            {
                var dayTasks = taskList.Where(task => task.TimeInterval.EndTime.Date == date ||
                 task.TimeInterval.EndTime == default(DateTime)).ToList();
                var dGenerator = new DayGenerator();
                var day = dGenerator.Generate(dayTasks);
                unplacedTasks.AddRange(day.unplacedTasks);
                day.unplacedTasks.Clear();
                day.Date = date;
                days.Add(day);
                UncheckTasks();
            }

            unplacedTasks = taskList.Where(task => !task.Checked).ToList();

            return new Week(days.Where(day => day.taskList.Count != 0).ToList(), unplacedTasks, weekDates.First(), weekDates.Last());
        }

        private void UncheckTasks()
        {
            foreach (var task in unplacedTasks)
                task.Checked = false;
            unplacedTasks.Clear();
        }

        private void FindDates(List<ITask> taskList)
        {
            var datesOrdered = taskList.Where(task => task.TimeInterval.EndTime != default(DateTime)).
                Select(task => task.TimeInterval.EndTime.Date).OrderBy(date => date);
            foreach (var date in datesOrdered)
                if (!weekDates.Contains(date))
                    weekDates.Add(date);
            if(weekDates.Count == 0)
            {
                var currentDate = DateTime.Now.Date;
                for (int i = 0; i < 7; i++)
                    weekDates.Add(new DateTime(currentDate.Year, currentDate.Month, currentDate.Day + i));
            }
        }
    }
}
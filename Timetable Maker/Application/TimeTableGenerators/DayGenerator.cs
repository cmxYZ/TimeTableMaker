using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public class DayGenerator : IGenerator<Day>
    {
        private List<ITask> UnplacedTasks;
        private List<ITask> GeneratedTaskList;
        private DateTime Date;
        private int StartHour = 8;
        private int EndHour = 23;

        public Day Generate(TaskCollector taskCollector)
        {
            var taskList = taskCollector.taskList;
            return Generate(taskList);
        }

        public Day Generate(List<ITask> taskList)
        {
            FindDate(taskList);
            UnplacedTasks = taskList.
                Where(task => task.TimeInterval.EndTime != default(DateTime) 
                    && task.TimeInterval.EndTime.Date != Date).ToList();
            taskList = taskList.Where(task => task.TimeInterval.EndTime == default(DateTime)
                   || task.TimeInterval.EndTime.Date == Date).ToList();

            GeneratedTaskList = taskList.Where(task => task.TimeInterval.StartTime != default(DateTime)).
                OrderBy(task => task.TimeInterval.StartTime).ToList();
            
            TakeOutCrossedTasks();

            AddTasksWithDeadline(taskList);

            AddSimpleTasks(taskList);
            UpdateTaskList();
            foreach (var task in UnplacedTasks)
                task.Checked = false;
            return new Day(GeneratedTaskList, UnplacedTasks, Date);
        }

        private void UpdateTaskList()
        {
            GeneratedTaskList = GeneratedTaskList.OrderBy(task => task.TimeInterval.StartTime).ToList();
        }

        public void AddTasksWithDeadline(List<ITask> taskList)
        {
            var tasksWithDeadline = taskList.Where(task => !task.Checked && task.TimeInterval.EndTime != default(DateTime)).
                OrderBy(task => task.TimeInterval.EndTime);
            foreach (TaskWithDeadline task in tasksWithDeadline)
            {
                var emptyIntervals = GetEmptyIntervals();
                foreach (var interval in emptyIntervals)
                    if (interval.EndTime >= task.Deadline && interval.Interval >= task.TimeInterval.Interval)
                    {
                        task.TimeInterval.StartTime = interval.StartTime;
                        task.TimeInterval.EndTime = task.TimeInterval.StartTime + task.TimeInterval.Interval;
                        task.Checked = true;
                        GeneratedTaskList.Add(task);
                        UpdateTaskList();
                    }
                if (!task.Checked)
                {
                    UnplacedTasks.Add(task);
                    task.Checked = true;
                }
            }
        }

        public void AddSimpleTasks(List<ITask> taskList)
        {
            var simpleTasks = taskList.
                Where(task => !task.Checked && task.TimeInterval.EndTime == default(DateTime)).
                OrderByDescending(task => task.TimeInterval.Interval);
            foreach (SimpleTask task in simpleTasks)
            {
                var emptyIntervals = GetEmptyIntervals().OrderByDescending(interval => interval.Interval);
                foreach (var interval in emptyIntervals)
                    if (interval.Interval >= task.TimeInterval.Interval && !task.Checked)
                    {
                        task.TimeInterval.StartTime = interval.StartTime;
                        task.TimeInterval.EndTime = task.TimeInterval.StartTime + task.TimeInterval.Interval;
                        task.Checked = true;
                        GeneratedTaskList.Add(task);
                        UpdateTaskList();
                    }
                if (!task.Checked)
                {
                    UnplacedTasks.Add(task);
                    task.Checked = true;
                }
            }
        }

        private List<TimeInterval> GetEmptyIntervals()
        {
            var resultList = new List<TimeInterval>();
            if (GeneratedTaskList.Count == 0)
            {
                resultList.Add(new TimeInterval(new DateTime(Date.Year, Date.Month, Date.Day, StartHour, 0, 0),
                      new DateTime(Date.Year, Date.Month, Date.Day, EndHour, 0, 0)));
                return resultList;
            }
            var taskInterval = GeneratedTaskList.First().TimeInterval;
            if(taskInterval.StartTime.Hour > StartHour)
                resultList.Add(new TimeInterval(new DateTime(Date.Year, Date.Month, Date.Day, StartHour, 0, 0),
                    new DateTime(Date.Year, Date.Month, Date.Day, taskInterval.StartTime.Hour, 0, 0)));
            taskInterval = GeneratedTaskList.Last().TimeInterval;
            if(taskInterval.EndTime.Hour < EndHour && GeneratedTaskList.Count == 1)
            {
                resultList.Add(new TimeInterval(new DateTime(Date.Year, Date.Month, Date.Day, taskInterval.EndTime.Hour, 0, 0),
                    new DateTime(Date.Year, Date.Month, Date.Day, EndHour, 0, 0)));
                return resultList;
            }
            for(int i = 0; i < GeneratedTaskList.Count - 2; i++)
            {
                var interval = new TimeInterval(GeneratedTaskList[i].TimeInterval.EndTime, GeneratedTaskList[i + 1].TimeInterval.StartTime);
                if (interval.Interval.TotalMinutes > 0)
                    resultList.Add(interval);
            }
            taskInterval = GeneratedTaskList.Last().TimeInterval;
            if (taskInterval.EndTime.Hour < EndHour)
                resultList.Add(new TimeInterval(new DateTime(Date.Year, Date.Month, Date.Day, taskInterval.EndTime.Hour, 0, 0),
                    new DateTime(Date.Year, Date.Month, Date.Day, EndHour, 0, 0)));
            return resultList.OrderBy(x => x.StartTime).ToList();
        }

        private void FindDate(List<ITask> taskList)
        {
            var dates = taskList.Where(task => task.TimeInterval.EndTime != default(DateTime)).
                Select(task => task.TimeInterval.EndTime.Date);
            if (!dates.Any())
            {
                Date = default(DateTime);
                return;
            }
            Dictionary<DateTime, int> datesFrequency = new Dictionary<DateTime, int>();
            foreach (var date in dates)
            {
                if (datesFrequency.ContainsKey(date))
                    datesFrequency[date]++;
                else datesFrequency.Add(date, 1);
            }
            var maxFrequency = datesFrequency.Values.Max();
            Date = datesFrequency.First(pair => pair.Value == maxFrequency).Key;
        }

        private void TakeOutCrossedTasks()
        {
            if (GeneratedTaskList.Count < 2)
            {
                var onlyTask = GeneratedTaskList.FirstOrDefault();
                if (onlyTask != null)
                    onlyTask.Checked = true;
                return;
            }
            for (int i = 0; i < GeneratedTaskList.Count - 2; i++)
                if (TasksCross(GeneratedTaskList[i], GeneratedTaskList[i + 1]))
                {
                    GeneratedTaskList[i].Checked = true;
                    UnplacedTasks.Add(GeneratedTaskList[i + 1]);
                }
                else
                {
                    GeneratedTaskList[i].Checked = true;
                    GeneratedTaskList[i + 1].Checked = true;
                }
            foreach(var task in GeneratedTaskList)
                if(!task.Checked)
                {
                    GeneratedTaskList.Remove(task);
                    UnplacedTasks.Add(task);
                    task.Checked = true;
                }
        }

        private bool TasksCross(ITask firstTask, ITask secondTask)
        {
            return firstTask.TimeInterval.EndTime > secondTask.TimeInterval.StartTime; 
        }
    }
}

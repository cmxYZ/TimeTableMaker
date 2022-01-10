using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    class TxtWeekOutputGenerator : IOutPutGenerator<Week>
    {
        private string fileName = "Новое расписание";
        private bool append = false;

        public void GenerateOutput(Week timeTableContent, string fileName)
        {
            this.fileName = fileName;
            GenerateOutput(timeTableContent);
        }

        public void GenerateOutput(Week timeTableContent)
        {
            fileName = System.IO.Path.GetFullPath(@"..\..\..\") + fileName + ".txt";
            foreach(var day in timeTableContent.dayList)
            {
                WriteTaskListForDay(day);
                using (var writer = new StreamWriter(fileName, append))
                {
                    writer.WriteLine('-' * 10);
                }
            }
        }

        public void WriteTaskListForDay(Day dayData)
        {
            var title = dayData.Date.Day.ToString() + "." + dayData.Date.Month.ToString();
            WriteTasksFromList(dayData.taskList, title);
            append = true;
            if (dayData.unplacedTasks.Count != 0)
                WriteTasksFromList(dayData.unplacedTasks, "Невместившиеся задания");
        }

        public void WriteTasksFromList(List<ITask> tasks, string title)
        {
            using (var textWriter = new StreamWriter(fileName, append))
            {
                textWriter.WriteLine(title);
                foreach(var task in tasks)
                {
                    var output = GenerateTaskInfo(task);
                    textWriter.WriteLine(output);
                }
            }
        }


        public string GenerateTaskInfo(ITask task)
        {
            var builder = new StringBuilder();
            if(task.Checked)
            {
                builder.Append(task.TimeInterval.StartTime.TimeOfDay);
                builder.Append(" - ");
                builder.Append(task.TimeInterval.EndTime.TimeOfDay);
                builder.Append(". ");
            }
            builder.Append(task.Name + ".");
            if (task.Description != "")
                builder.Append(" " + task.Description + ".");
            return builder.ToString();
        }
    }
}

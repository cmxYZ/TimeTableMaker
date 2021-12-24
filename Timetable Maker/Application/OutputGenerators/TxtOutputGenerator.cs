using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    class TxtOutputGenerator<T> : IOutPutGenerator<T>
    {
        private string fileName = "Новое расписание";
        private bool append = false;

        public void GenerateOutput(T timeTableContent, string fileName)
        {
            this.fileName = fileName;
            GenerateOutput(timeTableContent);
        }

        public void GenerateOutput(T timeTableContent)
        {
            fileName = System.IO.Path.GetFullPath(@"..\..\..\") + fileName + ".txt";
            WriteTaskListForDay(timeTableContent as Day);
        }

        public void WriteTaskListForDay(Day dayData)
        {
            var title = "Расписание на день";
            if (dayData.Date != default(DateTime))
                title = dayData.Date.Day.ToString() + "." + dayData.Date.Month.ToString();
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

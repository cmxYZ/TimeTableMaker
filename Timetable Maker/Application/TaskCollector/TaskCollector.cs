using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public class TaskCollector
    {
        public List<ITask> taskList = new List<ITask>();

        public void AddTask(string name, string description, TimeSpan requiredTime,
            DateTime startTime = default(DateTime), DateTime timeLimit = default(DateTime))
        {
            if (startTime == default(DateTime) && timeLimit == default(DateTime))
                taskList.Add(new SimpleTask(name, description, requiredTime));
            else if (startTime == default(DateTime) && timeLimit != default(DateTime))
                taskList.Add(new TaskWithDeadline(name, description, requiredTime, timeLimit));
            else if (startTime != default(DateTime) && timeLimit == default(DateTime))
                taskList.Add(new ExactTimeTask(name, description, requiredTime, startTime));
            else throw new ArgumentException("Wrong arguments combination!");
        }

        public void StartGenerationAsForm()
        {
            var generator = new DayGenerator();
            var day = generator.Generate(this);
            var list = new List<Day>();
            list.Add(day);
            var panels = new FormOutputGenerator<Day>().GenerateOutput(list);
            new TimetableForm(panels, this).ShowDialog();
        }

        public void StartGenerationAsTxt()
        {
            var generator = new DayGenerator();
            var day = generator.Generate(taskList);
            new TxtOutputGenerator<Day>().GenerateOutput(day);
        }

        public void StartGenerationAsExel()
        {
            var generator = new DayGenerator();
            var day = generator.Generate(taskList);
            new ExcelOutputGenerator<Day>().GenerateOutput(day);
        }
    }
}

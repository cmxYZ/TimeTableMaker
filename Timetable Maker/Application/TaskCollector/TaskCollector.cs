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

        public void StartGeneration()
        {
            var generator = new DayGenerator();
            var day = generator.Generate(this);
            var list = new List<Day>();
            list.Add(day);
            new FormOutputGenerator<Week>().GenerateOutput(list);
            //var generator = new DayGenerator();
            //var day = generator.Generate(taskList);
            //new TxtOutputGenerator<Day>().GenerateOutput(day);
        }
    }
}

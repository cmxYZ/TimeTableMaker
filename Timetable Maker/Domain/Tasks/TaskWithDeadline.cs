using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public class TaskWithDeadline : ITask
    {
        public TimeInterval TimeInterval { get; set; }
        public DateTime Deadline { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }

        public TaskWithDeadline(string name, string description, TimeSpan requiredTime,
            DateTime deadline = default(DateTime))
        {
            Name = name;
            Description = description;
            TimeInterval = new TimeInterval(requiredTime);
            Deadline = deadline;
            TimeInterval.EndTime = Deadline;
        }

        public override string ToString()
        {
            return $"{Name} {Description} Deadline: {TimeInterval.EndTime.ToString()}";
        }
    }
}

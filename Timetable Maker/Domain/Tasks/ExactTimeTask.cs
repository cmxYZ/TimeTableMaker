using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public class ExactTimeTask : ITask
    {
        public TimeInterval TimeInterval { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }

        public ExactTimeTask(string name, string description, TimeSpan requiredTime,
            DateTime startTime = default(DateTime))
        {
            Name = name;
            Description = description;
            var endTime = startTime + requiredTime;
            TimeInterval = new TimeInterval(startTime, endTime);
        }

        public override string ToString()
        {
            return $"{Name} {Description} StartTime: {TimeInterval.StartTime.ToString()}";
        }
    }
}

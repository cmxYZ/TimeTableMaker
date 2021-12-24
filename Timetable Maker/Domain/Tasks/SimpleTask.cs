using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public class SimpleTask : ITask
    {
        public TimeInterval TimeInterval { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }

        public SimpleTask(string name, string description, TimeSpan requiredTime)
        {
            Name = name;
            Description = description;
            TimeInterval = new TimeInterval(requiredTime);
        }

        public override string ToString()
        {
            return $"{Name} {Description}";
        }
    }
}

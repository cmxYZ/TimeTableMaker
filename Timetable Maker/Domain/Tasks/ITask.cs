using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public interface ITask
    {
        public TimeInterval TimeInterval { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
    }
}

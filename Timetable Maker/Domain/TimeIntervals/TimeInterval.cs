using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public class TimeInterval : ITimeInterval
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Interval { get; set; }

        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            Interval = EndTime.TimeOfDay - StartTime.TimeOfDay;
        }

        public TimeInterval(TimeSpan interval)
        {
            Interval = interval;
        }
    }
}

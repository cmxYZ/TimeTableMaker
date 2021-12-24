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

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append(StartTime.Hour.ToString() + ":");
            str.Append(StartTime.Minute < 10 ? "0" + StartTime.Minute.ToString() : StartTime.Minute.ToString());
            str.Append(" - " + EndTime.Hour.ToString() + ":");
            str.Append(EndTime.Minute < 10 ? "0" + EndTime.Minute.ToString() : EndTime.Minute.ToString());
            return str.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    public interface IOutPutGenerator<T>
    {
        public void GenerateOutput(T timeTableContent);

        public string GenerateTaskInfo(ITask task);
    }
}

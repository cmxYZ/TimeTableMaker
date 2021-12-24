using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    interface IGenerator<T>  //Сделал дженериком, тк разные генераторы возвращают разные обьекты (день, неделя и тд)
    {
        public T Generate(TaskCollector taskCollector);
    }
}

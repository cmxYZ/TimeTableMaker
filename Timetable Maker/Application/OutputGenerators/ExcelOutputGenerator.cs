//using System;
//using System.Data;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Timetable_Maker.Drawers
//{
//    class ExcelOutputGenerator<T> : IOutPutGenerator<T>
//    {
//        private DataTable TimeTable;

//        public void GenerateOutput(T timeTableContent)
//        {
//            TimeTable = new DataTable();
//            if (typeof(T) is Day)
//                GenerateDateColumn(timeTableContent as Day);

            
//        }

//        public void GenerateDateColumn(Day dayData)
//        {
//            var columnName = "Расписание на день";
//            if (dayData.Date != default(DateTime))
//                columnName = dayData.Date.Day.ToString() + "." + dayData.Date.Month.ToString();

//            var column = new DataColumn();
//            column.DataType = Type.GetType("System.string");
//            column.ColumnName = columnName;
//            column.AutoIncrement = false;
//            column.Caption = columnName;
//            column.ReadOnly = true;
//            column.Unique = false;
//            TimeTable.Columns.Add(column);
//            foreach (var task in dayData.taskList)
//            {
//                var row = TimeTable.NewRow();
//                row[columnName] = GenerateTaskInfo(task);
//                TimeTable.Rows.Add(row);
//            }
//        }

//        private string GenerateTaskInfo(ITask task)
//        {
//            var builder = new StringBuilder();
//            builder.Append(task.TimeInterval.StartTime.TimeOfDay);
//            builder.Append(" - ");
//            builder.Append(task.TimeInterval.EndTime.TimeOfDay);
//            builder.Append(". ");
//            builder.Append(task.Name);
//            return builder.ToString();
//        }
//    }
//}

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Threading.Tasks;

namespace Timetable_Maker
{
    class ExcelOutputGenerator<T> : IOutPutGenerator<T>
    {
        private string fileName = "Новое расписание";

        public void GenerateOutput(T timeTableContent, string fileName)
        {
            this.fileName = fileName;
            GenerateOutput(timeTableContent);
        }

        public void GenerateOutput(T timeTableContent)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            fileName = System.IO.Path.GetFullPath(@"..\..\..\") + fileName + ".xlsx";
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Расписание");
            sheet = GenerateDateColumn(timeTableContent as Day, sheet);
            var output = package.GetAsByteArray();
            File.WriteAllBytes(fileName, output);
        }

        public ExcelWorksheet GenerateDateColumn(Day dayData, ExcelWorksheet sheet)
        {
            var columnName = "Расписание на день";
            if (dayData.Date != default(DateTime))
                columnName = dayData.Date.Day.ToString() + "." + dayData.Date.Month.ToString();
            
            sheet.Cells[1, 1].Value = columnName;
            var row = 1;
            foreach(var task in dayData.taskList)
            {
                row++;
                sheet.Cells[row, 1].Value = GenerateTaskInfo(task);
            }
            sheet.Cells[1, 1, row, 1].AutoFitColumns();
            sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[1, 1, row, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
            sheet.Cells[1, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
            return sheet;
        }

        public string GenerateTaskInfo(ITask task)
        {
            var builder = new StringBuilder();
            builder.Append(task.TimeInterval.StartTime.TimeOfDay);
            builder.Append(" - ");
            builder.Append(task.TimeInterval.EndTime.TimeOfDay);
            builder.Append(". ");
            builder.Append(task.Name);
            return builder.ToString();
        }
    }
}

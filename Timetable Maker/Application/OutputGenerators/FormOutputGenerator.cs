using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Timetable_Maker
{
    public class FormOutputGenerator<T> : IOutPutGenerator<T>
    {
        public void GenerateOutput(T timeTableContent)
        {

        }

        public string GenerateTaskInfo(ITask task)
        {
            throw new NotImplementedException();
        }

        public void GenerateOutput(List<Day> dayList)
        {
            List<List<Panel>> panels = new List<List<Panel>>();
            for (int i = 0; i < dayList.Count; i++)
            {
                panels.Add(new List<Panel>());
                for (int j = 0; j < dayList[i].taskList.Count; j++)
                {
                    if (j == 0)
                    {
                        var dayDateLabel = new Label();
                        dayDateLabel.AutoSize = true;
                        dayDateLabel.Dock = DockStyle.Top;
                        dayDateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                        dayDateLabel.Location = new Point(5, 5);
                        dayDateLabel.Name = "dayDateLabel";
                        dayDateLabel.Size = new Size(168, 28);
                        dayDateLabel.TabIndex = 0;
                        dayDateLabel.Text = dayList[i].Date.DayOfWeek.ToString() + " " +
                            dayList[i].Date.Day.ToString() + "." +
                            dayList[i].Date.Month.ToString() + "." +
                            dayList[i].Date.Year.ToString();

                        panels[i].Add(new Panel());
                        panels[i][j].Controls.Add(dayDateLabel);
                        panels[i][j].Location = new Point(3, 3);
                        panels[i][j].Name = "datePanel";
                        panels[i][j].Padding = new Padding(5);
                        panels[i][j].Size = new Size(247, 50);
                        panels[i][j].TabIndex = 0;
                        panels[i][j].BorderStyle = BorderStyle.FixedSingle;
                    }

                    var NameLabel = new Label();
                    NameLabel.AutoSize = true;
                    NameLabel.Location = new Point(0, 0);
                    NameLabel.Name = "NameLabel";
                    NameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
                    NameLabel.Size = new Size(49, 20);
                    NameLabel.TabIndex = 0;
                    NameLabel.Text = dayList[i].taskList[j].Name;
                    
                    var TaskTimeLabel = new Label();
                    TaskTimeLabel.AutoSize = true;
                    TaskTimeLabel.Dock = DockStyle.Right;
                    TaskTimeLabel.Location = new Point(149, 5);
                    TaskTimeLabel.Name = "TaskTimeLabel";
                    TaskTimeLabel.Size = new Size(93, 20);
                    TaskTimeLabel.TabIndex = 1;
                    TaskTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
                    TaskTimeLabel.Text = dayList[i].taskList[j].TimeInterval.StartTime.Hour.ToString() + ":" +
                        dayList[i].taskList[j].TimeInterval.StartTime.Minute.ToString() + " - " + 
                        dayList[i].taskList[j].TimeInterval.EndTime.Hour.ToString() + ":" +
                        dayList[i].taskList[j].TimeInterval.EndTime.Minute.ToString();

                    var descrLabel = new Label();
                    descrLabel.AutoSize = true;
                    descrLabel.Dock = DockStyle.Bottom;
                    descrLabel.Location = new Point(5, 46);
                    descrLabel.MaximumSize = new Size(250, 50);
                    descrLabel.Name = "descrLabel";
                    descrLabel.Size = new Size(162, 20);
                    descrLabel.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
                    descrLabel.TabIndex = 2;
                    descrLabel.TextAlign = ContentAlignment.MiddleLeft;
                    descrLabel.Text = dayList[i].taskList[j].Description;

                    panels[i].Add(new Panel());
                    panels[i][j + 1].Controls.Add(descrLabel);
                    panels[i][j + 1].Controls.Add(TaskTimeLabel);
                    panels[i][j + 1].Controls.Add(NameLabel);
                    panels[i][j + 1].Location = new Point(3, 3);
                    panels[i][j + 1].Name = "taskPanel";
                    panels[i][j + 1].Padding = new Padding(5);
                    panels[i][j + 1].Size = new Size(247, 91);
                    panels[i][j + 1].TabIndex = 1;
                    panels[i][j + 1].BorderStyle = BorderStyle.FixedSingle;
                }
            }
            new TimetableForm(panels).ShowDialog();
        }
    }
}

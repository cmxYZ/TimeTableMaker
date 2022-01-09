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

        public Panel GenerateDatePanel(DateTime dt)
        {
            var dayDateLabel = new Label();
            dayDateLabel.AutoSize = true;
            dayDateLabel.Dock = DockStyle.Top;
            dayDateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dayDateLabel.Location = new Point(5, 5);
            dayDateLabel.Name = "dayDateLabel";
            dayDateLabel.Size = new Size(168, 28);
            dayDateLabel.TabIndex = 0;
            dayDateLabel.Text = dt.DayOfWeek.ToString() + " " +
                dt.Day.ToString() + "." +
                dt.Month.ToString() + "." +
                dt.Year.ToString();

            var panel = new Panel();
            panel.Controls.Add(dayDateLabel);
            panel.Location = new Point(3, 3);
            panel.Name = "datePanel";
            panel.Padding = new Padding(5);
            panel.Size = new Size(247, 50);
            panel.TabIndex = 0;
            panel.BorderStyle = BorderStyle.FixedSingle;
            return panel;
        }

        public Label CreateNameLabel(string taskName)
        {
            var name = new Label();
            name.AutoSize = true;
            name.Location = new Point(0, 0);
            name.Name = "NameLabel";
            name.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            name.Size = new Size(49, 20);
            name.TabIndex = 0;
            name.Text = taskName;
            return name;
        }

        public Label CreateDescriptionLabel(string taskDescription)
        {
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
            descrLabel.Text = taskDescription;
            return descrLabel;
        }

        public Label CreateTaskTimeLabel(TimeInterval timeInterval)
        {
            var timeLabel = new Label();
            timeLabel.AutoSize = true;
            timeLabel.Dock = DockStyle.Right;
            timeLabel.Location = new Point(149, 5);
            timeLabel.Name = "TaskTimeLabel";
            timeLabel.Size = new Size(93, 20);
            timeLabel.TabIndex = 1;
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            timeLabel.Text = timeInterval.ToString();
            return timeLabel;
        }

        public List<List<Panel>> GenerateOutput(List<Day> dayList)
        {
            List<List<Panel>> panels = new List<List<Panel>>();
            for (int i = 0; i < dayList.Count; i++)
            {
                panels.Add(new List<Panel>());
                panels[i].Add(GenerateDatePanel(dayList[i].Date));
                for (int j = 0; j < dayList[i].taskList.Count; j++)
                {
                    var NameLabel = CreateNameLabel(dayList[i].taskList[j].Name);
                    var TaskTimeLabel = CreateTaskTimeLabel(dayList[i].taskList[j].TimeInterval);
                    var descrLabel = CreateDescriptionLabel(dayList[i].taskList[j].Description);
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
            return panels;
        }
    }
}

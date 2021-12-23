using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable_Maker
{
    public class TimetableForm : Form
    {
        private FlowLayoutPanel mainLayout;
        private List<List<Panel>> panels;

        public TimetableForm(List<List<Panel>> panels)
        {
            this.panels = panels;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            mainLayout = new FlowLayoutPanel();
            //this.dayLayout = new FlowLayoutPanel();
            mainLayout.SuspendLayout();
            //this.dayLayout.SuspendLayout();
            SuspendLayout();

            mainLayout.AutoSize = true;
            mainLayout.Location = new Point(12, 12);
            mainLayout.Name = "mainLayout";
            mainLayout.Size = new Size(1095, 634);
            mainLayout.TabIndex = 0;
            mainLayout.WrapContents = false;

            for (int i = 0; i < panels.Count; i++)
            {
                var dayLayout = new FlowLayoutPanel(); 
                dayLayout.Location = new Point(3, 3);
                dayLayout.Name = "dayLayout";
                dayLayout.Size = new Size(250, 628);
                dayLayout.TabIndex = 0;
                mainLayout.Controls.Add(dayLayout);
                for (int j = 0; j < panels[i].Count; j++)
                {
                    dayLayout.Controls.Add(panels[i][j]);
                }
            }
            
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new Size(1119, 655);
            this.Controls.Add(mainLayout);
            this.Name = "TimetableForm";
            this.Text = "Timetable Maker";
            this.mainLayout.ResumeLayout(false);
            //this.dayLayout.ResumeLayout(false);
            //this.taskPanel.ResumeLayout(false);
            //this.taskPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
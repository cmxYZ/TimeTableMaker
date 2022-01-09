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
        private List<List<Panel>> panels;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private ToolStripMenuItem exelToolStripMenuItem;
        private ToolStripMenuItem txtToolStripMenuItem;
        private TaskCollector taskCollector;

        public TimetableForm(List<List<Panel>> panels, TaskCollector taskCollector)
        {
            this.taskCollector = taskCollector;
            this.panels = panels;
            InitializeComponent();
        }

        private void SaveAsTxtButtonClick(object sender, EventArgs e)
        {
            taskCollector.StartGenerationAsTxt();
        }

        private void SaveAsExelButtonClick(object sender, EventArgs e)
        {
            taskCollector.StartGenerationAsExel();
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            for (int i = 0; i < panels.Count; i++)
            {
                var dayLayout = new FlowLayoutPanel();
                dayLayout.Location = new System.Drawing.Point(12 + (270 * i), 40);
                dayLayout.Name = "dayLayout";
                dayLayout.Size = new System.Drawing.Size(260, 500);
                dayLayout.TabIndex = 0;
                dayLayout.AutoSize = true;
                dayLayout.WrapContents = false;
                dayLayout.FlowDirection = FlowDirection.TopDown;
                for (int j = 0; j < panels[i].Count; j++)
                {
                    dayLayout.Controls.Add(panels[i][j]);
                }
                Controls.Add(dayLayout);
            }
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьКакToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(985, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exelToolStripMenuItem,
            this.txtToolStripMenuItem});
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            // 
            // exelToolStripMenuItem
            // 
            this.exelToolStripMenuItem.Name = "exelToolStripMenuItem";
            this.exelToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.exelToolStripMenuItem.Text = "Exel";
            this.exelToolStripMenuItem.Click += ExelToolStripMenuItem_Click;
            // 
            // txtToolStripMenuItem
            // 
            this.txtToolStripMenuItem.Name = "txtToolStripMenuItem";
            this.txtToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.txtToolStripMenuItem.Text = "Txt";
            this.txtToolStripMenuItem.Click += TxtToolStripMenuItem_Click;
            // 
            // TimetableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(985, 655);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TimetableForm";
            this.Text = "Timetable Maker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskCollector.StartGenerationAsTxt();
        }

        private void ExelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskCollector.StartGenerationAsExel();
        }
    }
}


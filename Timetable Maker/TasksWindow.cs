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
    public class TasksWindow : Form
    {
        private Label tasksLabel;
        private Button addTaskButton;
        private Button generateButton;
        private ListBox tasksList;
        private TaskCollector taskCollector;

        public TasksWindow(TaskCollector taskCollector)
        {
            InitializeComponent();
            this.taskCollector = taskCollector;
        }

        private void AddItemClick(object sender, EventArgs e)
        {
            new AddTaskWindow(taskCollector).ShowDialog();
            UpdateList();
        }

        private void GenerateTimetableClick(object sender, EventArgs e)
        {
            taskCollector.StartGeneration();
        }

        private void UpdateList()
        {
            tasksList.Items.Clear();
            foreach (var task in taskCollector.taskList)
            {
                tasksList.Items.Add(task);
            }
        }

        private void InitializeComponent()
        {
            this.tasksLabel = new System.Windows.Forms.Label();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.tasksList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tasksLabel
            // 
            this.tasksLabel.AutoSize = true;
            this.tasksLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tasksLabel.Location = new System.Drawing.Point(190, 16);
            this.tasksLabel.Name = "tasksLabel";
            this.tasksLabel.Size = new System.Drawing.Size(96, 46);
            this.tasksLabel.TabIndex = 0;
            this.tasksLabel.Text = "Tasks";
            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(29, 378);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(194, 49);
            this.addTaskButton.TabIndex = 2;
            this.addTaskButton.Text = "Add Task";
            this.addTaskButton.UseVisualStyleBackColor = true;
            this.addTaskButton.Click += new System.EventHandler(this.AddItemClick);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(242, 378);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(191, 49);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate Timetable";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateTimetableClick);
            // 
            // tasksList
            // 
            this.tasksList.FormattingEnabled = true;
            this.tasksList.ItemHeight = 20;
            this.tasksList.Location = new System.Drawing.Point(29, 82);
            this.tasksList.Name = "tasksList";
            this.tasksList.Size = new System.Drawing.Size(404, 264);
            this.tasksList.TabIndex = 4;
            // 
            // TasksWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 450);
            this.Controls.Add(this.tasksList);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.tasksLabel);
            this.Name = "TasksWindow";
            this.Text = "Timetable Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
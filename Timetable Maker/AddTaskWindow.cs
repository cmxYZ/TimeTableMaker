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
    public class AddTaskWindow : Form
    {
        private Label nameLabel;
        private Label descriptionLable;
        private TextBox nameTextBox;
        private RichTextBox descriptionTextBox;
        private DateTimePicker deadlinePicker;
        private Label DeadLineLabel;
        private Label startTimeLabel;
        private DateTimePicker startTimePicker;
        private Button AddButton;
        private Label requiredTimeLabel;
        private DateTimePicker requiredTimePicker;
        private CheckBox startTimeCheck;
        private CheckBox deadlineCheck;
        private TaskCollector taskCollector;

        public AddTaskWindow(TaskCollector taskCollector)
        {
            InitializeComponent();
            this.taskCollector = taskCollector;
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            DateTime startTime = startTimeCheck.Checked ? startTimePicker.Value : default(DateTime);
            DateTime deadline = deadlineCheck.Checked ? deadlinePicker.Value : default(DateTime);
            taskCollector.AddTask(nameTextBox.Text, descriptionTextBox.Text, 
                new TimeSpan(requiredTimePicker.Value.Hour, requiredTimePicker.Value.Minute, 0), 
                startTime, deadline);
            Close();
        }

        private void startTimeCheck_CheckedChanged(object sender, EventArgs e)
        {
            startTimePicker.Visible = !startTimePicker.Visible;
        }

        private void deadlineCheck_CheckedChanged(object sender, EventArgs e)
        {
            deadlinePicker.Visible = !deadlinePicker.Visible;
        }

        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLable = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.requiredTimeLabel = new System.Windows.Forms.Label();
            this.deadlinePicker = new System.Windows.Forms.DateTimePicker();
            this.DeadLineLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AddButton = new System.Windows.Forms.Button();
            this.requiredTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimeCheck = new System.Windows.Forms.CheckBox();
            this.deadlineCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(21, 23);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(60, 28);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "name";
            // 
            // descriptionLable
            // 
            this.descriptionLable.AutoSize = true;
            this.descriptionLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionLable.Location = new System.Drawing.Point(21, 89);
            this.descriptionLable.Name = "descriptionLable";
            this.descriptionLable.Size = new System.Drawing.Size(110, 28);
            this.descriptionLable.TabIndex = 1;
            this.descriptionLable.Text = "description";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameTextBox.Location = new System.Drawing.Point(223, 23);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(255, 34);
            this.nameTextBox.TabIndex = 2;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionTextBox.Location = new System.Drawing.Point(223, 89);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(255, 108);
            this.descriptionTextBox.TabIndex = 3;
            this.descriptionTextBox.Text = "";
            // 
            // requiredTimeLabel
            // 
            this.requiredTimeLabel.AutoSize = true;
            this.requiredTimeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.requiredTimeLabel.Location = new System.Drawing.Point(21, 226);
            this.requiredTimeLabel.Name = "requiredTimeLabel";
            this.requiredTimeLabel.Size = new System.Drawing.Size(130, 28);
            this.requiredTimeLabel.TabIndex = 4;
            this.requiredTimeLabel.Text = "required time";
            // 
            // deadlinePicker
            // 
            this.deadlinePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.deadlinePicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deadlinePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.deadlinePicker.Location = new System.Drawing.Point(262, 375);
            this.deadlinePicker.Name = "deadlinePicker";
            this.deadlinePicker.Size = new System.Drawing.Size(216, 34);
            this.deadlinePicker.TabIndex = 7;
            this.deadlinePicker.Visible = false;
            // 
            // DeadLineLabel
            // 
            this.DeadLineLabel.AutoSize = true;
            this.DeadLineLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeadLineLabel.Location = new System.Drawing.Point(21, 380);
            this.DeadLineLabel.Name = "DeadLineLabel";
            this.DeadLineLabel.Size = new System.Drawing.Size(87, 28);
            this.DeadLineLabel.TabIndex = 8;
            this.DeadLineLabel.Text = "deadline";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startTimeLabel.Location = new System.Drawing.Point(21, 303);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(95, 28);
            this.startTimeLabel.TabIndex = 9;
            this.startTimeLabel.Text = "start time";
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.startTimePicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(262, 303);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(216, 34);
            this.startTimePicker.TabIndex = 10;
            this.startTimePicker.Visible = false;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddButton.Location = new System.Drawing.Point(142, 444);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(228, 49);
            this.AddButton.TabIndex = 11;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // requiredTimePicker
            // 
            this.requiredTimePicker.CustomFormat = "HH:mm";
            this.requiredTimePicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.requiredTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.requiredTimePicker.Location = new System.Drawing.Point(223, 226);
            this.requiredTimePicker.Name = "requiredTimePicker";
            this.requiredTimePicker.Size = new System.Drawing.Size(82, 34);
            this.requiredTimePicker.TabIndex = 12;
            // 
            // startTimeCheck
            // 
            this.startTimeCheck.AutoSize = true;
            this.startTimeCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startTimeCheck.Location = new System.Drawing.Point(223, 310);
            this.startTimeCheck.Name = "startTimeCheck";
            this.startTimeCheck.Size = new System.Drawing.Size(18, 17);
            this.startTimeCheck.TabIndex = 13;
            this.startTimeCheck.UseVisualStyleBackColor = true;
            this.startTimeCheck.CheckedChanged += new System.EventHandler(this.startTimeCheck_CheckedChanged);
            // 
            // deadlineCheck
            // 
            this.deadlineCheck.AutoSize = true;
            this.deadlineCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deadlineCheck.Location = new System.Drawing.Point(223, 387);
            this.deadlineCheck.Name = "deadlineCheck";
            this.deadlineCheck.Size = new System.Drawing.Size(18, 17);
            this.deadlineCheck.TabIndex = 14;
            this.deadlineCheck.UseVisualStyleBackColor = true;
            this.deadlineCheck.CheckedChanged += new System.EventHandler(this.deadlineCheck_CheckedChanged);
            // 
            // AddTaskWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 514);
            this.Controls.Add(this.deadlineCheck);
            this.Controls.Add(this.startTimeCheck);
            this.Controls.Add(this.requiredTimePicker);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.DeadLineLabel);
            this.Controls.Add(this.deadlinePicker);
            this.Controls.Add(this.requiredTimeLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.descriptionLable);
            this.Controls.Add(this.nameLabel);
            this.MaximizeBox = false;
            this.Name = "AddTaskWindow";
            this.Text = "Timetable Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
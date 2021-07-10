
namespace WindowsFormsApp1.WUI {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblProfessor = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ctrlCourses = new System.Windows.Forms.DataGridView();
            this.ctrlStudents = new System.Windows.Forms.DataGridView();
            this.virtualServerModeSource1 = new DevExpress.Data.VirtualServerModeSource(this.components);
            this.ctrlProfessors = new System.Windows.Forms.DataGridView();
            this.ctrlSchedules = new System.Windows.Forms.DataGridView();
            this.ctrlStudentCourses = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.virtualServerModeSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlProfessors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlStudentCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(230, 529);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(143, 32);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(24, 546);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(143, 32);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(196, 484);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(195, 27);
            this.dateTimePicker.TabIndex = 10;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(920, 789);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(143, 32);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1069, 789);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(143, 32);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label6.Location = new System.Drawing.Point(12, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(569, 59);
            this.label6.TabIndex = 13;
            this.label6.Text = "University Courses Scheduler";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1224, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToScheduleToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadDataToolStripMenuItem,
            this.saveDataToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.mainToolStripMenuItem.Text = "File";
            // 
            // addToScheduleToolStripMenuItem
            // 
            this.addToScheduleToolStripMenuItem.Name = "addToScheduleToolStripMenuItem";
            this.addToScheduleToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.addToScheduleToolStripMenuItem.Text = "Add To Schedule...";
            this.addToScheduleToolStripMenuItem.Click += new System.EventHandler(this.addToScheduleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.loadDataToolStripMenuItem.Text = "Load Data";
            this.loadDataToolStripMenuItem.Click += new System.EventHandler(this.loadDataToolStripMenuItem_Click);
            // 
            // saveDataToolStripMenuItem
            // 
            this.saveDataToolStripMenuItem.Name = "saveDataToolStripMenuItem";
            this.saveDataToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.saveDataToolStripMenuItem.Text = "Save Data";
            this.saveDataToolStripMenuItem.Click += new System.EventHandler(this.saveDataToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(210, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCourse.Location = new System.Drawing.Point(20, 144);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(129, 23);
            this.lblCourse.TabIndex = 16;
            this.lblCourse.Text = "Choose Course:";
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblStudent.Location = new System.Drawing.Point(425, 144);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(135, 23);
            this.lblStudent.TabIndex = 17;
            this.lblStudent.Text = "Choose Student:";
            // 
            // lblProfessor
            // 
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblProfessor.Location = new System.Drawing.Point(788, 144);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(146, 23);
            this.lblProfessor.TabIndex = 18;
            this.lblProfessor.Text = "Choose Professor:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label10.Location = new System.Drawing.Point(203, 447);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "Choose Date and Time:";
            // 
            // ctrlCourses
            // 
            this.ctrlCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlCourses.Location = new System.Drawing.Point(24, 185);
            this.ctrlCourses.Name = "ctrlCourses";
            this.ctrlCourses.RowHeadersWidth = 51;
            this.ctrlCourses.RowTemplate.Height = 24;
            this.ctrlCourses.Size = new System.Drawing.Size(364, 244);
            this.ctrlCourses.TabIndex = 21;
            // 
            // ctrlStudents
            // 
            this.ctrlStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlStudents.Location = new System.Drawing.Point(415, 185);
            this.ctrlStudents.Name = "ctrlStudents";
            this.ctrlStudents.RowHeadersWidth = 51;
            this.ctrlStudents.RowTemplate.Height = 24;
            this.ctrlStudents.Size = new System.Drawing.Size(352, 244);
            this.ctrlStudents.TabIndex = 22;
            // 
            // ctrlProfessors
            // 
            this.ctrlProfessors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlProfessors.Location = new System.Drawing.Point(792, 185);
            this.ctrlProfessors.Name = "ctrlProfessors";
            this.ctrlProfessors.RowHeadersWidth = 51;
            this.ctrlProfessors.RowTemplate.Height = 24;
            this.ctrlProfessors.Size = new System.Drawing.Size(348, 244);
            this.ctrlProfessors.TabIndex = 23;
            // 
            // ctrlSchedules
            // 
            this.ctrlSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlSchedules.Location = new System.Drawing.Point(22, 584);
            this.ctrlSchedules.Name = "ctrlSchedules";
            this.ctrlSchedules.RowHeadersWidth = 51;
            this.ctrlSchedules.RowTemplate.Height = 24;
            this.ctrlSchedules.Size = new System.Drawing.Size(1118, 180);
            this.ctrlSchedules.TabIndex = 24;
            // 
            // ctrlStudentCourses
            // 
            this.ctrlStudentCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlStudentCourses.Location = new System.Drawing.Point(573, 447);
            this.ctrlStudentCourses.Name = "ctrlStudentCourses";
            this.ctrlStudentCourses.RowHeadersWidth = 51;
            this.ctrlStudentCourses.RowTemplate.Height = 24;
            this.ctrlStudentCourses.Size = new System.Drawing.Size(194, 129);
            this.ctrlStudentCourses.TabIndex = 25;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1224, 833);
            this.Controls.Add(this.ctrlStudentCourses);
            this.Controls.Add(this.ctrlSchedules);
            this.Controls.Add(this.ctrlProfessors);
            this.Controls.Add(this.ctrlStudents);
            this.Controls.Add(this.ctrlCourses);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblProfessor);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "University Courses Scheduler Application";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.virtualServerModeSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlProfessors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlStudentCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        
        private System.Windows.Forms.Button button6;
 
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
  
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem loadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToolStripMenuItem;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView ctrlCourses;
        private System.Windows.Forms.DataGridView ctrlStudents;
        private DevExpress.Data.VirtualServerModeSource virtualServerModeSource1;
        private System.Windows.Forms.DataGridView ctrlProfessors;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView ctrlSchedules;
        private System.Windows.Forms.DataGridView ctrlStudentCourses;
    }
}
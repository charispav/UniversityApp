using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using UniversityApp.Model;
using UniversityApp.Storage;


namespace WindowsFormsApp1.WUI {
    
    public partial class MainForm : Form {

        private University ViewData = new University();
       
        public MainForm() {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e) {
           
            LoadData();
        }
        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveData();
        }


        private void btnLoad_Click(object sender, EventArgs e) {
            LoadScheduleData();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveData();
        }
        private void AddSchedule() {
            ViewData.Schedules.Add(new Schedule() {
                CourseID =(Guid)ctrlCourses.SelectedRows[0].Cells["ID"].Value,
                StudentID = (Guid)ctrlStudents.SelectedRows[0].Cells["ID"].Value,
                ProfessorID = (Guid)ctrlProfessors.SelectedRows[0].Cells["ID"].Value,
                Calendar = dateTimePicker.Value
            }) ;
            ParametricLoadData<Schedule>();
            
        }
        private void SaveData() {
            Storage<University>.SerializeToJSON(ViewData);
        }
        private void LoadData() {

            ViewData = Storage<University>.DeserializeFromJSON();
            
            ParametricLoadData<Student>();
            ParametricLoadData<Professor>();
            ParametricLoadData<Course>();
        }

        private void ParametricLoadData<T>() where T : class {
            BindingSource bindingSource = new BindingSource();
            DataGridView dataGridView = new DataGridView();
            if (typeof(T) == typeof(Student)) {
                bindingSource.DataSource = ViewData.Students;
                ctrlStudents.DataSource = bindingSource;
                dataGridView = ctrlStudents;

            }
            else if (typeof(T) == typeof(Professor)) {
                bindingSource.DataSource = ViewData.Professors;
                ctrlProfessors.DataSource = bindingSource;
                dataGridView = ctrlProfessors;

            }
            else if (typeof(T) == typeof(Course)) {
                bindingSource.DataSource = ViewData.Courses;
                ctrlCourses.DataSource = bindingSource;
                dataGridView = ctrlCourses;

            }
            else if (typeof(T) == typeof(Schedule)) {  
                bindingSource.DataSource = from schedule in ViewData.Schedules
                                                   join student in ViewData.Students on schedule.StudentID equals student.ID
                                                   join professor in ViewData.Professors on schedule.ProfessorID equals professor.ID
                                                   join course in ViewData.Courses on schedule.CourseID equals course.ID
                                                   select new {
                                                       Date = schedule.Calendar,
                                                       ProfessorName = professor.Name,
                                                       ProfessorSurname = professor.Surname,
                                                       StudentName = student.Name,
                                                       StudentSurname = student.Surname,
                                                       Code = course.Code,
                                                       Subject = course.Subject,
                                                       ID = schedule.ID
                                                   };
                ctrlSchedules.DataSource = bindingSource;
                dataGridView = ctrlSchedules;
            }

            dataGridView.Columns["ID"].Visible = false;
        }

        private void LoadScheduleData() {
            ViewData = Storage<University>.DeserializeFromJSON();

            ParametricLoadData<Schedule>();

        }

        public void validate_professorCourse_with_studentCourse() {

            //TODO: ???

        }

        private void addToScheduleToolStripMenuItem_Click(object sender, EventArgs e) {

            // todo : display on a grid??

            // todo: add exception handling?
            

        }

        private void btnAdd_Click(object sender, EventArgs e) {
            //    try {

            //        // TODO: 1. CANNOT ADD SAME STUDENT + PROFESSOR IN SAME DATE & HOUR

            //        // TODO: 2. EACH STUDENT CANNOT HAVE MORE THAN 3 COURSES PER DAY!

            //        // TODO: 3. A PROFESSOR CANNOT TEACH MORE THAN 4 COURSES PER DAY AND 40 COURSES PER WEEK

            //        ViewData.Schedules.Add(new Schedule() { Course = listCourses.SelectedItem.ToString(), Student = listStudents.SelectedItem.ToString(), Professor = listProfessors.SelectedItem.ToString(), Calendar = dateTimePicker.Value });

            //        ctrlSchedule.Items.Clear();
            //        foreach (var AA in ViewData.Schedules) {

            //            ctrlSchedule.Items.Add(AA.Calendar + " | " + AA.Course + " | " + AA.Student + " | " + AA.Professor);

            //        }
            //    }
            //    catch {

            //    }
            //    finally {
            //        MessageBox.Show("all ok!");

            //    }
            AddSchedule();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }

}


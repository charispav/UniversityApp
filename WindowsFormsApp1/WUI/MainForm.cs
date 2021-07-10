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
using System.Globalization;

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

            Guid selectedProfessorID = (Guid)ctrlProfessors.SelectedRows[0].Cells["ID"].Value;
            Guid selectedStudentID = (Guid)ctrlStudents.SelectedRows[0].Cells["ID"].Value;
            Guid selectedCourseID = (Guid)ctrlCourses.SelectedRows[0].Cells["ID"].Value;
            DateTime selectedDateTime = dateTimePicker.Value;
            //if (ConditionsCheched(ViewData, selectedStudentID, selectedProfessorID, selectedCourseID, selectedDateTime)) {
                ViewData.Schedules.Add(new Schedule() {
                    CourseID = selectedProfessorID,
                    StudentID = selectedStudentID,
                    ProfessorID = selectedCourseID,
                    Calendar = selectedDateTime
                });
            LoadDataIntoGrid<Schedule>();
           // }
           // else {
                ///

            //}
        }
        private void SaveData() {
            Storage<University>.SerializeToJSON(ViewData);
        }
        private void LoadData() {
            GetViewData();
            LoadDataIntoGrid<Student>();
            LoadDataIntoGrid<Professor>();
            LoadDataIntoGrid<Course>();
        }

        private void LoadDataIntoGrid<T>() where T : class {
            BindingSource bindingSource = new BindingSource();
            DataGridView dataGridView = new DataGridView();
            if (typeof(T) == typeof(Student)) {
        
                bindingSource.DataSource = ViewData.Students;
                       
                ctrlStudents.DataSource = bindingSource;
                List<string> list = new List<string>();
                ctrlStudentCourses.DataBindings.Add("",bindingSource, "StudentCourses");
                //ctrlStudentCourses.DataSource = bindingSource.ToString();
                //ctrlStudentCourse.DataBindings.Add(new Binding("ListView", bindingSource, "StudentCourses"));
                dataGridView = ctrlStudents;

            }
            else if (typeof(T) == typeof(Professor)) {
                bindingSource.DataSource = ViewData.Professors;
                ctrlProfessors.DataSource = bindingSource;
                //ctrlProfessorCourses.DataBindings.Add("Text", bindingSource, "ProfessorCourses");
                ctrlProfessors.Columns["ProfessorCourses"].Visible = false;
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
                    ID = schedule.ID,
                };
                ctrlSchedules.DataSource = bindingSource;
                dataGridView = ctrlSchedules;
            }

            dataGridView.Columns["ID"].Visible = false;
        }

        private void LoadScheduleData() {
            //if (ViewData == null)
            GetViewData();
            LoadDataIntoGrid<Schedule>();
        }

        public void validate_professorCourse_with_studentCourse() {

            //TODO: ???

        }

        private void addToScheduleToolStripMenuItem_Click(object sender, EventArgs e) {

            // todo : display on a grid??

            // todo: add exception handling?
            

        }

        private void btnAdd_Click(object sender, EventArgs e) {
      
            AddSchedule();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private void GetViewData() {
            ViewData = Storage<University>.DeserializeFromJSON();
        }
        private bool ConditionsCheched(University university,Guid studentID, Guid professorID, Guid courseID, DateTime calendar) {
            //Conditions:
            bool professorAndStudentSameDateAndHour = false;
            bool studentMaxThreeCoursesPerDay = false;
            bool professorMaxFourCoursesPerDay = false;
            bool professorMaxFourtyCoursesPerWeek = false;
            bool professorCanTeachCourse = false;
            bool studentCanLearnCourse = false;
            bool sameProfessorInDifferentCourseSameHour = false;
            bool sameStudentInDifferentCourseSameHour = false;
            bool differentProfessorsForTheSameCourseGivenHour = false;
            bool sameCourseSameHour = false;
            bool sameAllElements = false;
            
            var QueryFindSameStudentProfessorHour = from schedule in university.Schedules
                    where schedule.StudentID == studentID
                        && schedule.ProfessorID == professorID
                        && schedule.Calendar.Hour == calendar.Hour
                    select schedule.ID;
            professorAndStudentSameDateAndHour = (QueryFindSameStudentProfessorHour.Count() == 0);
            if (!professorAndStudentSameDateAndHour) return false;

            var QueryStudentMaxThreeCoursesPerDay = from schedule in university.Schedules
                    where schedule.StudentID == studentID 
                        && schedule.Calendar.Day == calendar.Day
                    select schedule.ID;
            studentMaxThreeCoursesPerDay = (QueryStudentMaxThreeCoursesPerDay.Count() < 3);
            if (!studentMaxThreeCoursesPerDay) return false;

            var QueryProfessorMaxFourCoursesPerDay = from schedule in university.Schedules
                    where schedule.ProfessorID == professorID
                       && schedule.Calendar.Day == calendar.Day
                    select schedule.ID;
            professorMaxFourCoursesPerDay = (QueryProfessorMaxFourCoursesPerDay.Count() < 4);
            if (!professorMaxFourCoursesPerDay) return false;

            //Calendar Settings
            CultureInfo cultureInfo = new CultureInfo("el-GR");
            Calendar calendarInfo = cultureInfo.Calendar;
            CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
            DayOfWeek FirstDOW = cultureInfo.DateTimeFormat.FirstDayOfWeek;

            var QueryProfessorMaxFourtyCoursesPerWeek = from schedule in university.Schedules
                    where schedule.ProfessorID == professorID
                       && calendarInfo.GetWeekOfYear(schedule.Calendar, calendarWeekRule, FirstDOW)
                       == calendarInfo.GetWeekOfYear(calendar, calendarWeekRule, FirstDOW)
                    select schedule.ID;
            professorMaxFourtyCoursesPerWeek = (QueryProfessorMaxFourtyCoursesPerWeek.Count() < 40);
            if (!professorMaxFourtyCoursesPerWeek) return false;


            var courseCategory = (from course in university.Courses
                    where course.ID == courseID
                    select course.Category).First();
            var QueryProfessorCanTeachCourse = from professor in university.Professors
                     where professor.ID == professorID
                        && professor.ProfessorCourses.Contains(courseCategory)
                    select professor.ID;
            professorCanTeachCourse = (QueryProfessorCanTeachCourse.Count() > 0);
            if (!professorCanTeachCourse) return false;

            var QueryStudentCanLearnCourse = from student in university.Students
                    where student.ID == studentID
                        && student.StudentCourses.Contains(courseCategory)
                        select student.ID;
            studentCanLearnCourse = (QueryStudentCanLearnCourse.Count() > 0);
            if (!studentCanLearnCourse) return false;

            //TODO: Rest Queries


            return true;
        }

        
    }

}


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UniversityApp.Model;
using UniversityApp.Storage;
using System.Globalization;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1.WUI {

    public partial class MainForm : Form {

        private University ViewData = new University();

        public MainForm() {
            InitializeComponent();
        }

        #region Events
        private void MainForm_Load(object sender, EventArgs e) {
            LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e) {
            AddSchedule();
        }
        private void btnLoad_Click(object sender, EventArgs e) {
            LoadScheduleData();
        }
        private void btnSave_Click(object sender, EventArgs e) {
            SaveData();
        }

        private void ctrlStudents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            ctrlStudents.ClearSelection();
        }

        private void ctrlStudents_SelectionChanged(object sender, EventArgs e) {
            ShowStudentCoursesGrid();
        }
        private void ctrlProfessors_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            ctrlProfessors.ClearSelection();
        }

        private void ctrlProfessors_SelectionChanged(object sender, EventArgs e) {
            ShowProfessorCoursesGrid();
        }

        private void ctrlCourses_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            ctrlCourses.ClearSelection();
        }

        private void ctrlSchedules_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            ctrlSchedules.ClearSelection();
        }

        private void AdjustGridView(DataGridView dataGridView) {

            if (dataGridView == ctrlStudentCourses) {
                dataGridView.Columns["Courses"].HeaderText = "Student Courses";
                return;
            }
            else if (dataGridView == ctrlProfessorCourses) {
                dataGridView.Columns["Courses"].HeaderText = "Professor Courses";
                return;
            }

            dataGridView.Columns["ID"].Visible = false;

            if (dataGridView == ctrlStudents || dataGridView == ctrlProfessors) {
                dataGridView.Columns["Age"].DisplayIndex = 3;
                dataGridView.Columns["PersonCourses"].Visible = false;
            }

            if (dataGridView == ctrlCourses || dataGridView == ctrlSchedules) {
                dataGridView.Columns["Subject"].DisplayIndex = 1;
                dataGridView.Columns["Category"].DisplayIndex = 2;

            }

            if (dataGridView == ctrlStudents) {
                dataGridView.Columns["RegistrationNumber"].DisplayIndex = 0;
                dataGridView.Columns["RegistrationNumber"].HeaderText = "Registration Number";
                dataGridView.Columns["Name"].DisplayIndex = 1;
                dataGridView.Columns["Surname"].DisplayIndex = 2;

            }
            else if (dataGridView == ctrlProfessors) {
                dataGridView.Columns["Name"].DisplayIndex = 0;
                dataGridView.Columns["Surname"].DisplayIndex = 1;
                dataGridView.Columns["Rank"].DisplayIndex = 2;

            }
            else if (dataGridView == ctrlCourses) {
                dataGridView.Columns["Code"].DisplayIndex = 0;
                dataGridView.Columns["Hours"].DisplayIndex = 3;
            }
            else {
                dataGridView.Columns["Date"].DisplayIndex = 0;
                dataGridView.Columns["ProfessorName"].DisplayIndex = 3;
                dataGridView.Columns["ProfessorName"].HeaderText = "Professor Name";
                dataGridView.Columns["ProfessorSurname"].DisplayIndex = 4;
                dataGridView.Columns["ProfessorSurname"].HeaderText = "Professor Surname";
                dataGridView.Columns["StudentName"].DisplayIndex = 5;
                dataGridView.Columns["StudentName"].HeaderText = "Student Name";
                dataGridView.Columns["StudentSurname"].DisplayIndex = 6;
                dataGridView.Columns["StudentSurname"].HeaderText = "Student Surname";
            }

        }
        private void btnRemove_Click(object sender, EventArgs e) {
            RemoveSelectedRecord();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            FormClosingEventHandler(e);
        }

        #endregion

        #region Methods
        private void GetViewData() {
            ViewData = Storage<University>.DeserializeFromJSON();
        }

        private void LoadData() {
            try {
                GetViewData();
            }
            catch (Exception) {
                MessageBox.Show(Resources.ErrorDataReading, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            LoadDataIntoGrid<Student>();
            LoadDataIntoGrid<Professor>();
            LoadDataIntoGrid<Course>();
        }
        private void LoadScheduleData() {
            GetViewData();
            if (ViewData.Schedules.Count() > 0)
                LoadDataIntoGrid<Schedule>();
            else
                MessageBox.Show(Resources.WarningNoScheduleDataToLoad, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void LoadDataIntoGrid<T>() where T : class {
            BindingSource bindingSource = new BindingSource();

            if (typeof(T) == typeof(Student)) {
                bindingSource.DataSource = ViewData.Students;
                ctrlStudents.DataSource = bindingSource;
                AdjustGridView(ctrlStudents);
            }
            else if (typeof(T) == typeof(Professor)) {
                bindingSource.DataSource = ViewData.Professors;
                ctrlProfessors.DataSource = bindingSource;
                AdjustGridView(ctrlProfessors);
            }
            else if (typeof(T) == typeof(Course)) {
                bindingSource.DataSource = ViewData.Courses;
                ctrlCourses.DataSource = bindingSource;
                AdjustGridView(ctrlCourses);

            }
            else if (typeof(T) == typeof(Schedule)) {
                bindingSource.DataSource = from schedule in ViewData.Schedules
                                           join student in ViewData.Students on schedule.StudentID equals student.ID
                                           join professor in ViewData.Professors on schedule.ProfessorID equals professor.ID
                                           join course in ViewData.Courses on schedule.CourseID equals course.ID
                                           orderby schedule.Calendar descending
                                           select new {
                                               Date = schedule.Calendar,
                                               StudentName = student.Name,
                                               StudentSurname = student.Surname,
                                               ProfessorName = professor.Name,
                                               ProfessorSurname = professor.Surname,
                                               Subject = course.Subject,
                                               Category = course.Category,
                                               ID = schedule.ID
                                           };

                ctrlSchedules.DataSource = bindingSource;
                AdjustGridView(ctrlSchedules);
            }

        }

        private void AddSchedule() {
            Guid selectedProfessorID = Guid.NewGuid();
            Guid selectedStudentID = Guid.NewGuid();
            Guid selectedCourseID = Guid.NewGuid();
            DateTime selectedDateTime = dateTimePicker.Value;
            bool resultOfValidation = ValidateSelections(ref selectedProfessorID, ref selectedStudentID, ref selectedCourseID);

            if (resultOfValidation) {
                if (ConditionsCheched(ViewData, selectedStudentID, selectedProfessorID, selectedCourseID, selectedDateTime)) {
                    ViewData.Schedules.Add(new Schedule() {
                        CourseID = selectedCourseID,
                        StudentID = selectedStudentID,
                        ProfessorID = selectedProfessorID,
                        Calendar = selectedDateTime
                    });

                    LoadDataIntoGrid<Schedule>();
                }

            }

        }

        private bool ValidateSelections(ref Guid selectedProfessorID, ref Guid selectedStudentID, ref Guid selectedCourseID) {
            try {
                selectedProfessorID = (Guid)ctrlProfessors.SelectedRows[0].Cells["ID"].Value;
            }
            catch (Exception) {
                MessageBox.Show(Resources.ErrorNoProfessorSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try {
                selectedStudentID = (Guid)ctrlStudents.SelectedRows[0].Cells["ID"].Value;
            }
            catch (Exception) {
                MessageBox.Show(Resources.ErrorNoStudentSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try {
                selectedCourseID = (Guid)ctrlCourses.SelectedRows[0].Cells["ID"].Value;
            }
            catch (Exception) {
                MessageBox.Show(Resources.ErrorNoCourseSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ConditionsCheched(University university, Guid studentID, Guid professorID, Guid courseID, DateTime calendar) {

            if (!CheckSameAllElements(university, studentID, professorID, courseID, calendar)) {
                MessageBox.Show(Resources.ErrorDuplicateRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!CheckForProfessorAndStudentSameDateAndHour(university, studentID, professorID, calendar)) {
                MessageBox.Show(Resources.ErrorSameStudentAndProfessor, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!CheckStudentMaxThreeCoursesPerDay(university, studentID, calendar)) {
                MessageBox.Show(Resources.ErrorStudentMaxThreeCoursesPerDay, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!CheckProfessorMaxFourCoursesPerDay(university, professorID, calendar)) {
                MessageBox.Show(Resources.ErrorProfessorMaxFourCoursesPerDay, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!CheckProfessorMaxFourtyCoursesPerWeek(university, professorID, calendar)) {
                MessageBox.Show(Resources.ErrorProfessorMaxFourtyCoursesPerWeek, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CheckSameProfessorInDifferentCourseSameHour(university, professorID, courseID, calendar)) {
                MessageBox.Show(Resources.ErrorProfessorTeachesDifferentSubjectGivenHour, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CheckSameStudentInDifferentCourseSameHour(university, studentID, courseID, calendar)) {
                MessageBox.Show(Resources.ErrorStudentLearnsDifferentSubjectGivenHour, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!CheckProfessorCanTeachCourse(university, courseID, professorID)) {
                MessageBox.Show(Resources.ErrorProfessorCannotTeachCourse, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!CheckStudentCanLearnCourse(university, courseID, studentID)) {
                MessageBox.Show(Resources.ErrorStudentCannotLearnCourse, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MessageBox.Show(Resources.ScheduleUpdatedSuccessfully, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return true;
        }

        private bool CheckForProfessorAndStudentSameDateAndHour(University university, Guid studentID, Guid professorID, DateTime calendar) {

            var QueryProfessorAndStudentSameDateAndHour = from schedule in university.Schedules
                                                          where schedule.StudentID == studentID
                                                              && schedule.ProfessorID == professorID
                                                              && schedule.Calendar == calendar
                                                          select schedule.ID;

            return QueryProfessorAndStudentSameDateAndHour.Count() == 0;
        }

        private bool CheckStudentMaxThreeCoursesPerDay(University university, Guid studentID, DateTime calendar) {
            
            var QueryStudentMaxThreeCoursesPerDay = from schedule in university.Schedules
                                                    where schedule.StudentID == studentID
                                                        && schedule.Calendar.Day == calendar.Day
                                                    select schedule.ID;

            return QueryStudentMaxThreeCoursesPerDay.Count() < 3;
        }

        private bool CheckProfessorMaxFourCoursesPerDay(University university, Guid professorID, DateTime calendar) {
            
            var QueryProfessorMaxFourCoursesPerDay = from schedule in university.Schedules
                                                     where schedule.ProfessorID == professorID
                                                        && schedule.Calendar.Day == calendar.Day
                                                     select schedule.ID;

            return QueryProfessorMaxFourCoursesPerDay.Count() < 4;
        }

        private bool CheckSameProfessorInDifferentCourseSameHour(University university, Guid professorID, Guid courseID, DateTime calendar) {
            
            var QuerySameProfessorInDifferentCourseSameHour = from schedule in university.Schedules
                                                              where schedule.ProfessorID == professorID
                                                                 && schedule.Calendar == calendar
                                                                 && schedule.CourseID != courseID
                                                              select schedule.ID;

            return QuerySameProfessorInDifferentCourseSameHour.Count() == 0;
        }

        private bool CheckSameStudentInDifferentCourseSameHour(University university, Guid studentID, Guid courseID, DateTime calendar) {
            
            var QuerySameStudentInDifferentCourseSameHour = from schedule in university.Schedules
                                                            where schedule.StudentID == studentID
                                                               && schedule.Calendar == calendar
                                                               && schedule.CourseID != courseID
                                                            select schedule.ID;

            return QuerySameStudentInDifferentCourseSameHour.Count() == 0;
        }

        private bool CheckProfessorMaxFourtyCoursesPerWeek(University university, Guid professorID, DateTime calendar) {
            CultureInfo cultureInfo = new CultureInfo("el-GR");
            Calendar calendarInfo = cultureInfo.Calendar;
            CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
            DayOfWeek FirstDOW = cultureInfo.DateTimeFormat.FirstDayOfWeek;

            var QueryProfessorMaxFourtyCoursesPerWeek = from schedule in university.Schedules
                                                        where schedule.ProfessorID == professorID
                                                           && calendarInfo.GetWeekOfYear(schedule.Calendar, calendarWeekRule, FirstDOW)
                                                           == calendarInfo.GetWeekOfYear(calendar, calendarWeekRule, FirstDOW)
                                                        select schedule.ID;

            return QueryProfessorMaxFourtyCoursesPerWeek.Count() < 40;
        }


        private bool CheckProfessorCanTeachCourse(University university, Guid courseID, Guid professorID) {

            CoursesCategoryEnum courseCategory = GetCourseCategory(university, courseID);
            var QueryProfessorCanTeachCourse = from professor in university.Professors
                                               where professor.ID == professorID
                                                  && professor.PersonCourses.Contains(courseCategory)
                                               select professor.ID;
            return QueryProfessorCanTeachCourse.Count() > 0;
        }

        private bool CheckStudentCanLearnCourse(University university, Guid courseID, Guid studentID) {

            CoursesCategoryEnum courseCategory = GetCourseCategory(university, courseID);
            var QueryStudentCanLearnCourse = from student in university.Students
                                             where student.ID == studentID
                                                 && student.PersonCourses.Contains(courseCategory)
                                             select student.ID;

            return QueryStudentCanLearnCourse.Count() > 0;
        }

        private bool CheckSameAllElements(University university, Guid studentID, Guid professorID, Guid courseID, DateTime calendar) {

            var QuerySameAllElements = from schedule in university.Schedules
                                       where schedule.StudentID == studentID
                                       && schedule.ProfessorID == professorID
                                       && schedule.CourseID == courseID
                                       && schedule.Calendar == calendar
                                       select schedule.ID;

            return QuerySameAllElements.Count() == 0;
        }


        private CoursesCategoryEnum GetCourseCategory(University university, Guid courseID) {
            CoursesCategoryEnum courseCategory = (CoursesCategoryEnum)(from course in university.Courses
                                                                       where course.ID == courseID
                                                                       select course.Category).First();
            return courseCategory;
        }

        private void SaveData() {
            try {
                Storage<University>.SerializeToJSON(ViewData);
            }
            catch (Exception) {
                MessageBox.Show(Resources.ErrorDataWriting, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ShowStudentCoursesGrid() {
            if (ctrlStudents.Focused) {
                ctrlStudentCourses.DataSource = PopulateCoursesGrid(ctrlStudents);
                AdjustGridView(ctrlStudentCourses);
            }
        }

        private void ShowProfessorCoursesGrid() {
            if (ctrlProfessors.Focused) {
                ctrlProfessorCourses.DataSource = PopulateCoursesGrid(ctrlProfessors);
                AdjustGridView(ctrlProfessorCourses);
            }
        }

        private BindingSource PopulateCoursesGrid(DataGridView dataGridView) {
            BindingSource gridBindingSource = new BindingSource();

            List<CoursesCategoryEnum> selectedCourses = dataGridView.SelectedRows[0].Cells["PersonCourses"].Value as List<CoursesCategoryEnum>;
            ICollection<string> coursesList = new List<string>();

            if (selectedCourses == null) return null;
            else {
                for (int i = 0; i < selectedCourses.Count(); i++) {
                    coursesList.Add(selectedCourses.GetType().GetProperty("Item").GetValue(selectedCourses, new Object[] { i }).ToString());
                }
                gridBindingSource.DataSource = coursesList.Select(x => new { Courses = x }).ToList();

                return gridBindingSource;
            }

        }

        private void RemoveSelectedRecord() {
            try {
                Guid selectedScheduleID = (Guid)ctrlSchedules.SelectedRows[0].Cells["ID"].Value;
                ViewData.Schedules.Remove(ViewData.Schedules.First(x => x.ID == selectedScheduleID));
                if (ViewData.Schedules.Count() > 0) {
                    LoadDataIntoGrid<Schedule>();
                }
                else
                    ctrlSchedules.DataSource = null;
            }
            catch (Exception) {
                MessageBox.Show(Resources.ErrorNoRecordSelected, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormClosingEventHandler(FormClosingEventArgs e) {
            DialogResult result = MessageBox.Show(Resources.SaveChanges, this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result) {
                case DialogResult.Yes:
                    SaveData();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }

        }

        #endregion
    }

}
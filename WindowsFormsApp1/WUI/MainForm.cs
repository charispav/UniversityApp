using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using UniversityApp.Model;

namespace WindowsFormsApp1.WUI {

    public partial class MainForm : Form {

        private University ViewData = new University();

        public MainForm() {
            InitializeComponent();
        }

        #region old code
        private void DataForm_Load(object sender, EventArgs e) {

            // todo : load data on enter!
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e) {

            JavaScriptSerializer r = new JavaScriptSerializer();

            ViewData = r.Deserialize<University>(File.ReadAllText("Data.json"));

            foreach (Student a in ViewData.Students) {
                list1.Items.Add(a.Name + " " + a.Surname);
            }

            for (int i = 0; i < ViewData.Courses.Count - 1; i++) {

                listBox1.Items.Add(ViewData.Courses[i].Code + "--" + ViewData.Courses[i].Subject);
            }


            foreach (Professor k in ViewData.Professors) {
                list3.Items.Add(string.Format("{0}  {1}", k.Name, k.Surname));
            }
        }

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e) {
            JavaScriptSerializer save_Serializer = new JavaScriptSerializer();

            File.WriteAllText("Data.json", save_Serializer.Serialize(ViewData));
        }
        #endregion

        #region new code
        private void DataForm1_Load(object sender, EventArgs e) {

            // todo : load data on enter!
        }

        private void initializeDedomenaToolStripMenuItem_Click(object sender, EventArgs e) {

            ViewData.run_once();

            foreach (Student a in ViewData.Students) {
                list1.Items.Add(a.Name + " " + a.Surname);
            }

            foreach (Course bb in ViewData.Courses) {
                listBox1.Items.Add(bb.Code + "--" + bb.Subject);
            }


            foreach (Professor cc1 in ViewData.Professors) {

                list3.Items.Add(string.Format("{0}  {1}", cc1.Name, cc1.Surname));
            }

            //should run only once!
            button11.Hide();
        }

        private void button9_Click(object sender, EventArgs e) {

            JavaScriptSerializer GG = new JavaScriptSerializer();

            ViewData = GG.Deserialize<University>(File.ReadAllText("Data.json"));

            foreach (Student a in ViewData.Students) {
                list1.Items.Add(a.Name + " " + a.Surname);
            }

            for (int i = 0; i < ViewData.Courses.Count - 1; i++) {

                listBox1.Items.Add(ViewData.Courses[i].Code + "--" + ViewData.Courses[i].Subject);
            }

            // we do a loop
            foreach (Professor cc1 in ViewData.Professors) {
                // we add to the list
                list3.Items.Add(string.Format("{0}  {1}", cc1.Name, cc1.Surname));
            }

        }

        private void button10_Click(object sender, EventArgs e) {
            JavaScriptSerializer ff = new JavaScriptSerializer();

            File.WriteAllText("Data.json", ff.Serialize(ViewData));
        }

        private void ctrlExit_Click(object sender, EventArgs e) {

            try {

                // TODO: 1. CANNOT ADD SAME STUDENT + PROFESSOR IN SAME DATE & HOUR

                // TODO: 2. EACH STUDENT CANNOT HAVE MORE THAN 3 COURSES PER DAY!

                // TODO: 3. A PROFESSOR CANNOT TEACH MORE THAN 4 COURSES PER DAY AND 40 COURSES PER WEEK

                ViewData.Schedules.Add(new Schedule() { Course = listBox1.SelectedItem.ToString(), Student = list1.SelectedItem.ToString(), Professor = list3.SelectedItem.ToString(), Calendar = dateTimePicker2.Value });

                ctrlSchedule.Items.Clear();
                foreach (var AA in ViewData.Schedules) {

                    ctrlSchedule.Items.Add(AA.Calendar + " | " + AA.Course + " | " + AA.Student + " | " + AA.Professor);

                }
            }
            catch { 
            
            }
            finally {
                MessageBox.Show("all ok!");

            }
        }

        public void validate_professorCourse_with_studentCourse() { 
        
            //TODO: ???

        }

        #endregion

        private void button11_Click(object sender, EventArgs e) {

            

            ViewData.run_once();

            foreach (Student a in ViewData.Students) {
                list1.Items.Add(a.Name + " " + a.Surname);
            }

            foreach (Course bb in ViewData.Courses) {
                listBox1.Items.Add(bb.Code + "--" + bb.Subject);
            }


            foreach (Professor cc1 in ViewData.Professors) {

                list3.Items.Add(string.Format("{0}  {1}", cc1.Name, cc1.Surname));
            }

            //should run only once!
            button11.Hide();
        }

        private void addToScheduleToolStripMenuItem_Click(object sender, EventArgs e) {

            // todo : display on a grid??

            // todo: add exception handling?
                ViewData.Schedules.Add(new Schedule() { 
                    Course = listBox1.SelectedItem.ToString(), Student = list1.SelectedItem.ToString()
                        , Professor = list3.SelectedItem.ToString(), Calendar = dateTimePicker2.Value });

                ctrlSchedule.Items.Clear();
                foreach (var AA in ViewData.Schedules) {

                    ctrlSchedule.Items.Add(
                        AA.Calendar + " " + 
                        AA.Course + " " + 
                        AA.Student + " " + 
                        AA.Professor);

                }
        
        }

    }
}


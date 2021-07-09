using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Model {

    public class University  {

        public List<Student> Students { get; set; }
        public List<Professor> Professors { get; set; }
        public List<Course> Courses { get; set; }
        public List<Schedule> Schedules { get; set; }

        public University() {
            Students = new List<Student>();
            Professors = new List<Professor>();
            Courses = new List<Course>();
            Schedules = new List<Schedule>();
        }

        public void run_once() {


            // TODO: MUST IMPLEMENT ENUMERATION FOR CATEGORY ?

            Courses.Add( new Course() {
                ID = Guid.NewGuid(), 
                Code = "01",
                Subject = "Quantum Physics",
                Category = CoursesCategoryEnum.Physics, 
                Hours = 100
            });

            Courses.Add(new Course() {
                ID = Guid.NewGuid(),
                Code = "02",
                Subject = "Electo-Dynamics",
                Category = CoursesCategoryEnum.Physics, 
                Hours = 50
            });

            Courses.Add(new Course() {
                ID = Guid.NewGuid(),
                Code = "03",
                Subject = "Basic Chemistry",
                Category = CoursesCategoryEnum.Chemistry, 
                Hours = 50
            });

            Courses.Add(new Course() {
                ID = Guid.NewGuid(),
                Code = "04",
                Subject = "Financial II",
                Category = CoursesCategoryEnum.Financial, 
                Hours = 50
            });

            Courses.Add(new Course() {
                ID = Guid.NewGuid(),
                Code = "05",
                Subject = "Mathematics I",
                Category = CoursesCategoryEnum.Mathematics, 
                Hours = 50
            });

            Students.Add(new Student() {
                ID = Guid.NewGuid(),
                Name = "Fotis",
                Surname = "Chrysoulas",
                RegistrationNumber = "1234",
                CoursesThatCanBeLearned = new List<CoursesCategoryEnum>() { CoursesCategoryEnum.Chemistry, CoursesCategoryEnum.Financial}
            });


            Students.Add(new Student() {
                ID = Guid.NewGuid(),
                Name = "Dimitris",
                Surname = "Raptodimos",
                RegistrationNumber = "1235",
                CoursesThatCanBeLearned = new List<CoursesCategoryEnum>() { CoursesCategoryEnum.Physics, CoursesCategoryEnum.Financial } 
            });

            Professors.Add(new Professor() {
                Name = "Maria",
                Surname = "Papadopoulou",
                Rank = "1"
            });


        }

        
    }

}


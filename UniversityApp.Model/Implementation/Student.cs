using System;
using System.Collections.Generic;
using UniversityApp.Model.Base;

namespace UniversityApp.Model {
    public class Student : Person {
       
        public string RegistrationNumber { get; set; }
        public int Age { get; set; }
        public List<CoursesCategoryEnum> StudentCourses { get; set; }

        public Student() : base() {

        }

    }

}


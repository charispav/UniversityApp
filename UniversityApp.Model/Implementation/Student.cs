using System;
using System.Collections.Generic;
using System.ComponentModel;
using UniversityApp.Model.Base;

namespace UniversityApp.Model {
    public class Student : Person {
       
        public string RegistrationNumber { get; set; }
        public int Age { get; set; }
        public ICollection<CoursesCategoryEnum> PersonCourses { get; set; }

        public Student() : base() {

        }

    }

}


using System;
using System.Collections.Generic;

namespace UniversityApp.Model {
    public class Student {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public int Age { get; set; }
        public List<CoursesCategoryEnum> CoursesThatCanBeLearned { get; set; }
    }

}


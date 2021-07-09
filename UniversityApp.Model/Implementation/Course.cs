using System;

namespace UniversityApp.Model {
    public class Course  {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public int Hours { get; set; }
        public CoursesCategoryEnum Category { get; set; }

        public Course() {
                
        }

    }

}


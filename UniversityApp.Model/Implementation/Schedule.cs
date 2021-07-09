using System;
using UniversityApp.Model.Base;

namespace UniversityApp.Model {
    public class Schedule : Entity {

        public Guid StudentID { get; set; }
        public Guid ProfessorID { get; set; }
        public Guid CourseID { get; set; }
        public DateTime Calendar { get; set; }

        public Schedule() : base() {
                
        }
    }

}


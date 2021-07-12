using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Model.Base;

namespace UniversityApp.Model {
    public class Professor : Person {
        
        public short Age { get; set; }
        public string Rank { get; set; }
        public override ICollection<CoursesCategoryEnum> PersonCourses { get; set; }

        public Professor() : base() {
           
        }
    }
}

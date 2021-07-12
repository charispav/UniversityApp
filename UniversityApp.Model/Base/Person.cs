using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Model.Base {
    public abstract class Person : Entity {
        public string Name { get; set; }
        public string Surname { get; set; }
        public abstract ICollection<CoursesCategoryEnum> PersonCourses { get; set; }
        public Person(): base() {

        }

    }
}

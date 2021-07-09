using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Model {
    public class Professor {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public short Age { get; set; }
        public string Rank { get; set; }
        public List<CoursesCategoryEnum> CoursesThatCanBeTeached { get; set; }

        public Professor() {
            ID = Guid.NewGuid();
        }
    }
}

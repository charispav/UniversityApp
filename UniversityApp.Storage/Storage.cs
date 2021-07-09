using System;
using System.IO;
using System.Web.Script.Serialization;
using UniversityApp.Model;

namespace UniversityApp.Storage {
    public class Storage {
        /*
        private void SerializeToJSON() {

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

        private void DeserializeFromJSON(object sender, EventArgs e) {
            JavaScriptSerializer save_Serializer = new JavaScriptSerializer();

            File.WriteAllText("Data.json", save_Serializer.Serialize(ViewData));
        }
        */
    }

}


using System;
using System.IO;
using System.Web.Script.Serialization;
using UniversityApp.Model;
using System.Data;
namespace UniversityApp.Storage {
    public static class Storage<T> where T : class {
        
        public static void SerializeToJSON(T ViewData) {

            JavaScriptSerializer saveSerializer = Serializer();
            File.WriteAllText($"{typeof(T).Name}Data.json", saveSerializer.Serialize(ViewData));
        }

        public static T DeserializeFromJSON() {

            JavaScriptSerializer loadSerializer = Serializer();

            return loadSerializer.Deserialize<T>(File.ReadAllText($"{typeof(T).Name}Data.json"));
        }

        private static JavaScriptSerializer Serializer() {

            return new JavaScriptSerializer();
        }
       
    }

}

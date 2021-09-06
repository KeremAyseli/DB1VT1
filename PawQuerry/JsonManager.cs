using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;

namespace PawQuerry
{
    
    class JsonManager<T>
    {
        
        public Hashtable readJson(string path)
        {
            StreamReader sr = new StreamReader("deneme1.json");
            Hashtable jsonWithKeyAndValue = new Hashtable();
            var keysAndValues = JsonSerializer.Deserialize<Hashtable>(sr.ReadToEnd());
            sr.Close();
            foreach (string key in keysAndValues.Keys)
            {
                jsonWithKeyAndValue.Add(key, keysAndValues[key]);
            }
            
            return jsonWithKeyAndValue;
        }
        public void WriteJson(string path, T data)
        {
            new StreamWriter(path).WriteLine(JsonSerializer.Serialize(data));
        }   
    }
}

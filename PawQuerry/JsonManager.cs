using System.Text;
using System.Text.Json;
using System.Collections;
using System.IO;


namespace PawQuerry
{
    
    class JsonManager
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
        public void WriteJson(string path, object data)
        {
            File.WriteAllText(path,JsonSerializer.Serialize(data), Encoding.UTF8);
        }   
    }
}

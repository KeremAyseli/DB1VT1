using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace PawQuerry
{
    class Querry<T> : ClassParser
    {
        private System.Reflection.MemberInfo[] classPropName, classVarriables;
        private JsonManager<T> jm = new JsonManager<T>();
        public Querry()
        {
            classPropName = getProperties();
            classVarriables = getVarriable();
            for (int i = 0; i < classVarriables.Length; i++)
            {
                Console.WriteLine("Varriables name:{0}", classVarriables[i]);
            }
        }
        public void update(string updateColumnName, string newData)
        {
            
            Hashtable data = jm.readJson("deneme");
            try
            {
                for (int i = 0; i < classPropName.Length; i++)
                {
                    if (classPropName[i].Name == updateColumnName)
                    {
                        data[updateColumnName] = newData;
                        File.WriteAllText("deneme.json",JsonSerializer.Serialize(data),Encoding.UTF8);
                        break;
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

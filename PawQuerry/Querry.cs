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
        private JsonManager jm = new JsonManager();
        Condition conditions = new Condition();
        public Querry()
        {
            classPropName = getProperties();
            classVarriables = getVarriable();
            for (int i = 0; i < classVarriables.Length; i++)
            {
                Console.WriteLine("Varriables name:{0}", classVarriables[i]);
            }
        }
        public void Update(string updateColumnName, string newData)
        {
            Hashtable data = jm.readJson("deneme");
            try
            {
                for (int i = 0; i < classPropName.Length; i++)
                {
                    if (classPropName[i].Name == updateColumnName)
                    {
                        data[updateColumnName] = newData;
                        jm.WriteJson("deneme.json", data.ToString());
                        break;
                    }
                }
            }
            catch (WrongSyntaxExpection ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string Select(string columnName,string conditionColumn,string conditionvalue, string condition)
        {
            Hashtable data = jm.readJson("deneme");

            try
            {
                for (int i = 0; i < classPropName.Length; i++)
                {
                    if (classPropName[i].Name == columnName)
                    {
                        Console.WriteLine(conditions.conditions(data[conditionColumn].ToString(), conditionvalue, condition));
                        if(conditions.conditions(data[conditionColumn].ToString(), conditionvalue,condition))
                           return data[classPropName[i].Name].ToString();
                    }
                }
            }
            catch (WrongSyntaxExpection ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


    }
}

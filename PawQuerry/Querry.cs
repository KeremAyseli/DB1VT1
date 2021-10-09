using System;
using System.Collections;
using static System.Int32;

namespace PawQuerry
{
    class Querry<T> : ClassParser
    {
        private System.Reflection.MemberInfo[] classPropName, classVarriables;
        private JsonManager jm = new JsonManager();

        public string conditionsSelectedColumnValue { get; set; }

        public Querry()
        {
            classPropName = getProperties();
            classVarriables = getVarriable();
            for (int i = 0; i < classVarriables.Length; i++)
            {
                Console.WriteLine("Varriables name:{0}", classVarriables[i]);
            }
        }

        public void Update(string updateColumnName, object newData)
        {
            Hashtable data = jm.readJson("deneme1");
            try
            {
                for (int i = 0; i < classPropName.Length; i++)
                {
                    if (classPropName[i].Name == updateColumnName)
                    {
                        data[updateColumnName] = newData;
                        jm.WriteJson("deneme1.json", data);
                        break;
                    }
                }
            }
            catch (WrongSyntaxExpection ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public string Select(string columnName, string conditionColumn, Func<bool> condition)
        {
            Hashtable data = jm.readJson("deneme");
            conditionsSelectedColumnValue = data[conditionColumn].ToString();
            if (condition())
                return data[GetColumn(columnName)].ToString();
            return null;
        }

        public int  Delete(string columnName, string conditionColunm, Func<bool> condition)
        {
            Hashtable data = jm.readJson("deneme");
            try
            {
                conditionsSelectedColumnValue = data[conditionColunm].ToString();
                if (condition())
                {
                    if (TryParse(data[columnName].ToString(),out int num))
                    {data[columnName] = 0;Console.WriteLine("int");}
                    else
                    {data[columnName] = null;Console.WriteLine("İnt değil");}
                }
                jm.WriteJson("deneme.json",data);
                return 1;
            }
            catch (WrongSyntaxExpection e)
            {
                Console.WriteLine(e.Message);
            }

            return 0;
        }

        public string GetColumn(string ColumnName)
        {
            try
            {
                for (int i = 0; i < classPropName.Length; i++)
                {
                    if (classPropName[i].Name == ColumnName)
                    {
                        return classPropName[i].Name;
                    }
                }
            }
            catch (WrongSyntaxExpection e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}


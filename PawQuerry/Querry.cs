using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PawQuerry
{
    class Querry<T>:ClassParser
    {
        private System.Reflection.MemberInfo[] classPropName,classVarriables;
       public Querry()
        {
            classPropName = getProperties();
            classVarriables = getVarriable();
            for(int i = 0; i < classVarriables.Length; i++)
            {
                Console.WriteLine("Varriables name:{0}", classVarriables[i]);
            }
        }
        public void update(string updateColumnName,string newData,T recordDataType)
        {
            for(int i = 0; i < classPropName.Length; i++)
            {
                if (classPropName[i].Name == updateColumnName)
                {
                    Console.WriteLine("column name to update:{0}", classPropName[i].Name);
                }
            }
        }

    }
}

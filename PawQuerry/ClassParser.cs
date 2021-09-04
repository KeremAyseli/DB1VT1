using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PawQuerry
{
    abstract class ClassParser
    {
        public PropertyInfo[] getProperties()
        {
            return this.GetType().GetProperties();
        }
        public MemberInfo[] getVarriable()
        {
            return this.GetType().GetFields();
        }
    }
}

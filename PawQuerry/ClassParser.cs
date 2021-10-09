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

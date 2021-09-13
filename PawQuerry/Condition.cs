using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawQuerry
{
    class Condition
    {
        public bool conditions(string firstArguments, string secondArguments, string conditions)
        {
            switch (conditions)
            {
                case "==":
                    return firstArguments.Equals(secondArguments);
                case "!=":
                    return firstArguments != secondArguments;
            }
            return false;
        }
        public bool conditions(int firstArguments, int secondArguments, string conditions)
        {
            switch (conditions)
            {
                case "==":
                    return firstArguments == secondArguments;
                case "!=":
                    return firstArguments != secondArguments;
                case ">":
                    return firstArguments > secondArguments;
                case ">=":
                    return firstArguments >= secondArguments;
                case "<":
                    return firstArguments < secondArguments;
                case "<=":
                    return firstArguments <= secondArguments;
            }
            return false;
        }


    }
}

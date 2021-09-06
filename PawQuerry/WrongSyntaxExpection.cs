using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawQuerry
{
    class WrongSyntaxExpection:Exception
    {
        public WrongSyntaxExpection(string message) : base(message) { }

    }
}

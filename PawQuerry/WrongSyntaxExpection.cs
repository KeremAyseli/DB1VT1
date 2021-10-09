using System;

namespace PawQuerry
{
    class WrongSyntaxExpection:Exception
    {
        public WrongSyntaxExpection(string message) : base(message) { }

    }
}

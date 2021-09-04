using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawQuerry
{
    class example:Querry<example>
    {
        public int id;
        public string isim { get; set; }
        public string soyisim { get; set; }

    }
}

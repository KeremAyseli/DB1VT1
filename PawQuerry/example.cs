using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawQuerry
{
    class example:Querry<example>
    {
        public example(int id,string isim,string soyisim)
        {
            this.id = id;
            this.isim = isim;
            this.soyisim = soyisim;
        }
        public int id { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string Numara { get; set; }
        //Test
        //Tree
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DB1VT1
{
    [Serializable]
    class Kişiler
    {
        [ID]
        public int id { get;set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public int yas { get; set; }

    }
}

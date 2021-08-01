using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DB1VT1
{
    interface IDataRead<T>
    {
        List<T> jsonOkuListİle(string aranacakVeri);
        string[] klasörOku(string yol);
        public T[] jsonOku(string aranacakVeri);       
    }
    interface IDataWrite<T>
    {
        void dataWrite(string Tablo, T Veri, string AnahtarKelime);
    }
}

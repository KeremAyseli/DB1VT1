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
        public List<T> ReadJsonWithList(string tableName, string aranacakVeri);
        public string[] ReadFolder(string tableName);
        public T[] ReadData(string tableName, string aranacakVeri);
    }
    interface IDataWrite<T>
    {
        void dataWrite(string Tablo, T Veri, string AnahtarKelime);
    }
}

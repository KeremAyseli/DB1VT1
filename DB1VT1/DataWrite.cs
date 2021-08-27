using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace DB1VT1
{
    class DataWrite<T>
    {
        WordHandler wordHandler = new WordHandler();
        public void dataWrite(string tableName, T Veri, string AnahtarKelime)
        {
            StreamWriter yazma = new StreamWriter(AdressBuilder.adressGenerator(tableName,AnahtarKelime));

            string jsonDosya = JsonSerializer.Serialize<T>(Veri);
            
            yazma.WriteLine(jsonDosya);
            yazma.Close();
        }
    }
}

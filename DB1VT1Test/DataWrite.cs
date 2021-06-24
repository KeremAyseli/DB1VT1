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
        public DataWrite(string Tablo, T Veri, string AnahtarKelime)
        {
            

            StreamWriter yazma = new StreamWriter(dosyaAdresi + @"\" + wordHandler.kelimeHarfSayısı(AnahtarKelime).ToString() + "Harf" + @"\" + wordHandler.YerBulmaCarpma(AnahtarKelime).ToString() + @"\" + dosyaİsimOlusturma(Tablo) + ".json");

            string jsonDosya = JsonSerializer.Serialize<T>(Veri);
            yazma.WriteLine(jsonDosya);
            yazma.Close();
        }
    }
}

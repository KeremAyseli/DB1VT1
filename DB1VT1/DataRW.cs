using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace DB1VT1
{
    class DataRW<T>:IDataRead<T>,IDataWrite<T>
    {
        #region IDataWrite<T>
        public void dataWrite(string Tablo, T Veri, string AnahtarKelime)
        {
            StreamWriter yazma = new StreamWriter(dosyaAdresi + @"\" + wordHandler.kelimeHarfSayısı(AnahtarKelime).ToString() + "Harf" + @"\" + wordHandler.YerBulmaCarpma(AnahtarKelime).ToString() + @"\" + dosyaİsimOlusturma(Tablo) + ".json");

            string jsonDosya = JsonSerializer.Serialize<T>(Veri);
            yazma.WriteLine(jsonDosya);
            yazma.Close();
        }
        #endregion IDataWrite<T>
        #region IDataRead<T>
       public List<T> jsonOkuListİle(string aranacakVeri) {
            string[] adresler = klasörOku(AdressBuilder.adresOlusturma(aranacakVeri));
            List<T> liste = new List<T>();
            string json;

            for (int i = 0; i < adresler.Length; i++)
            {
                Console.WriteLine("Gelen adresler: " + adresler[i]);
                StreamReader okuma = new StreamReader(adresler[i].ToString());
                json = okuma.ReadToEnd();
                liste.Add(JsonSerializer.Deserialize<T>(json));
            }
            return liste;
        }
       public string[] klasörOku(string yol) {
            try
            {
                string[] dosyalar = Directory.GetFiles(yol);
                return dosyalar;
            }
            catch (DirectoryNotFoundException)
            {
                return null;
            }
        }
        public T[] jsonOku(string aranacakVeri) {
            return new T[0]; }
    }
    #endregion IDataRead<T>
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Linq.Expressions;

namespace DB1VT1
{
    class DataRW<T>:IDataRead<T>,IDataWrite<T>
    {
        IQueryable<T> aranan;
        WordHandler wordHandler = new WordHandler();
        #region IDataWrite<T>
        public void dataWrite(string Tablo, T Veri, string AnahtarKelime)
        {
            StreamWriter yazma = new StreamWriter(new FileBuilder<T>().NewFile(Tablo,Veri,AnahtarKelime));

            string jsonDosya = JsonSerializer.Serialize<T>(Veri);
            yazma.WriteLine(jsonDosya);
            yazma.Close();
        }
        #endregion IDataWrite<T>
        #region IDataRead<T>
        public List<T> ReadJsonWithList(string tableName,string aranacakVeri) {
            string[] adresler = klasörOku(tableName,AdressBuilder.adressGenerator(tableName,aranacakVeri));
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
       public string[] klasörOku(string tableName,string yol) {
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
        public T[] ReadData(string tableName,string aranacakVeri)
        {
            string[] adresler = klasörOku(tableName,AdressBuilder.adressGenerator(tableName,aranacakVeri));
            T[] liste = new T[adresler.Length];
            string json;
            for (int i = 0; i < liste.Length; i++)
            {
                Console.WriteLine("Gelen adresler: " + adresler[i]);
                StreamReader okuma = new StreamReader(adresler[i].ToString());
                json = okuma.ReadToEnd();
                liste[i] = JsonSerializer.Deserialize<T>(json);
            }
            return liste;
        }
        public T ilkBulunanVeri(string tableName,Expression<Func<T, bool>> ArananVeriler, string anahtarKelime)
        {
            List<T> BulunanDegerler = ReadJsonWithList(tableName,anahtarKelime);
            aranan = BulunanDegerler.AsQueryable();
            return aranan.Where(ArananVeriler).FirstOrDefault();
        }
    }
    #endregion IDataRead<T>
}

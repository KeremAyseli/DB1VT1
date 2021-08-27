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
    class DataRead<T>
    {
        IQueryable<T> aranan;
        public List<T> ReadJsonWithList(string tableName,string aranacakVeri)
        {
            string[] adresler = klasörOku(AdressBuilder.adressGenerator(tableName,aranacakVeri));
            List<T> liste = new List<T>();
            string json;
            try
            {
                for (int i = 0; i < adresler.Length; i++)
                {
                    Console.WriteLine("Gelen adresler: " + adresler[i]);
                    StreamReader okuma = new StreamReader(adresler[i].ToString());
                    json = okuma.ReadToEnd();
                    liste.Add(JsonSerializer.Deserialize<T>(json));
                }
                return liste;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public string[] klasörOku(string yol)
        {
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
        public T[] jsonOku(string tableName,string aranacakVeri)
        {
            string[] adresler = klasörOku(AdressBuilder.adressGenerator(tableName,aranacakVeri));
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
         
        public T ilkBulunanVeri(string tableName,Expression<Func<T,bool>>ArananVeriler,string anahtarKelime)
        {
            List<T> BulunanDegerler = ReadJsonWithList(tableName,anahtarKelime);
            aranan = BulunanDegerler.AsQueryable();
           return aranan.Where(ArananVeriler).FirstOrDefault();
        }
        public List<T> BulunanTumVeriler(string tableName,Expression<Func<T, bool>> ArananVeriler, string anahtarKelime)
        {
            List<T> BulunanDegerler = ReadJsonWithList(tableName,anahtarKelime);
            aranan = BulunanDegerler.AsQueryable();
            return aranan.Where(ArananVeriler).ToList();
        }
    }
}

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
    class DataRead<T>:IDataRead<T>
    {
        IQueryable<T> searchingData;
        public List<T> ReadJsonWithList(string tableName,string aranacakVeri)
        {
            string[] paths = ReadFolder(AdressBuilder.AdressGenerator(tableName,aranacakVeri));
            List<T> liste = new List<T>();
            string json;
            try
            {
                for (int i = 0; i < paths.Length; i++)
                {
                    Console.WriteLine("Reading paths: " + paths[i]);
                    StreamReader okuma = new StreamReader(paths[i].ToString());
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
        public string[] ReadFolder(string yol)
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
        public T[] ReadData(string tableName,string searchingValue)
        {
            string[] paths = ReadFolder(AdressBuilder.AdressGenerator(tableName, searchingValue)) ?? throw new ArgumentNullException("ReadFolder(AdressBuilder.AdressGenerator(tableName, searchingValue))");
            T[] liste = new T[paths.Length];
            string json;
            for (int i = 0; i < liste.Length; i++)
            {
                Console.WriteLine("Reading paths: " + paths[i]);
                StreamReader okuma = new StreamReader(paths[i].ToString());
                json = okuma.ReadToEnd();
                liste[i] = JsonSerializer.Deserialize<T>(json);
            }
            return liste;
        }
         
        public T FindFirst(string tableName,Expression<Func<T,bool>>searchExpression,string keyword)
        {
            List<T> FindgData = ReadJsonWithList(tableName,keyword);
            searchingData = FindgData.AsQueryable();
           return searchingData.Where(searchExpression).FirstOrDefault();
        }
        public List<T> FindingAllData(string tableName,Expression<Func<T, bool>> searchingDataVeriler, string anahtarKelime)
        {
            List<T> FindgData = ReadJsonWithList(tableName,anahtarKelime);
            searchingData = FindgData.AsQueryable();
            return searchingData.Where(searchingDataVeriler).ToList();
        }
    }
}

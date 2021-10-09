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
    class DataRW<T> : IDataRead<T>, IDataWrite<T>
    {
        IQueryable<T> searchingData;
        WordHandler wordHandler = new WordHandler();
        #region IDataWrite<T>
        public void dataWrite(string Table, T Data, string Keyword)
        {
            StreamWriter Write = new StreamWriter(FileBuilder<T>.GetInstance().NewFile(Table, Data, Keyword));
            Write.WriteLine(JsonSerializer.Serialize(Data));
            Write.Close();
        }
        #endregion IDataWrite<T>
        #region IDataRead<T>
        public List<T> ReadJsonWithList(string tableName, string aranacakData)
        {
            string[] adresler = ReadFolder(AdressBuilder.AdressGenerator(tableName, aranacakData));
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
        public string[] ReadFolder(string yol)
        {
            try
            {
                return Directory.GetFiles(yol);
            }
            catch (DirectoryNotFoundException)
            {
                return null;
            }
        }
        public T[] ReadData(string tableName, string aranacakData)
        {
            string[] adresler = ReadFolder(AdressBuilder.AdressGenerator(tableName, aranacakData));
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
        public T FindFirst(string tableName, Func<T, bool> searchingDataExpression, string Keyword)
        {
            List<T> findedList = ReadJsonWithList(tableName, Keyword);
            searchingData = findedList.AsQueryable();
            return findedList.Where(searchingDataExpression).FirstOrDefault();
        }
    }
    #endregion IDataRead<T>
}

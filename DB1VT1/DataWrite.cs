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
        private WordHandler wordHandler;

        public DataWrite()
        {
            wordHandler = new WordHandler();
        }

        public void dataWrite(string tableName, T data, string keyWord)
        {
            StreamWriter writer = new StreamWriter(AdressBuilder.AdressGenerator(tableName,keyWord));
            writer.WriteLine(JsonSerializer.Serialize(data));
            writer.Close();
        }
    }
}

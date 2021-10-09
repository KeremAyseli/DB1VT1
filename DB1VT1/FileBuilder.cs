using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace DB1VT1
{
    class FileBuilder<T>
    {
        private static FileBuilder<T> file;
        private FileBuilder()
        {
            folderController = new FolderController();
            wordHandler = new WordHandler();
            file = new FileBuilder<T>();
        }

        public static FileBuilder<T> GetInstance()
        {
            return file;
        }
        private FolderController folderController;
        private WordHandler wordHandler;


        public string NewFile(string tableName, T dataType, string keyWord)
        {
            string fileAdress = AdressBuilder.AdressGenerator(tableName, keyWord) + @"\" + FileNameGenerator(tableName) + ".json";
            int x = wordHandler.FindLocaiton(keyWord);
            return fileAdress;
        }
        public string FileNameGenerator(string Location)
        {
            Random rnd = new Random();
            int x = (rnd.Next(1000) / 20) * 19;
            int timeMiliMillisecond = DateTime.Now.Millisecond;
            if (folderController.dosyaisimKontrol(Location, "Data" + x.ToString() + "-" + timeMiliMillisecond.ToString() + ".json") == false)
            {
                return "Data" + x.ToString() + "-" + timeMiliMillisecond.ToString();
            }
            else
            {
                FileNameGenerator(Location);
            }
            return "Empty";
        }
    }
}

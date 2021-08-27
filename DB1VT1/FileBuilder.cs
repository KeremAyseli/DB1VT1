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
        FolderController kontrolEtme = new FolderController();
        WordHandler wordHandler = new WordHandler();
        
       public string NewFile(string tableName, T dataType, string keyWord)
        {
            string fileAdress = AdressBuilder.adressGenerator(tableName,keyWord)+@"\" + FileNameGenerator(tableName) + ".json";
            int x = wordHandler.YerBulma(keyWord);

            return fileAdress;
            
        }
        public string FileNameGenerator(string Adres)
        {
            Random rnd = new Random();
            int x = (rnd.Next(1000) / 20) * 19;
            int zaman = DateTime.Now.Millisecond;
            if (kontrolEtme.dosyaisimKontrol(Adres, "Veri" + x.ToString() + "-" + zaman.ToString() + ".json") == false)
            {
                return "Veri" + x.ToString() + "-" + zaman.ToString();
            }
            else
            {
                FileNameGenerator(Adres);
            }
            return "boş";
        }
    }
}

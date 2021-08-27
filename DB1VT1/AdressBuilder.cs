using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1VT1
{
    static class AdressBuilder
    {
        public static string adressGenerator(string tableName,string data)
        {
            WordHandler wordHandler = new WordHandler();
            string firstDirectory = wordHandler.aralıkBulma(data, 100),secondDirectory= wordHandler.kelimeHarfSayısı(data).ToString(),trhirdDirectory= wordHandler.YerBulmaCarpma(data).ToString();
            string path= Environment.CurrentDirectory + @"\Table\" + tableName + @"\" + firstDirectory + @"\" + secondDirectory + "Harf" + @"\" +trhirdDirectory;
            string firstFolder = Environment.CurrentDirectory+ @"\Table\" + tableName + @"\" + firstDirectory,
                secondFolder= Environment.CurrentDirectory + @"\Table\" + tableName + @"\" + firstDirectory + @"\" + secondDirectory + "Harf",
                thirdFolder= Environment.CurrentDirectory + @"\Table\"+tableName+@"\"+ firstDirectory + @"\" + secondDirectory + "Harf" + @"\" + trhirdDirectory;
            if (FolderController(tableName,firstFolder,secondFolder,thirdFolder))
            {
                return path;
            }
            return null;
        }
        public static bool FolderController(params string[] path)
        {
            for(int i = 0; i < path.Length; i++)
            {
                try
                {
                    if (!Directory.Exists(path[i]))
                    {
                        Directory.CreateDirectory(path[i]);
                    }  
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }
    }
}

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
        public static string adressGenerator(string girilecekVeri)
        {
            WordHandler wordHandler = new WordHandler();
            string firstDirectory = wordHandler.aralıkBulma(girilecekVeri, 100),secondDirectory= wordHandler.kelimeHarfSayısı(girilecekVeri).ToString(),trhirdDirectory= wordHandler.YerBulmaCarpma(girilecekVeri).ToString();
            
            string path= Environment.CurrentDirectory + firstDirectory + @"\" + secondDirectory + "Harf" + @"\" +trhirdDirectory ;
            string firstFolder = Environment.CurrentDirectory + firstDirectory,
                secondFolder= Environment.CurrentDirectory + firstDirectory + @"\" + secondDirectory + "Harf",
                thirdFolder= Environment.CurrentDirectory + firstDirectory + @"\" + secondDirectory + "Harf" + @"\" + trhirdDirectory;
            if (FolderController(firstFolder,secondFolder,thirdFolder))
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

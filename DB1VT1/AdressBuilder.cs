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
        public static string AdressGenerator(string tableName,string data)
        {
            WordHandler wordHandler = new WordHandler();
            string firstDirectory =wordHandler.FindSpacing(data, 100),secondDirectory= wordHandler.WordLetterCount(data).ToString(),trhirdDirectory= wordHandler.FindLocationMultiplication(data).ToString();
            string path= Environment.CurrentDirectory + @"\Table\" + tableName + @"\" + firstDirectory + @"\" + secondDirectory + "Letter" + @"\" +trhirdDirectory;
            string firstFolder = Environment.CurrentDirectory+ @"\Table\" + tableName + @"\" + firstDirectory,
                secondFolder= Environment.CurrentDirectory + @"\Table\" + tableName + @"\" + firstDirectory + @"\" + secondDirectory + "Letter",
                thirdFolder= Environment.CurrentDirectory + @"\Table\"+tableName+@"\"+ firstDirectory + @"\" + secondDirectory + "Letter" + @"\" + trhirdDirectory;
            if (FolderController(tableName,firstFolder,secondFolder,thirdFolder))
            {
                return path;
            }
            return null;
        }
        public static bool FolderController(params string[] path)
        {
            foreach (var t in path)
            {
                try
                {
                    if (!Directory.Exists(t))
                    {
                        Directory.CreateDirectory(t);
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

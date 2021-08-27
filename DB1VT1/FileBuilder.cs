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
        
       public string NewFile(string Tablo, T Veri, string AnahtarKelime)
        {
            string fileAdress = AdressBuilder.adressGenerator(AnahtarKelime)+@"\" + dosyaİsimOlusturma(Tablo) + ".json";
            int x = wordHandler.YerBulma(AnahtarKelime);

            return fileAdress;
            
        }
        public string dosyaİsimOlusturma(string Adres)
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
                dosyaİsimOlusturma(Adres);
            }
            return "boş";
        }
    }
}

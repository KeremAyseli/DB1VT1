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
        
        public void JsonOlustur(string Tablo, T Veri, string AnahtarKelime)
        {
            string fileAdress = AdressBuilder.adressGenerator(AnahtarKelime);
            int x = wordHandler.YerBulma(AnahtarKelime);
            if (!Directory.Exists(fileAdress))
            {
                Directory.CreateDirectory(fileAdress);
            }
            if (!Directory.Exists(fileAdress + @"\" + wordHandler.kelimeHarfSayısı(AnahtarKelime).ToString() + "Harf"))
            {
                Directory.CreateDirectory(fileAdress + @"\" + wordHandler.kelimeHarfSayısı(AnahtarKelime).ToString() + "Harf");
            }
            if (!Directory.Exists(fileAdress + @"\" + wordHandler.kelimeHarfSayısı(AnahtarKelime).ToString() + "Harf" + @"\" + wordHandler.YerBulmaCarpma(AnahtarKelime).ToString()))
            {
                Directory.CreateDirectory(fileAdress + @"\" + wordHandler.kelimeHarfSayısı(AnahtarKelime).ToString() + "Harf" + @"\" + wordHandler.YerBulmaCarpma(AnahtarKelime).ToString());
            }
            Console.WriteLine(Environment.CurrentDirectory + wordHandler.aralıkBulma(AnahtarKelime, 100) + @"\" + dosyaİsimOlusturma(Tablo) + ".json" + " dosya konumu");
            Console.WriteLine(x.ToString() + " bu veriler");
            
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

using System;
using System.Diagnostics;

namespace DB1VT1
{
    class Program
    {static Stopwatch zaman = new Stopwatch();
     static  Random rastgeleSayı = new Random();
        static void Main(string[] args)
        {
            //Soyisimler listesi.
            //Surname list.
         string[] soyiismler = { "ayseli", "tarcan", "şimşek", "bişgin", "beslenti", "sönmez", "öztürk", "mataracı", "bektaş", "aslan" };

            //İsimler metodundan gelen isimler listesi.
            //The list of name from isimler method.
            string[] isimlistesi = isimler();

            //Veritabanı sınıfının tanımlanması.
            //Defining the Database class.
            Kayıt<Kişiler> veriTabanıBaglnatı = new Kayıt<Kişiler>();

            //Tablo sınıfınımız.
            //The table class.
           Kişiler kişi = new Kişiler();

           /*
            * 100000 Adet yeni veri üretilmesi.
            * 100000 new data are procuded.
            */
          for (int i = 0; i < 100000; i++)
            {
                kişi.id = 3;
                kişi.isim = isimlistesi[rastgeleSayı.Next(0, isimlistesi.Length)];
                kişi.soyisim = soyiismler[rastgeleSayı.Next(0, soyiismler.Length)];
                kişi.yas = 10;
                veriTabanıBaglnatı.JsonOlustur("Kişiler", kişi, kişi.isim);
            }
        zaman.Start();  
            //Veri aranması için kullanılan ilkBulunanVeri metodu.Bir linq ve anahtar kelime parametreleriyle çalışıyor.
            //The ilkbulunanVeri method used to search data.It works with a linq and keyword parameters.
        Console.WriteLine(veriTabanıBaglnatı.ilkBulunanVeri(kisininİsmi => kisininİsmi.isim== "Joanna Daniel\r", "Joanna Daniel\r").id);
            zaman.Stop();
            Console.WriteLine("zaman: " + zaman.Elapsed.Milliseconds.ToString());
        }


        /// <summary>
        /// isimler listesini okuyan metot.
        /// The method that reads the list of names.
        /// </summary>
        /// <returns></returns>
        static string[] isimler()
        {  
         string isimlerListesi= System.IO.File.ReadAllText("isimler.txt");
          return isimlerListesi.Split(" ");
        }
    }
}

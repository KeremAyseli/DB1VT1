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
            InsertData<Kişiler> insert = new InsertData<Kişiler>();
            FileBuilder<Kişiler> file = FileBuilder<Kişiler>.GetInstance();
            DataRW<Kişiler> dataRW = new DataRW<Kişiler>();
            //Tablo sınıfınımız.
            //The table class.
           Kişiler kişi = new Kişiler();

           /*
            * 100000 Adet yeni veri üretilmesi.
            * 100000 new data are procuded.
            */
            zaman.Start();  
        /*for(int i = 0; i < 100000; i++) {
                kişi.id = 3;
                kişi.isim = isimlistesi[rastgeleSayı.Next(0, isimlistesi.Length)];
                kişi.soyisim = soyiismler[rastgeleSayı.Next(0, soyiismler.Length)];
                kişi.yas = 10;
                dataRW.dataWrite("Kişiler", kişi, kişi.isim);
            }*/
                
           //Console.WriteLine( dataRW.jsonOkuListİle("Read\r\nAmeera")[0].isim);
            
           
            Console.WriteLine(zaman.ElapsedMilliseconds);
            //Veri aranması için kullanılan ilkBulunanVeri metodu.Bir linq ve anahtar kelime parametreleriyle çalışıyor.
            //The ilkbulunanVeri method used to search data.It works with a linq and keyword parameters.
             Console.WriteLine(dataRW.FindFirst("Kişiler",kisininİsmi => kisininİsmi.isim== "Andrews\r\nSafiyah", "Andrews\r\nSafiyah").id);
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

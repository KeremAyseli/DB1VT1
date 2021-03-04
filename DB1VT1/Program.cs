using System;
using System.Diagnostics;

namespace DB1VT1
{
    class Program
    {static Stopwatch zaman = new Stopwatch();
     static  Random rastgeleSayı = new Random();
        static void Main(string[] args)
        {
           /* string[] isimler = { "kerem", "melih", "alperen", "furkan", "enes", "abdullah", "ege", "emir", "umut", "fatih" ,"Acar",
"Acun",
"Afşa",
"Adem",
"Adil",
"Adnan",
"Affan","ayseli", "tarcan", "şimşek", "bişgin", "beslenti", "sönmez", "öztürk", "mataracı", "bektaş", "aslan","cemre","nagihan","gülce","rabia","ecem","eda"};
         // string[] soyiismler = { "ayseli", "tarcan", "şimşek", "bişgin", "beslenti", "sönmez", "öztürk", "mataracı", "bektaş", "aslan" };*/
            zaman.Start();

            Kayıt<Kişiler> veriTabanıBaglnatı = new Kayıt<Kişiler>();
            
         /*  Kişiler kişi = new Kişiler();
           for (int i = 0; i < 100000; i++)
            {
                kişi.id = 3;
                kişi.isim = isimler[rastgeleSayı.Next(0, 31)];
                kişi.soyisim = soyiismler[rastgeleSayı.Next(0, 9)];
                kişi.yas = 10;
                veriTabanıBaglnatı.JsonOlustur("Kişiler", kişi, kişi.isim);
            }*/
            
            
        Console.WriteLine(veriTabanıBaglnatı.ilkBulunanVeri(kisininİsmi => kisininİsmi.isim=="kerem", "kerem").id);
            zaman.Stop();
            Console.WriteLine("zaman: " + zaman.Elapsed.Milliseconds.ToString());
        }
    }
}

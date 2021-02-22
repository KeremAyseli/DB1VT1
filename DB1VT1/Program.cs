using System;
using System.Diagnostics;

namespace DB1VT1
{
    class Program
    {static Stopwatch zaman = new Stopwatch();
        static void Main(string[] args)
        {
            zaman.Start();

            Kayıt<Kişiler> veriTabanıBaglnatı = new Kayıt<Kişiler>();
            Kişiler kişi = new Kişiler();
            kişi.id = 1;
            kişi.isim = "kerem";
            kişi.soyisim = "ayseli";
            kişi.yas = 10;
            veriTabanıBaglnatı.JsonOlustur("Kişiler", kişi, kişi.isim);
            veriTabanıBaglnatı.jsonOku(Console.ReadLine());
            zaman.Stop();
            Console.WriteLine("zaman: " + zaman.Elapsed.Milliseconds);
        }
    }
}

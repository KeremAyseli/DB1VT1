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
            kişi.id = 2;
            kişi.isim = Console.ReadLine();
            kişi.soyisim = Console.ReadLine();
            kişi.yas = 10;
            veriTabanıBaglnatı.JsonOlustur("Kişiler", kişi, kişi.isim);
            veriTabanıBaglnatı.jsonOku(Console.ReadLine());
            int i = 0;
            string aramaİsim = Console.ReadLine();
           Console.WriteLine(veriTabanıBaglnatı.ilkBulunanVeri(Id => Id.isim == aramaİsim,aramaİsim).id.ToString());
            
            zaman.Stop();
            Console.WriteLine("zaman: " + zaman.Elapsed.Milliseconds);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Motor
{//Bu program kullanacağımız sınıfları üretir.
    class Program
    {
        
      
        static void Main(string[] args)
        {
           
            Sınıfİslemleri sınıfİslemleri = new Sınıfİslemleri();
            string[] sınıflar = sınıfİslemleri.Parcalama(args[0]);
            Console.WriteLine("ARGÜMANLAR: " + sınıfİslemleri.Parcalama(args[0]).Length) ;
            
            
            //  Console.WriteLine(args[0]);
            List<string> Degiskenler = new List<string>();
            Degiskenler.Add("int i=0; String Merhaba=`merhaba`");
            for (int i = 0; i < args.Length; i++)
            {
                //program çalışırken değişkenler programa argüman olarak gönderileceği için bu kısmı oluşturdum.
                Degiskenler.Add(args[i]);
            }
            //Sınıflar adında bir klasör oluşturdum ki sınıflarımıza erişmek daha rahat olsun.
            Directory.CreateDirectory(@"E:\Visual\veri_tabanı_deneme\Motor\Sınıflar");

            for (int i = 0; i < sınıflar.Length; i++)
            { string yol = @"E:\Visual\veri_tabanı_deneme\Motor\Sınıflar\" + sınıflar[i]+".cs";
                Console.WriteLine(yol);
                FileStream SınıfYazma = new FileStream(yol, FileMode.Create);

                StreamWriter yazma = new StreamWriter(SınıfYazma);

                yazma.Write("using system; namespace Motor{class " + sınıflar[i]+ "{");
                for (int a = 0; a < Degiskenler.Count; a++)
                {
                    yazma.Write(Degiskenler[a]);
                }
                yazma.Write("}}");
                yazma.Close();
            }
            Console.ReadKey();
            
        }
    }
}


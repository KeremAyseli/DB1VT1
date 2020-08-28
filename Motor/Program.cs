using System;
using System.Collections.Generic;
using System.IO;

namespace Motor
{//Bu program kullanacağımız sınıfları üretir.
    class Program
    {
        
        static void Main(string[] args)
        {

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
            string yol = @"E:\Visual\veri_tabanı_deneme\Motor\Sınıflar\"+args[0];
            Console.WriteLine(yol);
            FileStream SınıfYazma = new FileStream(yol,FileMode.Create);  
            
            StreamWriter yazma = new StreamWriter(SınıfYazma);
          
yazma.Write("using system; namespace Motor{class deneme{");
            for (int i = 0; i < Degiskenler.Count; i++)
            {
                yazma.Write(Degiskenler[i]);   
            }
            yazma.Write("}}");
            yazma.Close();

            Console.ReadKey();
            
        }
    }
}


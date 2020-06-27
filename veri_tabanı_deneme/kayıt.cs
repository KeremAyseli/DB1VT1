using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;
namespace veri_tabanı_deneme
{
    public  class kayıt<T>
    {
        kontrol kontrolEtme = new kontrol();
        int altAralık,üstAralık;
        public T[] jsonOku(string aranacakVeri)
        {
         string[] adresler = klasörOku(adresOlusturma(aranacakVeri));
           T[] liste=new T[adresler.Length];
            string json;
            
            for(int i=0;i<adresler.Length;i++)
            {
                Console.WriteLine(adresler[i]);  
            }
            foreach (string adres in adresler)
            {for (int i = 0; i < liste.Length; i++)
                {Console.WriteLine("Gelen adresler: "+adres);
                StreamReader okuma = new StreamReader(adres);
                json = okuma.ReadToEnd(); 
                 liste[i] = JsonConvert.DeserializeObject<T>(json); }   
            }

            return liste;
           
        }

       

        string adresOlusturma(string girilecekVeri)
        {
            return @"E:\Visual\veri_tabanı_deneme\veri_tabanı_deneme\kaynak\" + aralıkBulma(YerBulma(girilecekVeri), 100) ;
        }
       
        public string[] klasörOku(string yol)
        {
            try
            {
                string[] dosyalar = Directory.GetFiles(yol);
                return dosyalar;
            }
            catch(DirectoryNotFoundException)
            {
                return null;
            }
        }


        public int YerBulma(string deger)
        {
            char[] alfabe = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'i', 'ı', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z' };
            int toplam_deger = 0;
            char[] parca = deger.ToCharArray();
            for (int i = 0; i < parca.Length; i++)
            {
                for (int x = 0; x < alfabe.Length; x++)
                {
                    if (parca[i].ToString() == alfabe[x].ToString())
                    {
                        toplam_deger += (i + x) * 10;
                        Console.WriteLine(toplam_deger + " Bu sayılar arasında olacak");
                    }
                }

            }
            return toplam_deger;
        }
     public string aralıkBulma(int arananSayı,int aralık)
        {
           
            int x =arananSayı, y = aralık;
            if (x < y)
            {
                Console.WriteLine("girilen sayı 0 ile" + y + " arasındadır");
                this.altAralık = 0;
                this.üstAralık = y;
                return 0.ToString() + "-" + y.ToString();
            }
            else
            {
                x = x / y;
                x = x * y;
                int z = x + y;
                Console.WriteLine(x + " " + y + " " + z);
                this.üstAralık = z;
                this.altAralık = x;
                return üstAralık + "-" + altAralık;
            }
        }

        public void JsonOlustur(string Tablo, T veri,string girilecekVeri)
        {
            int x = YerBulma(girilecekVeri);
            FileInfo dosya = new FileInfo(@"E:\Visual\veri_tabanı_deneme\veri_tabanı_deneme\kaynak\" + aralıkBulma(YerBulma(girilecekVeri), 100) + @"\" + dosyaİsimOlusturma(Tablo)+".json" );
            dosya.Directory.Create();
            Console.WriteLine(@"E:\Visual\veri_tabanı_deneme\veri_tabanı_deneme\kaynak\" + aralıkBulma(YerBulma(girilecekVeri), 100) + @"\" + dosyaİsimOlusturma(Tablo) + ".json"+" dosya konumu");
            Console.WriteLine(x.ToString() + " bu veriler");
            StreamWriter yazma = new StreamWriter(@"E:\Visual\veri_tabanı_deneme\veri_tabanı_deneme\kaynak\" + aralıkBulma(YerBulma(girilecekVeri),100) + @"\" +dosyaİsimOlusturma(Tablo)+".json" );
            
            string jsonDosya = JsonConvert.SerializeObject(veri);
            yazma.WriteLine(jsonDosya);
            yazma.Close();

        }
        public string dosyaİsimOlusturma(string Adres)
        {
            Random rnd = new Random();
            int x =(rnd.Next(1000)/20)*19;
            int zaman = DateTime.Now.Millisecond;
            if (kontrolEtme.dosyaisimKontrol(Adres,"Veri"+ x.ToString() + "-" + zaman.ToString() + ".json")==false)
            {
              return "Veri"+x.ToString() + "-" + zaman.ToString() ;
            }
            else
            {
                dosyaİsimOlusturma(Adres);
            }
            return "boş";
        }
    }
}
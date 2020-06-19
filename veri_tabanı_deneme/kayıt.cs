using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;
namespace veri_tabanı_deneme
{
    public  class kayıt<T>
    {
        int altAralık,üstAralık;
        public T jsonOku(string veri_kaynak)
        {
            StreamReader okuma = new StreamReader(veri_kaynak);
            string json = okuma.ReadToEnd();
            T liste = JsonConvert.DeserializeObject<T>(json);
            return liste;
        }
        public void JsonOlustur(string sıra, T veri)
        {
            StreamWriter yazma = new StreamWriter(@"E:\Visual\veri_tabanı_deneme\veri_tabanı_deneme\kaynak\" + sıra + ".json");
            string jsonDosya = JsonConvert.SerializeObject(veri);
            yazma.WriteLine(jsonDosya);
            yazma.Close();

        }

       

        public string[] klasörOku(string yol)
        {
            string[] dosyalar = Directory.GetFiles(yol);
            return dosyalar;

        }


        public void YerBulma(string deger)
        {char[] alfabe = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'i', 'ı', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z' };
            int toplam_deger;
            string[] parca = deger.Split(' ');
            for(int i = 0; i < parca.Length; i++)
            {
                for(int x=0;x<alfabe.Length;x++)
                {
                    if(parca[i]==alfabe[x].ToString())
                    {
                        toplam_deger = (i + x) * 10;
                    }
                }
                
            }
            
        }
     public void aralıkBulma(int arananSayı,int aralık)
        {
           
            int x =arananSayı, y = aralık;
            if (x < y)
            {
                Console.WriteLine("girilen sayı 0 ile" + y + " arasındadır");
                this.altAralık = 0;
                this.üstAralık = y;
            }
            else
            {
                x = x / y;
                x = x * y;
                int z = x + y;
                Console.WriteLine(x + " " + y + " " + z);
                this.üstAralık = z;
                this.altAralık = x;   
            }
        }
       

    }
}
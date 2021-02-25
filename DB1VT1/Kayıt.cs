using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Linq.Expressions;
using System.Linq;

namespace DB1VT1
{
    public class Kayıt<T>
    {
        Kontrol kontrolEtme = new Kontrol();
        int altAralık, üstAralık;
        IQueryable<T> aranan;
        public T[] KayıtOku(string aranacakVeri)
        {
            string[] adresler = klasörOku(adresOlusturma(aranacakVeri));
            T[] liste = new T[adresler.Length];
            string json;

            for (int i = 0; i < liste.Length; i++)
            {
                Console.WriteLine("Gelen adresler: " + adresler[i]);
                StreamReader okuma = new StreamReader(adresler[i].ToString());
                json = okuma.ReadToEnd();
                liste[i] = JsonSerializer.Deserialize<T>(json);
            }
            return liste;
        }
        public List<T> jsonOkuListİle(string aranacakVeri)
        {
            string[] adresler = klasörOku(adresOlusturma(aranacakVeri));
            List<T> liste = new List<T>();
            string json;

            for (int i = 0; i < adresler.Length; i++)
            {
                Console.WriteLine("Gelen adresler: " + adresler[i]);
                StreamReader okuma = new StreamReader(adresler[i].ToString());
                json = okuma.ReadToEnd();
                liste.Add(JsonSerializer.Deserialize<T>(json));
            }
            return liste;
        }

        public T VeriBul(Expression<Func<T,bool>>ArananVeriler,string anahtarKelime)
        {
         List<T>BulunanDegerler=jsonOkuListİle(anahtarKelime);
            aranan = BulunanDegerler.AsQueryable();
           return aranan.Where(ArananVeriler).FirstOrDefault();
        }

        string adresOlusturma(string girilecekVeri)
        {
            return Environment.CurrentDirectory + aralıkBulma(girilecekVeri, 100);
        }

        public string[] klasörOku(string yol)
        {
            try
            {
                string[] dosyalar = Directory.GetFiles(yol);
                return dosyalar;
            }
            catch (DirectoryNotFoundException)
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
                    }
                }

            }
            return toplam_deger;
        }
        public string aralıkBulma(string girilencekVeri, int aralık)
        {

            int x = YerBulma(girilencekVeri), y = aralık;
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
                Console.WriteLine(x + " " + x + " " + z);
                this.üstAralık = z;
                this.altAralık = x;
                return üstAralık + "-" + altAralık;
            }
        }

        public void KayıtGir(string Tablo, T Veri, string AnahtarKelime)
        {
            int x = YerBulma(AnahtarKelime);
            FileInfo dosya = new FileInfo(Environment.CurrentDirectory + aralıkBulma(AnahtarKelime, 100) + @"\" + dosyaİsimOlusturma(Tablo) + ".json");
            dosya.Directory.Create();
            Console.WriteLine(Environment.CurrentDirectory + aralıkBulma(AnahtarKelime, 100) + @"\" + dosyaİsimOlusturma(Tablo) + ".json" + " dosya konumu");
            Console.WriteLine(x.ToString() + " bu veriler");
            StreamWriter yazma = new StreamWriter(Environment.CurrentDirectory + aralıkBulma(AnahtarKelime, 100) + @"\" + dosyaİsimOlusturma(Tablo) + ".json");

            string jsonDosya = JsonSerializer.Serialize<T>(Veri);
            yazma.WriteLine(jsonDosya);
            yazma.Close();

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

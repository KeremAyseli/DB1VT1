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
        private List<T> AnlıkVeriler;
        public T[] jsonOku(string aranacakVeri)
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
       
        public T ilkBulunanVeri(Expression<Func<T,bool>>ArananVeriler,string anahtarKelime)
        {
            List<T> BulunanDegerler = jsonOkuListİle(anahtarKelime);
            aranan = BulunanDegerler.AsQueryable();
           return aranan.Where(ArananVeriler).FirstOrDefault();
        }
        public List<T> BulunanTumVeriler(Expression<Func<T, bool>> ArananVeriler, string anahtarKelime)
        {
            List<T> BulunanDegerler = jsonOkuListİle(anahtarKelime);
            aranan = BulunanDegerler.AsQueryable();
            return aranan.Where(ArananVeriler).ToList();
        }
        public void Guncelle(Expression<Func<T, bool>> ArananVeriler, string anahtarKelime)
        {
            List<T> BulunanDegerler = jsonOkuListİle(anahtarKelime);
            aranan = BulunanDegerler.AsQueryable();
            AnlıkVeriler= aranan.Where(ArananVeriler).ToList();
            
        }
        public void Kaydet(string TabloAdi,string anahtarKelime)
        {
            for (int i = 0; i < AnlıkVeriler.Count; i++)
            {
                JsonOlustur(TabloAdi, AnlıkVeriler[i], anahtarKelime);
            }
        }
        string adresOlusturma(string girilecekVeri)
        {
            return Environment.CurrentDirectory+ aralıkBulma(girilecekVeri, 100)+@"\"+kelimeHarfSayısı(girilecekVeri).ToString()+"Harf"+@"\"+YerBulmaCarpma(girilecekVeri);
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
             char[] alfabe=  { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'i', 'ı', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z' };
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
        public int YerBulmaCarpma(string deger)
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
                        toplam_deger += ((i * x) + 10)*(parca.Length*2);
                    }
                }

            }
            return toplam_deger;
        }
        public int kelimeHarfSayısı(string kelime) 
        {
            return kelime.Length;
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

        public void JsonOlustur(string Tablo, T Veri, string AnahtarKelime)
        {
            string dosyaAdresi = Environment.CurrentDirectory + aralıkBulma(AnahtarKelime, 100);
            int x = YerBulma(AnahtarKelime);
          if(!Directory.Exists(dosyaAdresi))
            {
                Directory.CreateDirectory(dosyaAdresi);
                
            }
            if (!Directory.Exists(dosyaAdresi + @"\" + kelimeHarfSayısı(AnahtarKelime).ToString() + "Harf"))
            {
                Directory.CreateDirectory(dosyaAdresi + @"\" + kelimeHarfSayısı(AnahtarKelime).ToString() + "Harf");
            }
            if (!Directory.Exists(dosyaAdresi + @"\" + kelimeHarfSayısı(AnahtarKelime).ToString() + "Harf"+ @"\" + YerBulmaCarpma(AnahtarKelime).ToString()))
            {
                Directory.CreateDirectory(dosyaAdresi + @"\" + kelimeHarfSayısı(AnahtarKelime).ToString() + "Harf"+@"\"+ YerBulmaCarpma(AnahtarKelime).ToString());
            }
            Console.WriteLine(Environment.CurrentDirectory + aralıkBulma(AnahtarKelime, 100) + @"\" + dosyaİsimOlusturma(Tablo) + ".json" + " dosya konumu");
            Console.WriteLine(x.ToString() + " bu veriler");
            StreamWriter yazma = new StreamWriter(dosyaAdresi+@"\"+ kelimeHarfSayısı(AnahtarKelime).ToString()+"Harf"+@"\"+ YerBulmaCarpma(AnahtarKelime).ToString()+ @"\" + dosyaİsimOlusturma(Tablo) + ".json");

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

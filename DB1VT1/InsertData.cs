using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Linq.Expressions;
using System.Linq;

namespace DB1VT1
{
    public class InsertData<T>
    {
        
        
        IQueryable<T> aranan;
        private List<T> AnlıkVeriler;
        
       
        
       
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
       

       


        

        
       
    }
}

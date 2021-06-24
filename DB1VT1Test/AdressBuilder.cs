using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1VT1
{
    static class AdressBuilder
    {
        public static string adresOlusturma(string girilecekVeri)
        {
            return Environment.CurrentDirectory + aralıkBulma(girilecekVeri, 100) + @"\" + kelimeHarfSayısı(girilecekVeri).ToString() + "Harf" + @"\" + YerBulmaCarpma(girilecekVeri);
        }
    }
}

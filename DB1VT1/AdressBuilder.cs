using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1VT1
{
    static class AdressBuilder
    {
        public static string adressGenerator(string girilecekVeri)
        {
            WordHandler wordHandler = new WordHandler();
            return Environment.CurrentDirectory + wordHandler.aralıkBulma(girilecekVeri, 100) + @"\" +wordHandler.kelimeHarfSayısı(girilecekVeri).ToString() + "Harf" + @"\" + wordHandler.YerBulmaCarpma(girilecekVeri);
        }
    }
}

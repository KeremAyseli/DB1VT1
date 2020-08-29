using System;
using System.Collections.Generic;
using System.Text;

namespace Motor
{
    class Sınıfİslemleri
    {
        public string[] Parcalama(string degerler)
        {
           

            string[] argümanlar = degerler.Split(',');
            Console.WriteLine(argümanlar[0]);
            return argümanlar;
        }
    }
}

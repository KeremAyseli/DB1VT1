using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

namespace veri_tabanı_deneme
{
    class Komutlar
    {
      
        
        public void sınıfOlustur()
        {
            string[] satırlar = { "namespace veri_tabanı_deneme{public class deneme{ string deneme;}}" };   
            File.WriteAllLines(@"E:\Visual\veri_tabanı_deneme\veri_tabanı_deneme\Sınıflar\deneme1.cs", satırlar);
        }
        

    }
}

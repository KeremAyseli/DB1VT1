using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
namespace veri_tabanı_deneme
{
    class kontrol
    {
      public bool dosyaisimKontrol(string Adres,string KontrolEdilecekİsim)
        {
          string[]isimler=Directory.GetFiles(Adres);
           for(int i = 0; i < isimler.Length; i++)
            {
                if (isimler[i] == KontrolEdilecekİsim)
                {
                    
                    return true;
                }
                else
                {
                    Console.WriteLine(isimler[i] + " Dosya kontrol");
                }
            }
            return false;
        }
        
        
    }
}

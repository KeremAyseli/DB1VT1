using System;
using System.IO;


namespace DB1VT1
{
    class Kontrol
    {
        public bool dosyaisimKontrol(string Adres, string KontrolEdilecekİsim)
        {
            if(!Directory.Exists(Adres))
            {
                Directory.CreateDirectory(Adres);
            }    
            string[] isimler = Directory.GetFiles(Adres);
            for (int i = 0; i < isimler.Length; i++)
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
        public void dosyaAdedi(string DosyaAdresi)
        {
          Console.WriteLine(Directory.GetFiles(@"G:\Visual\DB1VT1\DB1VT1\bin\Debug\netcoreapp3.11000-900").Length.ToString());

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace veri_tabanı_deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         private void Form1_Load(object sender, EventArgs e)
        {
             kayıt<veriYapısı> kayıt = new kayıt<veriYapısı>();
             kayıt<VeriTipi> kayı2 = new kayıt<VeriTipi>();
             veriYapısı veri = new veriYapısı();
             VeriTipi veri2 = new VeriTipi();
             veri2.id = 1;
             veri2.isim = "deneme";
             veri2.soyisim = "merhaba";
             veri2.yaş = 19;
             veri.id = 800;
             veri.veri = "bubirdenemedir";
             veri.veri_meta = "merhaba";
             kayıt.JsonOlustur("bilgiler800",veri,"merhaba");
             kayı2.JsonOlustur("bilgiler900", veri2,"merhaba");


              foreach(string dosyalar in kayıt.klasörOku(@"E:\Visual\veri_tabanı_deneme\veri_tabanı_deneme\kaynak"))
               {
                   Console.WriteLine(dosyalar);
                  veriYapısı s= kayıt.jsonOku(dosyalar);
                Console.WriteLine(s.id);
                Console.WriteLine(s.veri);
                Console.WriteLine(s.veri_meta);
               }


            kayıt.aralıkBulma(kayıt.YerBulma("merhaba"),100);
             kayı2.YerBulma("deneme");
            
            
        

    }
       
    }
}

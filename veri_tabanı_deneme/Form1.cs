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
        kayıt<veriYapısı> kayıt = new kayıt<veriYapısı>();
        veriYapısı veri = new veriYapısı();
        kayıt<VeriTipi> kayı2 = new kayıt<VeriTipi>();
        VeriTipi veri2 = new VeriTipi();
         private void Form1_Load(object sender, EventArgs e)
        {
             
            
             veri2.id = 1;
             veri2.isim = "deneme";
             veri2.soyisim = "merhaba";
             veri2.yaş = 19;
             veri.id = 800;
             veri.veri = "bubirdenemedir";
             veri.veri_meta = "merhaba";
             kayıt.JsonOlustur("bilgiler800",veri,"merhaba");
             kayı2.JsonOlustur("bilgiler900", veri2,"merhaba");


              


            kayıt.aralıkBulma(kayıt.YerBulma("merhaba"),100);
             kayı2.YerBulma("deneme");

    }

        private void button1_Click(object sender, EventArgs e)
        {
            veri.veri = textBox1.Text;
            kayıt.JsonOlustur("bilgiler800", veri, veri.veri);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            veri.veri = textBox2.Text;
                veriYapısı s = kayıt.jsonOku(veri.veri);
            Console.WriteLine(s.veri);    
            

        }
    }
}

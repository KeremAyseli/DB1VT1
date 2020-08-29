using System;
using System.Windows.Forms;
using System.Diagnostics;
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
        Stopwatch zaman = new Stopwatch();Komutlar komutlar = new Komutlar();
        private void Form1_Load(object sender, EventArgs e)
        {
            assemblyOkuma.sınıfOlusturma();
            veri2.id = 1;
            veri2.isim = "deneme";
            veri2.soyisim = "merhaba";
            veri2.yaş = 19;
            veri.id = 800;
            veri.veri = "bubirdenemedir";
            veri.veri_meta = "merhaba";
            // kayıt.JsonOlustur("bilgiler800",veri,"merhaba");
            //  kayı2.JsonOlustur("bilgiler900", veri2,"merhaba");
           
        }
 
       

        private void button1_Click(object sender, EventArgs e)
        {
            veri.veri = textBox1.Text;
            kayıt.JsonOlustur(@"E:\Visual\veri_tabanı_deneme\veri_tabanı_deneme\kaynak", veri, veri.veri);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            zaman.Start();
            veri.veri = textBox2.Text;
            veriYapısı[] s = kayıt.jsonOku(veri.veri);
            
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i].veri+" "+s[i].veri_meta+" "+s[i].id);
            }
            zaman.Stop();
            Console.WriteLine("zaman: " + zaman.Elapsed.Milliseconds);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // var x =Process.Start(@"E:\Visual\veri_tabanı_deneme\Motor\obj\Debug\netcoreapp3.1\Motor.exe");
            string[] dizi = { "sınıf1.cs", "Sınıflar3.cs" };
           
           try
            {
                Process islem = new Process();
                islem.StartInfo.UseShellExecute = false;
                islem.StartInfo.FileName = @"E:\Visual\veri_tabanı_deneme\Motor\bin\Debug\netcoreapp3.1\Motor.exe";
                islem.StartInfo.Arguments = "denem2,Sınıflar,Müsteri,Öğrenciler"; 
                //islem.StartInfo.CreateNoWindow = true;
               bool sat= islem.Start();
                if (sat == true)
                {
                    Console.WriteLine("Sınıf oluşturma başarılı");

                }
                else
                {
                    Console.WriteLine("Sınıf oluşturma başarısız");
                }
            }
            catch(Exception a)
            {
                Console.WriteLine(a.Message + " HATA MESAJI");
            }
        }
    }
}

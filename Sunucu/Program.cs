using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using DB1VT1;

namespace Sunucu
{
    class Program
    {
        static void Main(string[] args)
        {
            KisiBilgileri bilgiler = new KisiBilgileri();
            Console.WriteLine("Lütfen bir id numarası girin");
           bilgiler.id  = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lütfen isminizi giriniz");
            bilgiler.isim = Console.ReadLine();
            Console.WriteLine("Lütfen soyisiminizi giriniz");
            bilgiler.soyisim = Console.ReadLine();

           istemciBaslatma(JsonSerializer.Serialize<KisiBilgileri>(bilgiler));


            
        }
        public static void istemciBaslatma(string jsonDosya)
        {
            try
            {

                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = IPAddress.Parse("");
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 1111);

                
                Socket sender = new Socket(ipAddr.AddressFamily,
                           SocketType.Stream, ProtocolType.Tcp);

                try
                {

                 
                    sender.Connect(localEndPoint);

                    
                    Console.WriteLine("Socket connected to -> {0} ",
                                  sender.RemoteEndPoint.ToString());

                    byte[] messageSent = Encoding.ASCII.GetBytes(jsonDosya+" <EOF>");
                    int byteSent = sender.Send(messageSent);

                   
                    byte[] messageReceived = new byte[1024];

                    
                    int byteRecv = sender.Receive(messageReceived);
                    Console.WriteLine("Message from Server -> {0}",
                          Encoding.ASCII.GetString(messageReceived,
                                                     0, byteRecv));

                   
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }

        
                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }

            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
        public void sunucuBaslatma()
        {
            IPHostEntry ipSunucusu = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAdresi = ipSunucusu.AddressList[0];
            IPEndPoint yerelBitişNoktası = new IPEndPoint(ipAdresi, 1111);
            Socket port = new Socket(ipAdresi.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                port.Bind(yerelBitişNoktası);
                port.Listen(10);
                while (true)
                {
                    Console.WriteLine("Bağlnatı bekleniyor.");
                    Socket istemciPort = port.Accept();
                    byte[] byteVeriler = new byte[1024];
                    string veri = null;
                    while (true)
                    {
                        int numByte = istemciPort.Receive(byteVeriler);
                        veri += Encoding.ASCII.GetString(byteVeriler, 0, numByte);
                        if (veri.IndexOf("<EOF>") > -1)
                            break;
                    }
                    Console.WriteLine("Gelen veriler " + veri);
                    Kayıt<KisiBilgileri> VeriTabanı = new Kayıt<KisiBilgileri>();
                    KisiBilgileri kisi = JsonSerializer.Deserialize<KisiBilgileri>(veri);
                    VeriTabanı.JsonOlustur("deneme", kisi, kisi.isim);
                    byte[] mesaj = Encoding.ASCII.GetBytes("Sunucu deneme");
                    istemciPort.Send(mesaj);
                    istemciPort.Shutdown(SocketShutdown.Both);
                    istemciPort.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("hata " + e.Message);
            }
        }
    }
}

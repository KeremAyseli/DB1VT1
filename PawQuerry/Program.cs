using System;
using System.Collections;
using System.IO;
using System.Text.Json;
namespace PawQuerry
{
    class Program
    {
        static void Main(string[] args)
        {
            example a = new example(1,"kerem","ayseli");
            a.update("isim", "denemeYeniDeğer");
        }
    }
}

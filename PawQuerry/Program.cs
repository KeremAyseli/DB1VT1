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
            example a = new example(1, "kerem", "ayseli");
            //Console.WriteLine(a.Select("isim", "soyisim", "soyisim", "!="));
            
            //Console.Write(a.Select("isim","soyisim",()=>a.conditionsSelectedColumnValue=="soyisim"));
           // a.Update("id",1);
            Console.WriteLine(a.Delete("id","soyisim",()=>a.conditionsSelectedColumnValue=="soyisim"));
        }
        
    }
}

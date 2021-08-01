using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Linq.Expressions;
using System.Linq;

namespace DB1VT1
{
    public class InsertData<T>
    {
 
        private List<T> AnlıkVeriler;
 
        public void Insert(string TabloAdi,string anahtarKelime)
        {
            DataWrite<T> dataWrite = new DataWrite<T>();
            for (int i = 0; i < AnlıkVeriler.Count; i++)
            {
                dataWrite.dataWrite(TabloAdi, AnlıkVeriler[i], anahtarKelime);
            }
        }
       

       


        

        
       
    }
}

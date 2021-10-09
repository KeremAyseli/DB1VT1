using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1VT1
{
    class WordHandler
    {
        readonly char[] alphabe =
        {
            'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'i', 'ı', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r',
            's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z'
        };
        int BottomLimit, TopLimit;
        public int FindLocaiton(string value)
        {
            int sumOfValue = 0;
            
            for (int i = 0; i <value.Length; i++)
            {
                for (int x = 0; x < alphabe.Length; x++)
                {
                    if (value[i].ToString() == alphabe[x].ToString())
                    {
                        sumOfValue += (i + x) * 10;
                    }
                }

            }
            return sumOfValue;
        }
        public int FindLocationMultiplication(string values)
        {
            int sumOfValue = 0;
            for (int i = 0; i < values.Length; i++)
            {
                for (int x = 0; x < alphabe.Length; x++)
                {
                    if (values[i].ToString() == alphabe[x].ToString())
                    {
                        sumOfValue += ((i * x) + (10 * values.Length)) * (values.Length * 2);
                    }
                }

            }
            return sumOfValue;
        }
        public int WordLetterCount(string word)
        {
            return word.Length;
        }
        public string FindSpacing(string inputData, int spacingLimit)
        {

            int x = FindLocaiton(inputData), y = spacingLimit;
            if (x < y)
            {
                Console.WriteLine("girilen sayı 0 ile" + y + " arasındadır");
                this.BottomLimit = 0;
                this.TopLimit = y;
                return 0.ToString() + "-" + y.ToString();
            }
            x = x / y;
            x = x * y;
            int z = x + y;
            Console.WriteLine(x + " " + x + " " + z);
            this.TopLimit = z;
            this.BottomLimit = x;
            return TopLimit + "-" + BottomLimit;
        }
    }
}

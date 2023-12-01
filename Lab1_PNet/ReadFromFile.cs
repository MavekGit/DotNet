using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_PNet
{
    public class ReadFromFile
    {

        public void czytajZPliku(int liczba,string FileName)
        {
            string line = "";
            using (StreamReader sr = new StreamReader(FileName))
            {
                while ((line = sr.ReadLine()) != null && liczba > 0)
                {
                    Console.WriteLine(line);
                    liczba--;
                }
            }

        }

    }
}

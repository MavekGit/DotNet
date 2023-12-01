using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Lab3Dotnet
{
     internal class Generate
    {
        List<double> RandomValues = new List<double>();
        public List<double> GenerateNumbers(int NoE,int Rf,int Rt)
        {
            
            double value;
            Random rnd = new Random();
            double test = 0;

            for (int i = 0; i < NoE; i++)
            {

                value = rnd.NextDouble();
                test = value;
                value = (Rt - Rf) * value + Rf;
                Thread.Sleep(1000);

                RandomValues.Add(value);

            }

            return RandomValues; 
        }
        
        public List<double> GetRandomValues()
        {
            return RandomValues;
        }

    }
}

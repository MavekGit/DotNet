// See https://aka.ms/new-console-template for more information


using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Lab1_PNet;
using System.Runtime.CompilerServices;

class TemperatureSensor
{
 

    double? getRandomNumber()
    {
        Random random = new Random();

        double? temperature = random.NextDouble()*200 - 100;

        if(temperature <= -80)
        {
            temperature = null;
        }

        return temperature;
    }

    //List<double?> RNG(int nValues)
    //{
    //    Random number = new Random();
    //    List<double?> RandomValues = new List<double?>();
    //    for(int i = 0; i < nValues; i++) { 
    //    double? Ntemperature = number.NextDouble() * 200 - 100;
    //    string LT =  String.Format("{0:0.00}",Ntemperature);
    //    double? newListTemperature = Convert.ToDouble(LT);
    //    RandomValues.Add(newListTemperature);
    //}
    //    foreach(double? newListTemperature in RandomValues)
    //    {
    //        Console.WriteLine(newListTemperature + " ");
    //    }
    //    Console.WriteLine("FUNKCJA");
    //    return RandomValues;
    //}

    public void SaveToFile(string FileName, List<double?> TemperatureToFile) 
    {
        using (StreamWriter sw = new StreamWriter(FileName))
        {
            foreach(double? temperature in TemperatureToFile)
            {
                sw.WriteLine(temperature);
            }

        }

    }


    List<double?> RNG(int nValues, int displayValues)
    {
        Random number = new Random();
        List<double?> RandomValues = new List<double?>();
        for (int i = 0; i < nValues; i++)
        {
            double? Ntemperature = number.NextDouble() * 200 - 100;
            string LT = String.Format("{0:0.00}", Ntemperature);
            double.TryParse(LT, out double newListTemperature);
            //double? newListTemperature = Convert.ToDouble(LT);
            RandomValues.Add(newListTemperature);

            //Console.WriteLine(RandomValues.Count);

        }

        if (displayValues > RandomValues.Count)
        {
            displayValues = RandomValues.Count;
        }

        for (int j = 0;j < displayValues; j++)
        {
            Console.WriteLine(RandomValues[j]+ " ");
        }
        Console.WriteLine("FUNKCJA");
        foreach (double? Ntemperature in RandomValues)
        {
            Console.Write(Ntemperature + " ");
        }

        SaveToFile("C:\\Users\\Mavek\\Desktop\\DotNet\\Lab1DotNet\\Lab1_PNet\\plikDane.txt", RandomValues);
        return RandomValues;
    }


    static void Main(string[] args)
    {
        
        TemperatureSensor sensor = new TemperatureSensor();
        double? measure =  sensor.getRandomNumber();

        //Console.WriteLine(measure);

        ReadFromFile rff = new ReadFromFile();
        rff.czytajZPliku(10,"C:\\Users\\Mavek\\Desktop\\DotNet\\Lab1DotNet\\Lab1_PNet\\plikDane.txt ");

        List<double?> newList = new List<double?>();
        newList =  sensor.RNG(100,10);

        //foreach (double? Ntemperature in newList)
        //{
        //    Console.Write(Ntemperature + " ");
        //}

    }


}





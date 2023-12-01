using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Windows.Controls.Primitives;

namespace Lab3Dotnet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            StatusBarItem.Content = "Not Ready";


        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            await StatusBarNotReady();
        }

        private async Task StatusBarNotReady()
        {
            while (true)
            {
                if (NoElemnets.Text.Length > 0 && RangeFrom.Text.Length > 0 && RangeTo.Text.Length > 0 && StatusBarItem.Content.ToString() != "Working")
                {
                    StatusBarItem.Content = "Ready";
                }
                else if(StatusBarItem.Content.ToString() != "Working")
                {
                    StatusBarItem.Content = "Not Ready";
                }
                
                await Task.Delay(1000);
                if(StatusBarItem.Content.ToString() != "Success")
                {
                    await Task.Delay(10000);
                }
            }
        }

        private async void StartButton(object sender, RoutedEventArgs e)
        {
            StatusBarItem.Content = "Working";
            int NoE = 0, Rf = 0, Rt = 0;

            bool NoESuc, RfSuc, RtSuc;
            ProgresBar.Value = 0;
            double ProgresBarVal = ProgresBar.Value; 
            double value = 0;
            string NoEText = NoElemnets.Text;
            string RfText = RangeFrom.Text;
            string RtText = RangeTo.Text;

            NoESuc = int.TryParse(NoEText,out NoE);
            RfSuc = int.TryParse(RfText, out Rf);
            RtSuc = int.TryParse(RtText, out Rt);

            List<double> RandomValues = new List<double>();
            Generate generate = new Generate();
            double BarPercentage =  (100/NoE);

            if (NoESuc && RfSuc && RfSuc && (Rf <= Rt)) 
            {

                RandomValues = generate.GenerateNumbers(NoE,Rf,Rt);

                foreach (double n in RandomValues)
                {
                   
                    while (ProgresBar.Value < ProgresBarVal + BarPercentage)
                    {
                        ProgresBar.Value += 0.5;
                        await Task.Delay(50);
                    }

                    await Task.Delay(10);
                    ValueList.Text += n.ToString() + "\r\n";

                    ProgresBarVal = ProgresBar.Value;

                    //ProgresBar.Value += (int)BarPercentage;
                    
                    
                    
                    
                    
                }
                while(ProgresBar.Value < 100)
                {
                    ProgresBar.Value += 1;
                    await Task.Delay(1);
                }
                StatusBarItem.Content = "Success";
            }
            else
            {
                MessageBox.Show("Zły format liczb wprowadź dane jeszcze raz");

            }




        }

        private void NewClk(object sender, RoutedEventArgs e)
        {
            ValueList.Text = "";
            ProgresBar.Value =0;
        }

        private void LoadClk(object sender, RoutedEventArgs e)
        {
            int firstLine = 0;
            string line = "";
            using (StreamReader sr = new StreamReader("C:\\Users\\Mavek\\Desktop\\DotNet\\lab3Dotnet\\Lab3Dotnet\\plikDane.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    if (firstLine == 0)
                    {
                        ValueList.Text += line.ToString();
                        firstLine++;
                    }
                    else
                    {
                        ValueList.Text += "\r\n" + line.ToString();
                    }    
                }
            }

        }

        private void SaveClk(object sender, RoutedEventArgs e)
        {
            List<double> RandomValues = new List<double>();

            
            using (StreamWriter sw = new StreamWriter("C:\\Users\\Mavek\\Desktop\\DotNet\\lab3Dotnet\\Lab3Dotnet\\plikDane.txt"))
            {
                //foreach (double n in RandomValues)
                {
                    sw.WriteLine(ValueList.Text);
                }
            }
        }

        private void ExitClk(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć aplikację?", "Potwierdzenie zamknięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                
                if (e is System.Windows.Input.ExecutedRoutedEventArgs executedRoutedEventArgs)
                {
                    executedRoutedEventArgs.Handled = true;
                }
            }
            else
            {
                App.Current.Shutdown();
            }
        }

        private void AboutClk(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Author: Maciej Węcki");
        }
    }
}

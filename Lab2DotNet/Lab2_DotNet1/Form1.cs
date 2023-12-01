using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_DotNet
{
    public partial class UstSk : Form
    {
        public UstSk()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
        }

        private async void Start_Click(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy != true)
            {
                //MessageBox.Show("Start button clicked!");
                backgroundWorker1.RunWorkerAsync();
            }

            Kolo1.Text = "Stan";
            Kolo2.Text = "Stan";
            Kolo3.Text = "Stan";
            Kolo4.Text = "Stan";
            Tank.Text = "Stan";
            UstSkrz.Text = "Stan";
            WyczKas.Text = "Stan";


            await MainTask();
            
        }

        public async Task MainTask()

        {

            // Sync

            //await WymianaKola(1);
            //await WymianaKola(2);
            //await WymianaKola(3);
            //await WymianaKola(4);
            //await Tankowanie();
            //await UstawSkrzydlo();
            //await WyczyscKask();

            // Async

            Task task1 = WymianaKola(1);
            Task task2 = WymianaKola(2);
            Task task3 = WymianaKola(3);
            Task task4 = WymianaKola(4);

            Task[] groupTask = { task1, task2, task3, task4 };
            
            await Task.WhenAll(groupTask);

            await Tankowanie();
            await UstawSkrzydlo();
            await WyczyscKask();
            
        }


        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            Task mainTask = MainTask();

            while (!mainTask.IsCompleted)
            {


                for (int i = 1; i <= 10; i++)
                {

                    System.Threading.Thread.Sleep(100);
                    worker.ReportProgress(i * 10);

                }

            }    
            

        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            ZnakStop.Text = "Aktywny";
            panel1.BackColor = Color.Red;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            ZnakStop.Text = "Nie Aktywny";
            panel1.BackColor = Color.Green;

        }



        private async Task WymianaKola(int numerKola)
        {
            //DateTime WymianaRoz = DateTime.Now;
            int display = numerKola;
            switch(display)
            { 
                case 1:
                    Kolo1.Text = "Start Kolo " + numerKola;
                    break;
                case 2:
                    Kolo2.Text = "Start Kolo " + numerKola;
                    break;
                case 3:
                    Kolo3.Text = "Start Kolo " + numerKola;
                    break;
                case 4:
                    Kolo4.Text = "Start Kolo " + numerKola;
                    break;
            }


            //var t = Task.Run(async delegate { await Task.Delay(TimeSpan.FromSeconds(2)); return numerKola; });
            await Task.Delay(2000); 
            //t.Wait();
            
            switch (display)
            {
                case 1:
                    Kolo1.Text = "End Kolo " + numerKola;
                    break;
                case 2:
                    Kolo2.Text = "End Kolo " + numerKola;
                    break;
                case 3:
                    Kolo3.Text = "End Kolo " + numerKola;
                    break;
                case 4:
                    Kolo4.Text = "End Kolo " + numerKola;
                    break;
            }

            //DateTime WymianaKon = DateTime.Now;
            //MessageBox.Show("Wymieniono kolo " + numerKola + "\n" + "Rozpoczęcie " + WymianaRoz + "\n" + "Zakończenie " + WymianaKon);

        }

        public async Task Tankowanie()
        {
            Tank.Text = "Start Tank";
            //var t = Task.Run(async delegate { await Task.Delay(TimeSpan.FromSeconds(2));});
            await Task.Delay(5000);
            Tank.Text = "End Tank";
            //t.Wait();
        }


        public async Task UstawSkrzydlo()
        {
            UstSkrz.Text = "Start UstSk";
            //var t = Task.Run(async delegate { await Task.Delay(TimeSpan.FromSeconds(2)); });
            await Task.Delay(1000);
            UstSkrz.Text = "End UstSk";
            //t.Wait();
        }
        public async Task WyczyscKask()
        {
            WyczKas.Text = "Start WyczKas";
            //var t = Task.Run(async delegate { await Task.Delay(TimeSpan.FromSeconds(2)); });
            await Task.Delay(500);
            WyczKas.Text = "End WyczKas";
            //t.Wait();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ZnakStop_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }
}

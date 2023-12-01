namespace Lab2_DotNet
{
    partial class UstSk
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ZnakStop = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Start = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Kolo1 = new System.Windows.Forms.Label();
            this.Kolo2 = new System.Windows.Forms.Label();
            this.Kolo3 = new System.Windows.Forms.Label();
            this.Kolo4 = new System.Windows.Forms.Label();
            this.Tekst6 = new System.Windows.Forms.Label();
            this.Tekst5 = new System.Windows.Forms.Label();
            this.Tekst7 = new System.Windows.Forms.Label();
            this.Tekst4 = new System.Windows.Forms.Label();
            this.Tekst3 = new System.Windows.Forms.Label();
            this.Tekst2 = new System.Windows.Forms.Label();
            this.Tekst1 = new System.Windows.Forms.Label();
            this.WyczKas = new System.Windows.Forms.Label();
            this.UstSkrz = new System.Windows.Forms.Label();
            this.Tank = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ZnakStop
            // 
            this.ZnakStop.AutoSize = true;
            this.ZnakStop.Location = new System.Drawing.Point(111, 112);
            this.ZnakStop.Name = "ZnakStop";
            this.ZnakStop.Size = new System.Drawing.Size(29, 13);
            this.ZnakStop.TabIndex = 0;
            this.ZnakStop.Text = "Stan";
            this.ZnakStop.Click += new System.EventHandler(this.ZnakStop_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(53, 34);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(53, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(38, 37);
            this.panel1.TabIndex = 2;
            // 
            // Kolo1
            // 
            this.Kolo1.AutoSize = true;
            this.Kolo1.Location = new System.Drawing.Point(58, 222);
            this.Kolo1.Name = "Kolo1";
            this.Kolo1.Size = new System.Drawing.Size(29, 13);
            this.Kolo1.TabIndex = 3;
            this.Kolo1.Text = "Stan";
            this.Kolo1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Kolo2
            // 
            this.Kolo2.AutoSize = true;
            this.Kolo2.Location = new System.Drawing.Point(177, 222);
            this.Kolo2.Name = "Kolo2";
            this.Kolo2.Size = new System.Drawing.Size(29, 13);
            this.Kolo2.TabIndex = 4;
            this.Kolo2.Text = "Stan";
            // 
            // Kolo3
            // 
            this.Kolo3.AutoSize = true;
            this.Kolo3.Location = new System.Drawing.Point(309, 222);
            this.Kolo3.Name = "Kolo3";
            this.Kolo3.Size = new System.Drawing.Size(29, 13);
            this.Kolo3.TabIndex = 5;
            this.Kolo3.Text = "Stan";
            // 
            // Kolo4
            // 
            this.Kolo4.AutoSize = true;
            this.Kolo4.Location = new System.Drawing.Point(446, 222);
            this.Kolo4.Name = "Kolo4";
            this.Kolo4.Size = new System.Drawing.Size(29, 13);
            this.Kolo4.TabIndex = 6;
            this.Kolo4.Text = "Stan";
            // 
            // Tekst6
            // 
            this.Tekst6.AutoSize = true;
            this.Tekst6.Location = new System.Drawing.Point(183, 262);
            this.Tekst6.Name = "Tekst6";
            this.Tekst6.Size = new System.Drawing.Size(36, 13);
            this.Tekst6.TabIndex = 8;
            this.Tekst6.Text = "UstSk";
            // 
            // Tekst5
            // 
            this.Tekst5.AutoSize = true;
            this.Tekst5.Location = new System.Drawing.Point(60, 262);
            this.Tekst5.Name = "Tekst5";
            this.Tekst5.Size = new System.Drawing.Size(32, 13);
            this.Tekst5.TabIndex = 7;
            this.Tekst5.Text = "Tank";
            // 
            // Tekst7
            // 
            this.Tekst7.AutoSize = true;
            this.Tekst7.Location = new System.Drawing.Point(311, 262);
            this.Tekst7.Name = "Tekst7";
            this.Tekst7.Size = new System.Drawing.Size(52, 13);
            this.Tekst7.TabIndex = 9;
            this.Tekst7.Text = "WyczKas";
            // 
            // Tekst4
            // 
            this.Tekst4.AutoSize = true;
            this.Tekst4.Location = new System.Drawing.Point(446, 188);
            this.Tekst4.Name = "Tekst4";
            this.Tekst4.Size = new System.Drawing.Size(37, 13);
            this.Tekst4.TabIndex = 13;
            this.Tekst4.Text = "Kolo 4";
            // 
            // Tekst3
            // 
            this.Tekst3.AutoSize = true;
            this.Tekst3.Location = new System.Drawing.Point(309, 188);
            this.Tekst3.Name = "Tekst3";
            this.Tekst3.Size = new System.Drawing.Size(37, 13);
            this.Tekst3.TabIndex = 12;
            this.Tekst3.Text = "Kolo 3";
            // 
            // Tekst2
            // 
            this.Tekst2.AutoSize = true;
            this.Tekst2.Location = new System.Drawing.Point(177, 188);
            this.Tekst2.Name = "Tekst2";
            this.Tekst2.Size = new System.Drawing.Size(37, 13);
            this.Tekst2.TabIndex = 11;
            this.Tekst2.Text = "Kolo 2";
            // 
            // Tekst1
            // 
            this.Tekst1.AutoSize = true;
            this.Tekst1.Location = new System.Drawing.Point(58, 188);
            this.Tekst1.Name = "Tekst1";
            this.Tekst1.Size = new System.Drawing.Size(37, 13);
            this.Tekst1.TabIndex = 10;
            this.Tekst1.Text = "Kolo 1";
            // 
            // WyczKas
            // 
            this.WyczKas.AutoSize = true;
            this.WyczKas.Location = new System.Drawing.Point(311, 297);
            this.WyczKas.Name = "WyczKas";
            this.WyczKas.Size = new System.Drawing.Size(29, 13);
            this.WyczKas.TabIndex = 16;
            this.WyczKas.Text = "Stan";
            // 
            // UstSkrz
            // 
            this.UstSkrz.AutoSize = true;
            this.UstSkrz.Location = new System.Drawing.Point(183, 297);
            this.UstSkrz.Name = "UstSkrz";
            this.UstSkrz.Size = new System.Drawing.Size(29, 13);
            this.UstSkrz.TabIndex = 15;
            this.UstSkrz.Text = "Stan";
            // 
            // Tank
            // 
            this.Tank.AutoSize = true;
            this.Tank.Location = new System.Drawing.Point(60, 297);
            this.Tank.Name = "Tank";
            this.Tank.Size = new System.Drawing.Size(29, 13);
            this.Tank.TabIndex = 14;
            this.Tank.Text = "Stan";
            // 
            // UstSk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WyczKas);
            this.Controls.Add(this.UstSkrz);
            this.Controls.Add(this.Tank);
            this.Controls.Add(this.Tekst4);
            this.Controls.Add(this.Tekst3);
            this.Controls.Add(this.Tekst2);
            this.Controls.Add(this.Tekst1);
            this.Controls.Add(this.Tekst7);
            this.Controls.Add(this.Tekst6);
            this.Controls.Add(this.Tekst5);
            this.Controls.Add(this.Kolo4);
            this.Controls.Add(this.Kolo3);
            this.Controls.Add(this.Kolo2);
            this.Controls.Add(this.Kolo1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.ZnakStop);
            this.Name = "UstSk";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ZnakStop;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Kolo1;
        private System.Windows.Forms.Label Kolo2;
        private System.Windows.Forms.Label Kolo3;
        private System.Windows.Forms.Label Kolo4;
        private System.Windows.Forms.Label Tekst6;
        private System.Windows.Forms.Label Tekst5;
        private System.Windows.Forms.Label Tekst7;
        private System.Windows.Forms.Label Tekst4;
        private System.Windows.Forms.Label Tekst3;
        private System.Windows.Forms.Label Tekst2;
        private System.Windows.Forms.Label Tekst1;
        private System.Windows.Forms.Label WyczKas;
        private System.Windows.Forms.Label UstSkrz;
        private System.Windows.Forms.Label Tank;
    }
}


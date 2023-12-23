using System;
using System.Collections.Generic;
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
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Automation.Provider;
using System.Xml;
using System.Xml.Schema;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace Szachy_Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy chessGame.xaml
    /// </summary>
    public partial class chessGame : Page
    {
        public chessGame()
        {
            InitializeComponent();

            generateChessboard();

        }


        private void boardSquerBtn(object sender, RoutedEventArgs e)
        {

        }

        private void generateChessboard()
        {

            Button[,] buttons = new Button[8, 8];


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);

                    button.Click += boardSquerBtn;

                    UGrid.Children.Add(button);

                    buttons[i, j] = button;

                    if ((i + j) % 2 == 0)
                    {
                        button.Background = Brushes.Gray;
                    }
                    else
                    {
                        button.Background = Brushes.White;
                    }
                }
            }
        }

    

    }
}

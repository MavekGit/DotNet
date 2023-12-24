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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;



namespace Szachy_Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy chessGame.xaml
    /// </summary>
    public partial class chessGame : Page
    {
        private Button firstClick;
        private Button secondClick;
        //private int CurrentRow = -100;
        //private int CurrentColumn = -100;


        public chessGame()
        {
            InitializeComponent();
 
            generateChessboard();

        }


        private void boardSquerBtn(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);

            //BlackKnightMove(row, column, button);

        }

        //private void BlackKnightMove(int row, int column, Button button)
        //{
            

        //    if (firstClick == null && position[row, column] == figureValue.BlackKnight)
        //    {
        //        firstClick = button;
        //        CurrentRow = row;
        //        CurrentColumn = column;
        //       // BlackKnightCheck = true;

        //    }
        //    else if ((firstClick != null) && (secondClick == null) && ((position[row, column] == figureValue.Empty || (position[row, column] > 10) && position[row, column] < 100) && ((Math.Abs(row - CurrentRow) == 1 && (Math.Abs(column - CurrentColumn) == 2)) || ((Math.Abs(row - CurrentRow) == 2 && (Math.Abs(column - CurrentColumn) == 1))))))
        //    {



        //        secondClick = button;

                               
                
        //        buttons[CurrentRow, CurrentColumn].Content = "";
        //        buttons[row, column].Content = new System.Windows.Controls.Image { Source = Images.BlackKnight }; ;
        //        position[row, column] = figureValue.BlackKnight;
        //        position[CurrentRow, CurrentColumn] = 0;

        //        firstClick = null;
        //        secondClick = null;
        //       // BlackKnightCheck = false;
        //       // GlobalTurn = true;

        //    }
        //    else
        //    {
        //        firstClick = null;
        //        secondClick = null;
        //       // BlackKnightCheck = false;
        //    }

        //}



        private figureValue[,] generateChessboard()
        {

            Button[,] buttons = new Button[8, 8];
            figureValue[,] position = new figureValue[8, 8];

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

            foreach (int row in position)
            {
                foreach (int col in position)
                {
                    position[row, col] = figureValue.Empty;
                }
            }

            List<figureValue> figureList = new List<figureValue>
            {
                
                figureValue.BlackRook,
                figureValue.BlackKnight,
                figureValue.BlackBishop,
                figureValue.BlackKing,
                figureValue.BlackQueen,
                figureValue.BlackBishop,
                figureValue.BlackKnight,
                figureValue.BlackRook,
                figureValue.BlackPawn,
                figureValue.WhitePawn,
                figureValue.WhiteRook,
                figureValue.WhiteKnight,
                figureValue.WhiteBishop,
                figureValue.WhiteKing,
                figureValue.WhiteQueen,
                figureValue.WhiteBishop,
                figureValue.WhiteKnight,
                figureValue.WhiteRook,

            };

            List<ImageSource> imageList = new List<ImageSource>
            {
                Images.BlackRook,
                Images.BlackKnight,
                Images.BlackBishop,
                Images.BlackKing,
                Images.BlackQueen,
                Images.BlackBishop,
                Images.BlackKnight,
                Images.BlackRook,
                Images.BlackPawn,
                Images.WhitePawn,
                Images.WhiteRook,
                Images.WhiteKnight,
                Images.WhiteBishop,
                Images.WhiteKing,
                Images.WhiteQueen,
                Images.WhiteBishop,
                Images.WhiteKnight,
                Images.WhiteRook,
                
            };

            int[] index = { 0, 1, 6, 7 };

            int k = 0;
            foreach (int i in index)
            {
                for (int j = 0; j < 8; j++)
                {
                    
                    position[i, j] = figureList[k];

                    buttons[i, j].Content = new System.Windows.Controls.Image { Source = imageList[k] };

                    if (!((figureList[k] == figureValue.BlackPawn || figureList[k] == figureValue.WhitePawn) && j != 7 ))
                    {
                        k++;
                    }

                }
            }

            return position;
        }

       

    }
}

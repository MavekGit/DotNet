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

    struct ChessboardParameters
    {
        private Button[,] buttons;
        private figureValue[,] position;
        //private figureValue[] blackPiecesCannotCapture;
        //private figureValue[] whitePiecesCannotCapture;
        public Button button { get; set; }
        public Button FirstClick { get; set; }
        public Button SecondClick { get; set; }
        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }

        public Button[,] Buttons
        {
            get { return buttons; }
            set { buttons = value; }
        }

        public figureValue[,] Position
        {
            get { return position; }
            set { position = value; }
        }

        //public figureValue[] BlackPiecesCannotCapture
        //{
        //    get { return blackPiecesCannotCapture; }
        //    set { blackPiecesCannotCapture = value; }
        //}

        //public figureValue[] WhitePiecesCannotCapture
        //{
        //    get { return whitePiecesCannotCapture; }
        //    set { blackPiecesCannotCapture = value; }
        //}

        public ChessboardParameters(Button[,] buttons, figureValue[,] position, Button firstClick, Button secondClick, int currentRow, int currentColumn, figureValue[] blackPiecesCannotCapture, figureValue[] whitePiecesCannotCapture)
        {
            this.buttons = buttons;
            this.position = position;
            FirstClick = firstClick;
            SecondClick = secondClick;
            CurrentRow = currentRow;
            CurrentColumn = currentColumn;

            //BlackPiecesCannotCapture = blackPiecesCannotCapture ?? new figureValue[] { figureValue.BlackPawn, figureValue.BlackKnight, figureValue.BlackBishop, figureValue.BlackKnight, figureValue.BlackQueen, figureValue.WhiteKing };
            //WhitePiecesCannotCapture = whitePiecesCannotCapture ?? new figureValue[] { figureValue.WhitePawn, figureValue.WhiteKnight, figureValue.WhiteBishop, figureValue.WhiteKnight, figureValue.WhiteQueen, figureValue.BlackKnight };
        }
    }


    public partial class chessGame : Page
    {

        private ChessboardParameters param = new ChessboardParameters();
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

            BlackKnightMove(row, column, button);

        }

        private void BlackKnightMove(int row, int column, Button button)
        {
            figureValue[] blackPiecesAttacked = new figureValue[] { figureValue.BlackPawn,figureValue.BlackRook, figureValue.BlackKnight, figureValue.BlackBishop, figureValue.BlackQueen};
            figureValue[] whitePiecesAttacked = new figureValue[] { figureValue.WhitePawn,figureValue.WhiteRook, figureValue.WhiteKnight, figureValue.WhiteBishop, figureValue.WhiteQueen };




            if ( param.FirstClick == null && param.Position[row, column] == figureValue.BlackKnight)
            {

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {

                        if (param.Buttons[i, j].Background == Brushes.Red && (i + j) % 2 == 0)
                        {
                            param.Buttons[i, j].Background = Brushes.Gray;
                        }
                        else if (param.Buttons[i, j].Background == Brushes.Red && (i + j) % 2 != 0)
                        {
                            param.Buttons[i, j].Background = Brushes.White;
                        }

                        if (param.Buttons[i, j].Content is System.Windows.Controls.Image image && image.Source == Images.Dot)
                        {
                            param.Buttons[i, j].Content = "";
                        }


                    }
                }

                param.FirstClick = button;
                param.CurrentRow = row;
                param.CurrentColumn = column;

               
                // BlackKnightCheck = true;
                int futureRow = 0;
                int futureColumn = 0;

                int[] knightMoves = { -2, -1, 1, 2 };

                foreach (int i in knightMoves)
                {
                    foreach (int j in knightMoves)
                    {
                        
                        if (Math.Abs(i) + Math.Abs(j) != 3)
                        {
                            continue;
                        }

                            futureRow = row + i;
                            futureColumn = column + j;

                      
                        if ((futureRow >= 0 && futureRow < 8 && futureColumn >= 0 && futureColumn < 8) && param.Position[futureRow,futureColumn] == figureValue.Empty)
                        {
                            param.Buttons[futureRow, futureColumn].Content = new System.Windows.Controls.Image { Source = Images.Dot };
                            
                        }
                        else if (((futureRow >= 0 && futureRow < 8 && futureColumn >= 0 && futureColumn < 8)) && whitePiecesAttacked.Contains(param.Position[futureRow,futureColumn]))
                        {
                           param.Buttons[futureRow, futureColumn].Background = Brushes.Red;
                        }
                    }
                }

            }
            else if ((param.FirstClick != null) && (param.SecondClick == null) && ((param.Buttons[row, column].Content is System.Windows.Controls.Image image && image.Source == Images.Dot || (whitePiecesAttacked.Contains(param.Position[row, column])))))
            {

                param.SecondClick = button;

                param.Buttons[param.CurrentRow, param.CurrentColumn].Content = "";
                param.Buttons[row, column].Content = new System.Windows.Controls.Image { Source = Images.BlackKnight }; ;
                param.Position[row, column] = figureValue.BlackKnight;
                param.Position[param.CurrentRow, param.CurrentColumn] = 0;

                param.FirstClick = null;
                param.SecondClick = null;
                // BlackKnightCheck = false;
                // GlobalTurn = true;


                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {

                        if (param.Buttons[i, j].Background == Brushes.Red && (i + j) % 2 == 0)
                        {
                            param.Buttons[i, j].Background = Brushes.Gray;
                        }
                        else if (param.Buttons[i, j].Background == Brushes.Red && (i + j) % 2 != 0)
                        {
                            param.Buttons[i, j].Background = Brushes.White;
                        }

                        if (param.Buttons[i, j].Content is System.Windows.Controls.Image image1 && image1.Source == Images.Dot)
                        {
                            param.Buttons[i, j].Content = "";
                        }


                    }
                }

            }
            else
            {
                param.FirstClick = null;
                param.SecondClick = null;
                // BlackKnightCheck = false;


                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {

                        if (param.Buttons[i, j].Background == Brushes.Red && (i + j) % 2 == 0)
                        {
                            param.Buttons[i, j].Background = Brushes.Gray;
                        }
                        else if (param.Buttons[i, j].Background == Brushes.Red && (i + j) % 2 != 0)
                        {
                            param.Buttons[i, j].Background = Brushes.White;
                        }

                        if (param.Buttons[i, j].Content is System.Windows.Controls.Image image2 && image2.Source == Images.Dot)
                        {
                            param.Buttons[i, j].Content = "";
                        }


                    }
                }

            }

        }



        private void generateChessboard()
        {
            //ChessboardParameters chessboardParameters = new ChessboardParameters();

            Button[,] buttons = new Button[8,8];
            figureValue[,] position = new figureValue[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    param.button = button;

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

            param.Position = position;
            param.Buttons = buttons;
        }

       

    }
}

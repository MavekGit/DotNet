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
        private figureValue[] blackPiecesCannotCapture;
        private figureValue[] whitePiecesCannotCapture;
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

        public figureValue[] BlackPiecesCannotCapture
        {
            get { return blackPiecesCannotCapture; }
        }

        public figureValue[] WhitePiecesCannotCapture
        {
            get { return whitePiecesCannotCapture; }
        }

        public ChessboardParameters(Button[,] buttons, figureValue[,] position, Button firstClick, Button secondClick, int currentRow, int currentColumn)
        {
            this.buttons = buttons;
            this.position = position;
            FirstClick = firstClick;
            SecondClick = secondClick;
            CurrentRow = currentRow;
            CurrentColumn = currentColumn;

            blackPiecesCannotCapture = new figureValue[] { figureValue.BlackPawn,figureValue.BlackKnight,figureValue.BlackBishop,figureValue.BlackKnight,figureValue.BlackQueen,figureValue.WhiteKing};
            whitePiecesCannotCapture = new figureValue[] { figureValue.WhitePawn,figureValue.WhiteKnight,figureValue.WhiteBishop,figureValue.WhiteKnight,figureValue.WhiteQueen,figureValue.BlackKnight};
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

            
            if ( param.FirstClick == null && param.Position[row, column] == figureValue.BlackKnight)
            {
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

                        Debug.WriteLine("row: " + row + ", i: " + i + ", column: " + column + ", j: " + j + ", futureRow: " + futureRow + ", futureColumn: " + futureColumn);


                        //Debug.WriteLine(param.BlackPiecesCannotCapture[0], "XD");

                        if ((futureRow >= 0 && futureRow < 8 && futureColumn >= 0 && futureColumn < 8) && param.Position[futureRow,futureColumn] == figureValue.Empty)
                        {
                            param.Buttons[futureRow, futureColumn].Content = new System.Windows.Controls.Image { Source = Images.Dot };
                            Debug.WriteLine(param.Position[futureRow, futureColumn]);

                        }
                        else if (((futureRow >= 0 && futureRow < 8 && futureColumn >= 0 && futureColumn < 8)))
                        {

                            //foreach (figureValue blackPiece in param.BlackPiecesCannotCapture)
                            //{
                            //    if (param.Position[futureRow, futureColumn] == blackPiece)
                            //    {
    
                            //        param.Buttons[futureRow, futureColumn].Background = new SolidColorBrush(Colors.Red);
                                    
                            //    }
                            //}
                        }
                    }
                }

            }
            else if ((param.FirstClick != null) && (param.SecondClick == null) && ((param.Position[row, column] == figureValue.Empty || (param.Position[row, column] > figureValue.BlackPiece) && param.BlackPiecesCannotCapture.Contains(param.Position[row, column])) && ((Math.Abs(row - param.CurrentRow) == 1 && (Math.Abs(column - param.CurrentColumn) == 2)) || ((Math.Abs(row - param.CurrentRow) == 2 && (Math.Abs(column - param.CurrentColumn) == 1))))))
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

            }
            else
            {
                param.FirstClick = null;
                param.SecondClick = null;
                // BlackKnightCheck = false;
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

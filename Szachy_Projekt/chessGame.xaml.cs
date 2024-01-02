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
using Szachy_Projekt.Pieces;



namespace Szachy_Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy chessGame.xaml
    /// </summary>

    public struct param
    {

        public static Button[,] Buttons { get; set; }
        public static figureValue[,] Position { get; set; }
        public static figureValue[] BlackPiecesAttacked { get; set; }
        public static figureValue[] WhitePiecesAttacked { get; set; }
        public static figureValue[] BlackPieces { get; set; }
        public static figureValue[] WhitePieces { get; set; }
        public static figureValue PickedFigure {  get; set; }
        public static Button Button { get; set; }
        public static Button FirstClick { get; set; }
        public static Button SecondClick { get; set; }
        public static int CurrentRow { get; set; }
        public static int CurrentColumn { get; set; }
        public static bool GlobalTurn {  get; set; }
        public static bool KingAttackCheck { get; set; }
        public static bool BlackKingInDanger { get; set; }
        public static bool WhiteKingInDanger { get; set; }
        public static List<Tuple <int,int>> SquaresInCheck { get; set; }

        static param()
        {
        
        }

        public static void Initialize()
        {

            GlobalTurn = true;
            KingAttackCheck = false;

            BlackKingInDanger = false;
            BlackKingInDanger = false;

            BlackPiecesAttacked = [figureValue.BlackPawn, figureValue.BlackKnight, figureValue.BlackBishop, figureValue.BlackRook, figureValue.BlackQueen];
            WhitePiecesAttacked = [figureValue.WhitePawn, figureValue.WhiteKnight, figureValue.WhiteBishop, figureValue.WhiteRook, figureValue.WhiteQueen];

            BlackPieces = [figureValue.BlackPawn, figureValue.BlackKnight, figureValue.BlackBishop, figureValue.BlackRook, figureValue.BlackQueen, figureValue.BlackKing];
            WhitePieces = [figureValue.WhitePawn, figureValue.WhiteKnight, figureValue.WhiteBishop, figureValue.WhiteRook, figureValue.WhiteQueen, figureValue.WhiteKing];

            SquaresInCheck = new List<Tuple<int, int>>();

        }
    }

    




    public partial class chessGame : Page
    {

        public chessGame()
        {
            InitializeComponent();
            
            param.Initialize();

            generateChessboard();


        }


        private void boardSquerBtn(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);
        
            Knight whiteKnight = new Knight();
            Bishop whiteBishop = new Bishop();
            Rook whiteRook = new Rook();
            Queen whiteQueen = new Queen();
            Pawn whitePawn = new Pawn();
            King whiteKing = new King();

            Knight blackKnight = new Knight();
            Bishop blackBishop = new Bishop();
            Rook blackRook = new Rook();
            Queen blackQueen = new Queen();
            Pawn blackPawn = new Pawn();
            King blackKing = new King();

            Debug.WriteLine("Rząd, Kolumna, Przycisk NORMAL MOVE" + row + " " + column + " " + button);

         
            

            if (param.GlobalTurn == true)
            {
                

                whiteBishop.FigurePicked(row, column, button, figureValue.WhiteBishop, param.BlackPiecesAttacked);
                whiteKnight.FigurePicked(row, column, button, figureValue.WhiteKnight, param.BlackPiecesAttacked);
                whiteRook.FigurePicked(row, column, button, figureValue.WhiteRook, param.BlackPiecesAttacked);
                whiteQueen.FigurePicked(row, column, button, figureValue.WhiteQueen, param.BlackPiecesAttacked);
                whitePawn.FigurePicked(row, column, button, figureValue.WhitePawn, param.BlackPiecesAttacked);
                whiteKing.FigurePicked(row, column, button, figureValue.WhiteKing, param.BlackPiecesAttacked);

                if (param.PickedFigure == figureValue.WhiteKnight)
                {
                    whiteKnight.FigureMove(row, column, button, figureValue.WhiteKnight, Images.WhiteKnight, param.BlackPiecesAttacked, param.WhitePieces);
                }
                else if(param.PickedFigure == figureValue.WhiteBishop)
                {
                    whiteBishop.FigureMove(row, column, button, figureValue.WhiteBishop, Images.WhiteBishop, param.BlackPiecesAttacked, param.WhitePieces);
                }
                else if (param.PickedFigure == figureValue.WhiteRook)
                {
                    whiteRook.FigureMove(row, column, button, figureValue.WhiteRook, Images.WhiteRook, param.BlackPiecesAttacked, param.WhitePieces);
                }
                else if (param.PickedFigure == figureValue.WhiteQueen)
                {
                    whiteQueen.FigureMove(row, column, button, figureValue.WhiteQueen, Images.WhiteQueen, param.BlackPiecesAttacked, param.WhitePieces);
                }
                else if (param.PickedFigure == figureValue.WhitePawn)
                {
                    whitePawn.FigureMove(row, column, button, figureValue.WhitePawn, Images.WhitePawn, param.BlackPiecesAttacked, param.WhitePieces);
                }
                else if (param.PickedFigure == figureValue.WhiteKing)
                {
                    whitePawn.FigureMove(row, column, button, figureValue.WhiteKing, Images.WhiteKing, param.BlackPiecesAttacked, param.WhitePieces);
                }

            }
            else if(param.GlobalTurn == false)
            {
           

                blackBishop.FigurePicked(row, column, button, figureValue.BlackBishop, param.WhitePiecesAttacked);
                blackKnight.FigurePicked(row, column, button, figureValue.BlackKnight, param.WhitePiecesAttacked);
                blackRook.FigurePicked(row, column, button, figureValue.BlackRook, param.WhitePiecesAttacked);
                blackQueen.FigurePicked(row, column, button, figureValue.BlackQueen, param.WhitePiecesAttacked);
                blackPawn.FigurePicked(row, column, button, figureValue.BlackPawn, param.WhitePiecesAttacked);
                blackKing.FigurePicked(row, column, button, figureValue.BlackKing, param.WhitePiecesAttacked);

                if (param.PickedFigure == figureValue.BlackKnight)
                {
                    blackKnight.FigureMove(row, column, button, figureValue.BlackKnight, Images.BlackKnight, param.WhitePiecesAttacked, param.BlackPieces);
                }
                else if(param.PickedFigure == figureValue.BlackBishop)
                {
                    blackBishop.FigureMove(row, column, button, figureValue.BlackBishop, Images.BlackBishop, param.WhitePiecesAttacked, param.BlackPieces);
                }
                else if (param.PickedFigure == figureValue.BlackRook)
                {
                    blackRook.FigureMove(row, column, button, figureValue.BlackRook, Images.BlackRook, param.WhitePiecesAttacked, param.BlackPieces);
                }
                else if (param.PickedFigure == figureValue.BlackQueen)
                {
                    blackQueen.FigureMove(row, column, button, figureValue.BlackQueen, Images.BlackQueen, param.WhitePiecesAttacked, param.BlackPieces);
                }
                else if (param.PickedFigure == figureValue.BlackPawn)
                {
                    blackPawn.FigureMove(row, column, button, figureValue.BlackPawn, Images.BlackPawn, param.WhitePiecesAttacked, param.BlackPieces);
                }
                else if (param.PickedFigure == figureValue.BlackKing)
                {
                    blackKing.FigureMove(row, column, button, figureValue.BlackKing, Images.BlackKing, param.WhitePiecesAttacked, param.BlackPieces);
                }

            }

        }

      


        private void generateChessboard()
        {
            UGrid.Children.Clear();

            Button[,] buttons = new Button[8,8];
            figureValue[,] position = new figureValue[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    param.Button = button;

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

        private void ResetGameBtn(object sender, RoutedEventArgs e)
        {
            

            param.Initialize();
            generateChessboard();
        }
    }
}

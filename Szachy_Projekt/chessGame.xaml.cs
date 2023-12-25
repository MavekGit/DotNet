﻿using System;
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

        public struct param
    {

        public static Button[,] Buttons { get; set; }
        public static figureValue[,] Position { get; set; }
        public static figureValue[] BlackPiecesAttacked { get; set; }
        public static figureValue[] WhitePiecesAttacked { get; set; }
        public static figureValue[] BlackPieces { get; set; }
        public static figureValue[] WhitePieces { get; set; }
        public static Button Button { get; set; }
        public static Button FirstClick { get; set; }
        public static Button SecondClick { get; set; }
        public static int CurrentRow { get; set; }
        public static int CurrentColumn { get; set; }
        public static bool GlobalTurn {  get; set; }

        static param()
        {
        
            }

        public static void Initialize()
        {

            GlobalTurn = true;
            BlackPiecesAttacked = [figureValue.BlackPawn, figureValue.BlackKnight, figureValue.BlackBishop, figureValue.BlackRook, figureValue.BlackQueen];
            WhitePiecesAttacked = [figureValue.WhitePawn, figureValue.WhiteKnight, figureValue.WhiteBishop, figureValue.WhiteRook, figureValue.WhiteQueen];

            BlackPieces = [figureValue.BlackPawn, figureValue.BlackKnight, figureValue.BlackBishop, figureValue.BlackRook, figureValue.BlackQueen, figureValue.BlackKing];
            WhitePieces = [figureValue.WhitePawn, figureValue.WhiteKnight, figureValue.WhiteBishop, figureValue.WhiteRook, figureValue.WhiteQueen, figureValue.WhiteKing];
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

            //figureClass figure = new figureClass();



            //figure.BlackKnightMove(row, column, button);
           
           
                    
                
            if(param.GlobalTurn == true)
            {
                Knight whiteKnight = new Knight();
                whiteKnight.FigureMove(row, column, button, figureValue.WhiteKnight, Images.WhiteKnight, param.BlackPiecesAttacked);
            }
            else if(param.GlobalTurn == false)
            {
                Knight blackKnight = new Knight();
                blackKnight.FigureMove(row, column, button, figureValue.BlackKnight, Images.BlackKnight, param.WhitePiecesAttacked);
            }

        }

      


        private void generateChessboard()
        {
            

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

       

    }
}

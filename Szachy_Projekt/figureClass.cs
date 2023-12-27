using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Szachy_Projekt.Pieces;

namespace Szachy_Projekt
{
    public abstract class figureClass
    {
        protected void HelpMoveClear()
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
        }

        protected abstract void LegalMoves(int row, int column, figureValue[] figureAttacked);


        protected void ShowLegalMoves(int futureRow, int futureColumn, figureValue[] figureAttacked)
        {
           
            if ((futureRow >= 0 && futureRow < 8 && futureColumn >= 0 && futureColumn < 8) && param.Position[futureRow, futureColumn] == figureValue.Empty)
            {
                param.Buttons[futureRow, futureColumn].Content = new System.Windows.Controls.Image { Source = Images.Dot };

            }
            else if (((futureRow >= 0 && futureRow < 8 && futureColumn >= 0 && futureColumn < 8)) && figureAttacked.Contains(param.Position[futureRow, futureColumn]))
            {
                param.Buttons[futureRow, futureColumn].Background = Brushes.Red;
            }
        }
       
        public void FigureMove(int row, int column, Button button, figureValue figure, ImageSource figureImage ,figureValue[] figureAttacked, figureValue[] figureColor)
        {

            //Debug.WriteLine("FIGURE MOVE " + figure);

                
            if ((param.FirstClick != null) && (param.SecondClick == null) && ((param.Buttons[row, column].Content is System.Windows.Controls.Image image && image.Source == Images.Dot || param.Buttons[row, column].Background == Brushes.Red )))
            {
                Debug.WriteLine("FIGURE MOVE IF FUNCTION " + figure);

                param.SecondClick = button;
                param.Buttons[row, column].Content = new System.Windows.Controls.Image { Source = figureImage }; ;
                param.Position[row, column] = figure;

                param.Buttons[param.CurrentRow, param.CurrentColumn].Content = "";
                param.Position[param.CurrentRow, param.CurrentColumn] = figureValue.Empty;
               

                param.FirstClick = null;
                param.SecondClick = null;
                param.PickedFigure = figureValue.NonePicked;
                HelpMoveClear();

                if (param.BlackPieces.Contains(figure))
                {
                    param.GlobalTurn = true;
                }
                else if(param.WhitePieces.Contains(figure))
                {
                    param.GlobalTurn = false;
                }

            }

            //else if((param.FirstClick != null) && ( (figureColor.Contains(param.Position[row,column])) && ( (param.Position[param.CurrentRow,param.CurrentColumn] != param.Position[row, column]) || (param.Position[param.CurrentRow, param.CurrentColumn] == param.Position[row, column] && (row != param.CurrentRow || column != param.CurrentColumn))) ))
            
            // Optimazed if steatment
            else if ((param.FirstClick != null) && ((figureColor.Contains(param.Position[row, column])) && (((row != param.CurrentRow || column != param.CurrentColumn)))))
            {
                //Debug.WriteLine("FIGURE PRZED FUNKCJĄ " + figure);
                //Debug.WriteLine("PICKED FIGURE PRZED FUNKCJĄ " + param.PickedFigure);
                //Debug.WriteLine("WARTOŚĆ POLA PRZED FUNCKJĄ " + param.Position[row, column]);
                //Debug.WriteLine("-----------------------------------------------------------");
                //Debug.WriteLine(param.Position[param.CurrentRow, param.CurrentColumn] + " CURRENT");
                //Debug.WriteLine(param.Position[row, column] + " ");

                param.FirstClick = null;
                param.SecondClick = null;

                Knight whiteKnight = new Knight();
                Bishop whiteBishop = new Bishop();
                Rook whiteRook = new Rook();
                Queen whiteQueen = new Queen();
                Pawn whitePawn = new Pawn();

                Knight blackKnight = new Knight();
                Bishop blackBishop = new Bishop();
                Rook blackRook = new Rook();
                Queen blackQueen = new Queen();
                Pawn blackPawn = new Pawn();


                whiteBishop.FigurePicked(row, column, button, figureValue.WhiteBishop, param.BlackPiecesAttacked);
                whiteKnight.FigurePicked(row, column, button, figureValue.WhiteKnight, param.BlackPiecesAttacked);
                whiteRook.FigurePicked(row, column, button, figureValue.WhiteRook, param.BlackPiecesAttacked);
                whiteQueen.FigurePicked(row, column, button, figureValue.WhiteQueen, param.BlackPiecesAttacked);
                whitePawn.FigurePicked(row, column, button, figureValue.WhitePawn, param.BlackPiecesAttacked);
                
                               
                blackBishop.FigurePicked(row, column, button, figureValue.BlackBishop, param.WhitePiecesAttacked);
                blackKnight.FigurePicked(row, column, button, figureValue.BlackKnight, param.WhitePiecesAttacked);
                blackRook.FigurePicked(row, column, button, figureValue.BlackRook, param.WhitePiecesAttacked);
                blackQueen.FigurePicked(row, column, button, figureValue.BlackQueen, param.WhitePiecesAttacked);
                blackPawn.FigurePicked(row, column, button, figureValue.BlackPawn, param.WhitePiecesAttacked);

                //figure = param.Position[row, column];

                //FigurePicked(row,column,button,figure,figureAttacked);

                //Debug.WriteLine("FIGURE PO FUNKCJI" + figure);
                //Debug.WriteLine("PICKED FIGURE PO FUNKCJI " + param.PickedFigure);
                //Debug.WriteLine("WARTOŚĆ POLA PO FUNCKJI " + param.Position[row, column]);
                //Debug.WriteLine("-----------------------------------------------------------");


            }
            else if ((param.FirstClick != null) && param.Position[row, column] == figureValue.Empty)
            {
                param.FirstClick = null;
                param.SecondClick = null;
                param.PickedFigure = figureValue.NonePicked;
                HelpMoveClear();
            }

        }

        public void FigurePicked(int row, int column, Button button, figureValue figure, figureValue[] figureAttacked)
        {
            
            //Debug.WriteLine("WARTOŚĆ POLA PRZED PICKED FIGURE " + param.Position[row, column]);
            //Debug.WriteLine("-----------------------------------------------------------");

            if (param.FirstClick == null && (param.SecondClick == null) &&  param.Position[row, column] == figure)
            {

                //Debug.WriteLine("FIGURE PICKED " + figure);
                //Debug.WriteLine("WARTOŚĆ POLA W PICKED FIGURE " + param.Position[row, column]);
                //Debug.WriteLine("-----------------------------------------------------------");
                HelpMoveClear();

                param.FirstClick = button;
                param.CurrentRow = row;
                param.CurrentColumn = column;
                    

                LegalMoves(row, column, figureAttacked);

                param.PickedFigure = param.Position[param.CurrentRow,param.CurrentColumn];
                
            }
        }

    }
}

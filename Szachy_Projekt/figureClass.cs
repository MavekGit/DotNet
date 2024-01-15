using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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

                    if (param.Buttons[i, j].Background == Brushes.Yellow && (i + j) % 2 == 0 && (param.Position[i, j] == figureValue.Empty))
                    {
                        param.Buttons[i, j].Background = Brushes.Gray;
                    }
                    else if (param.Buttons[i, j].Background == Brushes.Yellow && (i + j) % 2 != 0 && (param.Position[i, j] == figureValue.Empty))
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

            if(param.KingAttackCheck == true && (futureRow >= 0 && futureRow < 8 && futureColumn >= 0 && futureColumn < 8))
            {

                //if (param.GlobalTurn == true && param.Position[futureRow, futureColumn] == figureValue.BlackKing)
                //{

                //    param.Buttons[futureRow, futureColumn].Background = Brushes.Yellow;
               

                //}
                //else if (param.GlobalTurn == false && param.Position[futureRow, futureColumn] == figureValue.WhiteKing)
                //{
                //    param.Buttons[futureRow, futureColumn].Background = Brushes.Yellow;
                
                //}

                param.SquaresInCheck.Add(new Tuple<int, int>(futureRow, futureColumn));

            }

            if (param.KingDefendCheck == true && (futureRow >= 0 && futureRow < 8 && futureColumn >= 0 && futureColumn < 8))
            {

                param.KingDefendingLines.Add(new Tuple<int, int>(futureRow, futureColumn));

            }

    }

        protected void AfterMoveChessboardUpdate(Button button)
        {
            param.KingAttackCheck = true;
            param.KingDefendCheck = true;
            param.SquaresInCheck.Clear();
            param.KingAttackingLines.Clear();
            param.KingDefendingLines.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int row = i;
                    int column = j;

                    // can be wrong
                    //param.FirstClick = null;

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


                    if (param.GlobalTurn == false)
                    {

                        if (param.Position[row, column] == figureValue.WhiteBishop)
                        {
                            whiteBishop.FigurePicked(row, column, button, figureValue.WhiteBishop, param.BlackPiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.WhiteKnight)
                        {
                            whiteKnight.FigurePicked(row, column, button, figureValue.WhiteKnight, param.BlackPiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.WhiteRook)
                        {
                            whiteRook.FigurePicked(row, column, button, figureValue.WhiteRook, param.BlackPiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.WhiteQueen)
                        {
                            whiteQueen.FigurePicked(row, column, button, figureValue.WhiteQueen, param.BlackPiecesAttacked);
                        }
                        //else if (param.Position[row, column] == figureValue.WhiteKing)
                        //{
                        //    whiteKing.FigurePicked(row, column, button, figureValue.WhiteKing, param.BlackPiecesAttacked);
                        //}
                        else if (param.Position[row, column] == figureValue.WhitePawn)
                        {
                            whitePawn.FigurePicked(row, column, button, figureValue.WhitePawn, param.BlackPiecesAttacked);
                        }

                    }
                    else if (param.GlobalTurn == true)
                    {

                        if (param.Position[row, column] == figureValue.BlackBishop)
                        {
                            blackBishop.FigurePicked(row, column, button, figureValue.BlackBishop, param.WhitePiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.BlackKnight)
                        {
                            blackKnight.FigurePicked(row, column, button, figureValue.BlackKnight, param.WhitePiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.BlackRook)
                        {
                            blackRook.FigurePicked(row, column, button, figureValue.BlackRook, param.WhitePiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.BlackQueen)
                        {
                            blackQueen.FigurePicked(row, column, button, figureValue.BlackQueen, param.WhitePiecesAttacked);
                        }
                        //else if (param.Position[row, column] == figureValue.BlackKing)
                        //{
                        //    blackKing.FigurePicked(row, column, button, figureValue.BlackKing, param.WhitePiecesAttacked);
                        //}
                        else if (param.Position[row, column] == figureValue.BlackPawn)
                        {
                            blackPawn.FigurePicked(row, column, button, figureValue.BlackPawn, param.WhitePiecesAttacked);
                        }

                    }


                }
            }

            param.KingAttackCheck = false;
            param.KingDefendCheck = false;
        }

        protected void AfterMoveIsKingInCheckUpdate(figureValue figure)
        {


            if (param.GlobalTurn == true)
            {

                foreach (Tuple<int, int> square in param.SquaresInCheck)
                {
                    int R = square.Item1;
                    int C = square.Item2;

                    //Debug.WriteLine(" TO JEST ROW:  " + R + " TO JEST COLUMN: " + C );
                    //param.Buttons[R, C].Background = Brushes.Blue;

                    //if (param.Position[R, C] == figureValue.WhiteKing)
                    //{
                    //    param.Buttons[R, C].Background = Brushes.Yellow;
                    //    param.WhiteKingInDanger = true;
                    //    Debug.WriteLine(" HELLO CHECKNESS MY OLD FRIEND BLACK TO MOVE");
                    //}
                    //else if (param.Buttons[R, C].Background == Brushes.Yellow && (R + C) % 2 == 0)
                    //{
                    //    param.Buttons[R, C].Background = Brushes.Gray;
                    //    param.WhiteKingInDanger = false;
                    //    Debug.WriteLine(" HELLO DARKNESS MY OLD FRIEND BLACK TO MOVE");
                    //}
                    //else if (param.Buttons[R, C].Background == Brushes.Yellow && (R + C) % 2 != 0)
                    //{
                    //    param.Buttons[R, C].Background = Brushes.White;
                    //    param.WhiteKingInDanger = false;
                    //    Debug.WriteLine(" HELLO WHITENESS MY OLD FRIEND BLACK TO MOVE");
                    //}
                }

                foreach (Tuple<int, int> square in param.KingAttackingLines)
                {
                    int R = square.Item1;
                    int C = square.Item2;

                    //param.Buttons[R, C].Background = Brushes.Magenta;
                    //Debug.WriteLine(R + " R " + C + " C ");
                }



                param.WhiteKingInDanger = false;
            }

            else if (param.GlobalTurn == false)
            {
                foreach (Tuple<int, int> square in param.SquaresInCheck)
                {
                    int R = square.Item1;
                    int C = square.Item2;

                    //Debug.WriteLine(" TO JEST ROW:  " + R + " TO JEST COLUMN: " + C);
                    //param.Buttons[R, C].Background = Brushes.Green;

                    //if (param.Position[R, C] == figureValue.BlackKing)
                    //{
                    //    Debug.WriteLine(" HELLO CHECKNESS MY OLD FRIEND WHITE TO MOVE");
                    //    param.Buttons[R, C].Background = Brushes.Yellow;
                    //    param.BlackKingInDanger = true;

                    //}
                    //else if (param.Buttons[R, C].Background == Brushes.Yellow && (R + C) % 2 == 0)
                    //{
                    //    Debug.WriteLine(" HELLO DARKNESS MY OLD FRIEND WHITE TO MOVE");
                    //    param.Buttons[R, C].Background = Brushes.Gray;
                    //    param.BlackKingInDanger = false;
                    //}
                    //else if (param.Buttons[R, C].Background == Brushes.Yellow && (R + C) % 2 != 0)
                    //{
                    //    Debug.WriteLine(" HELLO WHITENESS MY OLD FRIEND WHITE TO MOVE");
                    //    param.Buttons[R, C].Background = Brushes.White;
                    //    param.BlackKingInDanger = false;
                    //}
                }


                foreach (Tuple<int, int> square in param.KingAttackingLines)
                {
                    int R = square.Item1;
                    int C = square.Item2;

                     //param.Buttons[R, C].Background = Brushes.Purple;
                    // Debug.WriteLine(R + " R " + C + " C ");
                }

                param.BlackKingInDanger = false;
            }

        }


        protected void isKingChecked(Button button)
        {
            param.KingAttackCheck = true;
            param.SquaresInCheck.Clear();
            param.KingAttackingLines.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int row = i;
                    int column = j;

                    // can be wrong
                    //param.FirstClick = null;

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


                    if(param.GlobalTurn == true)
                    {

                        if (param.Position[row,column] == figureValue.WhiteBishop)
                        {
                            whiteBishop.FigurePicked(row, column, button, figureValue.WhiteBishop, param.BlackPiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.WhiteKnight)
                        {
                            whiteKnight.FigurePicked(row, column, button, figureValue.WhiteKnight, param.BlackPiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.WhiteRook)
                        {
                            whiteRook.FigurePicked(row, column, button, figureValue.WhiteRook, param.BlackPiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.WhiteQueen)
                        {
                            whiteQueen.FigurePicked(row, column, button, figureValue.WhiteQueen, param.BlackPiecesAttacked);
                        }
                        //else if (param.Position[row, column] == figureValue.WhiteKing)
                        //{
                        //    whiteKing.FigurePicked(row, column, button, figureValue.WhiteKing, param.BlackPiecesAttacked);
                        //}
                        else if (param.Position[row, column] == figureValue.WhitePawn)
                        {
                            whitePawn.FigurePicked(row, column, button, figureValue.WhitePawn, param.BlackPiecesAttacked);
                        }

                    }
                    else if(param.GlobalTurn == false)
                    {

                        if (param.Position[row, column] == figureValue.BlackBishop)
                        {
                            blackBishop.FigurePicked(row, column, button, figureValue.BlackBishop, param.WhitePiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.BlackKnight)
                        {
                            blackKnight.FigurePicked(row, column, button, figureValue.BlackKnight, param.WhitePiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.BlackRook)
                        {
                            blackRook.FigurePicked(row, column, button, figureValue.BlackRook, param.WhitePiecesAttacked);
                        }
                        else if (param.Position[row, column] == figureValue.BlackQueen)
                        {
                            blackQueen.FigurePicked(row, column, button, figureValue.BlackQueen, param.WhitePiecesAttacked);
                        }
                        //else if (param.Position[row, column] == figureValue.BlackKing)
                        //{
                        //    blackKing.FigurePicked(row, column, button, figureValue.BlackKing, param.WhitePiecesAttacked);
                        //}
                        else if (param.Position[row, column] == figureValue.BlackPawn)
                        {
                            blackPawn.FigurePicked(row, column, button, figureValue.BlackPawn, param.WhitePiecesAttacked);
                        }

                    }


                }
            }

            param.KingAttackCheck = false;

        }

        protected void isKingInCheckUpdate(figureValue figure)
        {
           

            if (param.BlackPieces.Contains(figure))
            {

                foreach (Tuple<int, int> square in param.SquaresInCheck)
                {
                    int R = square.Item1;
                    int C = square.Item2;

                    //Debug.WriteLine(" TO JEST ROW:  " + R + " TO JEST COLUMN: " + C );
                    //param.Buttons[R, C].Background = Brushes.Blue;

                    if (param.Position[R, C] == figureValue.WhiteKing)
                    {
                        param.Buttons[R, C].Background = Brushes.Yellow;
                        param.WhiteKingInDanger = true;
                        Debug.WriteLine(" HELLO CHECKNESS MY OLD FRIEND BLACK TO MOVE");
                    }
                    else if (param.Buttons[R, C].Background == Brushes.Yellow && (R + C) % 2 == 0)
                    {
                        param.Buttons[R, C].Background = Brushes.Gray;
                        param.WhiteKingInDanger = false;
                        Debug.WriteLine(" HELLO DARKNESS MY OLD FRIEND BLACK TO MOVE");
                    }
                    else if (param.Buttons[R, C].Background == Brushes.Yellow && (R + C) % 2 != 0)
                    {
                        param.Buttons[R, C].Background = Brushes.White;
                        param.WhiteKingInDanger = false;
                        Debug.WriteLine(" HELLO WHITENESS MY OLD FRIEND BLACK TO MOVE");
                    }
                }

                foreach (Tuple<int, int> square in param.KingAttackingLines)
                {
                    int R = square.Item1;
                    int C = square.Item2;

                    //param.Buttons[R, C].Background = Brushes.Magenta;
                    //Debug.WriteLine(R + " R " + C + " C ");
                }

                

                
            }

            else if(param.WhitePieces.Contains(figure))
            {
                foreach (Tuple<int, int> square in param.SquaresInCheck)
                {
                    int R = square.Item1;
                    int C = square.Item2;

                    //Debug.WriteLine(" TO JEST ROW:  " + R + " TO JEST COLUMN: " + C);
                    //param.Buttons[R, C].Background = Brushes.Green;

                    if (param.Position[R, C] == figureValue.BlackKing)
                    {
                        Debug.WriteLine(" HELLO CHECKNESS MY OLD FRIEND WHITE TO MOVE");
                        param.Buttons[R, C].Background = Brushes.Yellow;
                        param.BlackKingInDanger = true;
                        
                    }
                    else if (param.Buttons[R, C].Background == Brushes.Yellow && (R + C) % 2 == 0)
                    {
                        Debug.WriteLine(" HELLO DARKNESS MY OLD FRIEND WHITE TO MOVE");
                        param.Buttons[R, C].Background = Brushes.Gray;
                        param.BlackKingInDanger = false;
                    }
                    else if (param.Buttons[R, C].Background == Brushes.Yellow && (R + C) % 2 != 0)
                    {
                        Debug.WriteLine(" HELLO WHITENESS MY OLD FRIEND WHITE TO MOVE");
                        param.Buttons[R, C].Background = Brushes.White;
                        param.BlackKingInDanger = false;
                    }
                }


                foreach (Tuple<int, int> square in param.KingAttackingLines)
                {
                    int R = square.Item1;
                    int C = square.Item2;

                   // param.Buttons[R, C].Background = Brushes.Purple;
                   // Debug.WriteLine(R + " R " + C + " C ");
                }

              
            }

        }

        protected void FiugreAttackKing(int row, int column, int futureRow, int futureColumn, figureValue[] figureAttacked)
        {
            int rowDirection = 0;
            int columnDirection = 0;

            if ((param.Position[futureRow, futureColumn] == figureValue.BlackKing && param.GlobalTurn == true) || (param.Position[futureRow, futureColumn] == figureValue.WhiteKing && param.GlobalTurn == false))
            {

                if (row > futureRow)
                {
                    rowDirection = 1;
                }

                if (row < futureRow)
                {

                    rowDirection = -1;
                }

                if (column > futureColumn)
                {
                    columnDirection = 1;
                }

                if (column < futureColumn)
                {
                    columnDirection = -1;
                }

                if (row == futureRow)
                {
                    rowDirection = 0;

                }

                if (column == futureColumn)
                {
                    columnDirection = 0;
                }

                Debug.WriteLine(row + " " + column + " " + futureRow + " " + futureColumn + " " + rowDirection + " " + columnDirection);
                for (int i = futureRow, j = futureColumn; i != row || j != column; i += rowDirection, j += columnDirection)
                {
                    param.KingAttackingLines.Add(new Tuple<int, int>(i, j));
                }

                // Dodajemy również pozycje figury do pol które należy zająć aby obronić się przed szachem
                param.KingAttackingLines.Add(new Tuple<int, int>(row, column));
            }
           

        }


        private void CheckMate()
        {
            if((param.GlobalTurn == false && param.WhiteKingInDanger) || (param.GlobalTurn == true && param.BlackKingInDanger))
            {

                foreach (Tuple<int, int> square in param.KingAttackingLines)
                {
                    int RA = square.Item1;
                    int CA = square.Item2;

                    foreach (Tuple<int, int> Dsquare in param.KingDefendingLines)
                    {
                        int RD = Dsquare.Item1;
                        int CD = Dsquare.Item2;


                        if (RA != RD && CA != CD && (param.Position[RA, RD] != figureValue.WhiteKing && param.Position[RA, RD] != figureValue.BlackKing))
                        {
                            param.CheckMate = true;


                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    if (param.Buttons[i, j].Background == Brushes.Yellow)
                                    {
                                        param.Buttons[i, j].Background = Brushes.Orange;
                                    }
                                }
                            }
                        }
                    }


                }

            }

        }

        public void FigureMove(int row, int column, Button button, figureValue figure, ImageSource figureImage ,figureValue[] figureAttacked, figureValue[] figureColor)
        {
                
            if ((param.FirstClick != null) && (param.SecondClick == null) && ((param.Buttons[row, column].Content is System.Windows.Controls.Image image && image.Source == Images.Dot || param.Buttons[row, column].Background == Brushes.Red )))
            {

                param.SecondClick = button;
                param.Buttons[row, column].Content = new System.Windows.Controls.Image { Source = figureImage }; ;
                param.Position[row, column] = figure;

                param.Buttons[param.CurrentRow, param.CurrentColumn].Content = "";
                param.Position[param.CurrentRow, param.CurrentColumn] = figureValue.Empty;

                // Check if our King in check
                AfterMoveChessboardUpdate(button);
                AfterMoveIsKingInCheckUpdate(figure);

                // Must check what is attacked 
                isKingChecked(button);
                isKingInCheckUpdate(figure);

                CheckMate();

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

                param.FirstClick = null;
                param.SecondClick = null;

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

                whiteBishop.FigurePicked(row, column, button, figureValue.WhiteBishop, param.BlackPiecesAttacked);
                whiteKnight.FigurePicked(row, column, button, figureValue.WhiteKnight, param.BlackPiecesAttacked);
                whiteRook.FigurePicked(row, column, button, figureValue.WhiteRook, param.BlackPiecesAttacked);
                whiteQueen.FigurePicked(row, column, button, figureValue.WhiteQueen, param.BlackPiecesAttacked);
                whitePawn.FigurePicked(row, column, button, figureValue.WhitePawn, param.BlackPiecesAttacked);
                whiteKing.FigurePicked(row, column, button, figureValue.WhiteKing, param.BlackPiecesAttacked);

                blackBishop.FigurePicked(row, column, button, figureValue.BlackBishop, param.WhitePiecesAttacked);
                blackKnight.FigurePicked(row, column, button, figureValue.BlackKnight, param.WhitePiecesAttacked);
                blackRook.FigurePicked(row, column, button, figureValue.BlackRook, param.WhitePiecesAttacked);
                blackQueen.FigurePicked(row, column, button, figureValue.BlackQueen, param.WhitePiecesAttacked);
                blackPawn.FigurePicked(row, column, button, figureValue.BlackPawn, param.WhitePiecesAttacked);
                blackKing.FigurePicked(row, column, button, figureValue.BlackKing, param.WhitePiecesAttacked);


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
            

            if ((param.FirstClick == null && (param.SecondClick == null) &&  param.Position[row, column] == figure) || param.KingAttackCheck == true)
            {

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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy_Projekt.Pieces
{
    public class Pawn : figureClass
    {

        protected override void LegalMoves(int row, int column, figureValue[] figureAttacked)
        {
            int futureRow = 0;
            int futureColumn = 0;
            int BreakLoop = 0;

            int startRowWhite = row - 3, startRowBlack = row + 3, otherRowWhite = row - 2, otherRowBlack = row + 2;
            int[] pawnColumnMoves = { -1, 1 };
            int[] BlackpawnRowMoves = { 1 };
            int[] WhitepawnRowMoves = { -1 };

            // Black Pawn
            if (figureAttacked == param.WhitePiecesAttacked)
            {

                if (row == 1 && (param.KingAttackCheck == false || param.KingDefendCheck == true))
                {

                    for (int i = row, j = column; i < startRowBlack; i++)
                    {

                        if (((i < 0 || i > 7) || (j < 0 || j > 7))  || param.Position[i, j] != figureValue.Empty || param.Position[row+1, column] != figureValue.Empty)
                        {   

                            continue;
                        }
                        


                        Debug.WriteLine(i + " " + j);
                        futureRow = i;
                        futureColumn = j;

                        if ((param.GlobalTurn == false && param.BlackKingInDanger == true) || (param.GlobalTurn == true && param.WhiteKingInDanger == true))
                        {

                            foreach (Tuple<int, int> square in param.KingAttackingLines)
                            {
                                int R = square.Item1;
                                int C = square.Item2;

                                if (futureRow == R && futureColumn == C)
                                {
                                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);
                                }
                            }

                        }
                        else if ((param.BlackKingInDanger == false && param.GlobalTurn == false) || (param.WhiteKingInDanger == false && param.GlobalTurn == true))
                        {

                            ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                        }


                        FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);


                    }

                }
                
                else if(row != 1 && (param.KingAttackCheck == false || param.KingDefendCheck == true))
                {
                    for (int i = row, j = column; i < otherRowBlack; i++)
                    {

                        if (((i < 0 || i > 7) || (j < 0 || j > 7)) || param.Position[i, j] != figureValue.Empty)
                        {
                            continue;
                        }


                        Debug.WriteLine(i + " " + j);
                        futureRow = i;
                        futureColumn = j;

                        if ((param.GlobalTurn == false && param.BlackKingInDanger == true) || (param.GlobalTurn == true && param.WhiteKingInDanger == true))
                        {

                            foreach (Tuple<int, int> square in param.KingAttackingLines)
                            {
                                int R = square.Item1;
                                int C = square.Item2;

                                if (futureRow == R && futureColumn == C)
                                {
                                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);
                                }
                            }

                        }
                        else if ((param.BlackKingInDanger == false && param.GlobalTurn == false) || (param.WhiteKingInDanger == false && param.GlobalTurn == true))
                        {

                            ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                        }


                        FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);


                    }
                }

                //if (figureAttacked.Contains(param.Position[row+1,column-1]) || figureAttacked.Contains(param.Position[row + 1, column + 1]))
                //{
                //   // for (int i = row, j = column; i < otherRowBlack  ; i++)
                //    foreach(int j in pawnColumnMoves)
                //    { 
                //        foreach(int i in BlackpawnRowMoves)
                //        {

                //            if (((row + i < 0 || row + i > 7) || (column + j < 0 || column + j > 7)))
                //            {
                //                continue;
                //            }

                //            //Debug.WriteLine(i + " " + j);
                //            futureRow = row + i;
                //            futureColumn = column + j;

                //            ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                //        }
                //    }
                //}

                if (((row + 1 >= 0 && row + 1 <= 7) && (column - 1 >= 0 && column - 1 <= 7)))
                {
                    if ((figureAttacked.Contains(param.Position[row + 1, column - 1]) || param.Position[row + 1, column - 1] == figureValue.WhiteKing) || param.KingAttackCheck == true)
                    {
                        futureRow = row + 1;
                        futureColumn = column - 1;

                        if ((param.GlobalTurn == false && param.BlackKingInDanger == true) || (param.GlobalTurn == true && param.WhiteKingInDanger == true))
                        {

                            foreach (Tuple<int, int> square in param.KingAttackingLines)
                            {
                                int R = square.Item1;
                                int C = square.Item2;

                                if (futureRow == R && futureColumn == C)
                                {
                                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);
                                }
                            }

                        }
                        else if ((param.BlackKingInDanger == false && param.GlobalTurn == false) || (param.WhiteKingInDanger == false && param.GlobalTurn == true))
                        {

                            ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                        }


                        FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);

                    }


                }
                if (((row + 1 >= 0 && row + 1 <= 7) && (column + 1 >= 0 && column + 1 <= 7)))
                {
                if ((figureAttacked.Contains(param.Position[row + 1, column + 1]) || param.Position[row + 1, column + 1] == figureValue.WhiteKing) || param.KingAttackCheck == true)

                    {
                        futureRow = row + 1;
                        futureColumn = column + 1;

                        if ((param.GlobalTurn == false && param.BlackKingInDanger == true) || (param.GlobalTurn == true && param.WhiteKingInDanger == true))
                        {

                            foreach (Tuple<int, int> square in param.KingAttackingLines)
                            {
                                int R = square.Item1;
                                int C = square.Item2;

                                if (futureRow == R && futureColumn == C)
                                {
                                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);
                                }
                            }

                        }
                        else if ((param.BlackKingInDanger == false && param.GlobalTurn == false) || (param.WhiteKingInDanger == false && param.GlobalTurn == true))
                        {

                            ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                        }


                        FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);

                    }
                }


            }
            BreakLoop = 0;
            // White Pawn
            if (figureAttacked == param.BlackPiecesAttacked)
            {

                if (row == 6 && (param.KingAttackCheck == false || param.KingDefendCheck == true))
                {

                    for (int i = row, j = column; i > startRowWhite; i--)
                    {

                        if (((i < 0 || i > 7) || (j < 0 || j > 7)) || param.Position[i, j] != figureValue.Empty || param.Position[row - 1, column ] != figureValue.Empty)
                        {

                            continue;
                        }


                        Debug.WriteLine(i + " " + j);
                        futureRow = i;
                        futureColumn = j;

                        if ((param.GlobalTurn == false && param.BlackKingInDanger == true) || (param.GlobalTurn == true && param.WhiteKingInDanger == true))
                        {

                            foreach (Tuple<int, int> square in param.KingAttackingLines)
                            {
                                int R = square.Item1;
                                int C = square.Item2;

                                if (futureRow == R && futureColumn == C)
                                {
                                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);
                                }
                            }

                        }
                        else if ((param.BlackKingInDanger == false && param.GlobalTurn == false) || (param.WhiteKingInDanger == false && param.GlobalTurn == true))
                        {

                            ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                        }


                        FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);


                    }

                }
                else if(row != 6 && (param.KingAttackCheck == false || param.KingDefendCheck == true))
                {
                    for (int i = row, j = column; i > otherRowWhite; i--)
                    {

                        if (((i < 0 || i > 7) || (j < 0 || j > 7)) || param.Position[i, j] != figureValue.Empty)
                        {
                            continue;
                        }


                        Debug.WriteLine(i + " " + j);
                        futureRow = i;
                        futureColumn = j;

                        if ((param.GlobalTurn == false && param.BlackKingInDanger == true) || (param.GlobalTurn == true && param.WhiteKingInDanger == true))
                        {

                            foreach (Tuple<int, int> square in param.KingAttackingLines)
                            {
                                int R = square.Item1;
                                int C = square.Item2;

                                if (futureRow == R && futureColumn == C)
                                {
                                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);
                                }
                            }

                        }
                        else if ((param.BlackKingInDanger == false && param.GlobalTurn == false) || (param.WhiteKingInDanger == false && param.GlobalTurn == true))
                        {

                            ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                        }


                        FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);


                    }
                }

                //if (figureAttacked.Contains(param.Position[row - 1, column - 1]) || figureAttacked.Contains(param.Position[row - 1, column + 1]))
                //{
                //    // for (int i = row, j = column; i < otherRowBlack  ; i++)
                //    foreach (int j in pawnColumnMoves)
                //    {
                //        foreach (int i in WhitepawnRowMoves)
                //        {

                //            if (((row + i < 0 || row + i > 7) || (column + j < 0 || column + j > 7)))
                //            {
                //                continue;
                //            }

                //            //Debug.WriteLine(i + " " + j);
                //            futureRow = row + i;
                //            futureColumn = column + j;

                //            ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                //        }
                //    }
                //}
                
                if (((row - 1 >= 0 && row - 1 <= 7) && (column - 1 >= 0 && column - 1 <= 7)))    
                {

                    if ((figureAttacked.Contains(param.Position[row - 1, column - 1]) || param.Position[row - 1, column - 1] == figureValue.BlackKing) || param.KingAttackCheck == true)
                    {
                        futureRow = row - 1;
                        futureColumn = column - 1;

                        if ((param.GlobalTurn == false && param.BlackKingInDanger == true) || (param.GlobalTurn == true && param.WhiteKingInDanger == true))
                        {

                            foreach (Tuple<int, int> square in param.KingAttackingLines)
                            {
                                int R = square.Item1;
                                int C = square.Item2;

                                if (futureRow == R && futureColumn == C)
                                {
                                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);
                                }
                            }

                        }
                        else if ((param.BlackKingInDanger == false && param.GlobalTurn == false) || (param.WhiteKingInDanger == false && param.GlobalTurn == true))
                        {

                            ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                        }


                        FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);

                    }


                }

                if (((row - 1 >= 0 && row - 1 <= 7) && (column + 1 >= 0 && column + 1 <= 7)))
                {
                    
                    if ((figureAttacked.Contains(param.Position[row - 1, column + 1]) || param.Position[row - 1, column + 1] == figureValue.BlackKing) || param.KingAttackCheck == true)
                    {
                        futureRow = row - 1;
                        futureColumn = column + 1;

                        if ((param.GlobalTurn == false && param.BlackKingInDanger == true) || (param.GlobalTurn == true && param.WhiteKingInDanger == true))
                        {

                            foreach (Tuple<int, int> square in param.KingAttackingLines)
                            {
                                int R = square.Item1;
                                int C = square.Item2;

                                if (futureRow == R && futureColumn == C)
                                {
                                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);
                                }
                            }

                        }
                        else if ((param.BlackKingInDanger == false && param.GlobalTurn == false) || (param.WhiteKingInDanger == false && param.GlobalTurn == true))
                        {

                            ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                        }


                        FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);

                    }
                }

            }

        }

    }

}

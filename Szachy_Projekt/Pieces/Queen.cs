﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy_Projekt.Pieces
{
    public class Queen : figureClass
    {

        protected override void LegalMoves(int row, int column, figureValue[] figureAttacked)
        {
            int futureRow = 0;
            int futureColumn = 0;

            int BreakLoop = 0;
            

            for (int i = row - 1, j = column - 1; i > -7 && j > -7; i--, j--)
            {
               

                if (((i < 0 || i > 7) || (j < 0 || j > 7)) || BreakLoop == 1)
                {
                    continue;
                }
                else if (param.Position[i, j] != figureValue.Empty)
                {
                    BreakLoop++;
                }

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

                if (param.KingAttackCheck == true)
                {

                    FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);

                }
                //}
            }

            BreakLoop = 0;

            for (int i = row + 1, j = column + 1; i < 8 && j < 8; i++, j++)
            {
                
             

                if (((i < 0 || i > 7) || (j < 0 || j > 7)) || BreakLoop == 1)
                {
                    continue;
                }
                else if (param.Position[i, j] != figureValue.Empty)
                {
                    BreakLoop++;
                }

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

                if (param.KingAttackCheck == true)
                {

                    FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);

                }

            }

            BreakLoop = 0;

          
            for (int i = row - 1, j = column + 1; i > -7 && j < 8; i--, j++)
            {
              

                if (((i < 0 || i > 7) || (j < 0 || j > 7)) || BreakLoop == 1)
                {
                    continue;
                }
                else if (param.Position[i, j] != figureValue.Empty)
                {
                    BreakLoop++;
                }

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

                if (param.KingAttackCheck == true)
                {

                    FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);

                }

            }

            BreakLoop = 0;

            for (int i = row + 1, j = column - 1; i < 8 && j > -7; i++, j--)
            {
               

                if (((i < 0 || i > 7) || (j < 0 || j > 7)) || BreakLoop == 1)
                {
                    continue;
                }
                else if (param.Position[i, j] != figureValue.Empty)
                {
                    BreakLoop++;
                }

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

            BreakLoop = 0;

            for (int i = row - 1, j = column; i > -7; i--)
            {

                if (((i < 0 || i > 7) || (j < 0 || j > 7)) || BreakLoop == 1)
                {
                    continue;
                }
                else if (param.Position[i, j] != figureValue.Empty)
                {
                    BreakLoop++;
                }

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

            BreakLoop = 0;

            for (int i = row + 1, j = column; i < 8; i++)
            {

                if (((i < 0 || i > 7) || (j < 0 || j > 7)) || BreakLoop == 1)
                {
                    continue;
                }
                else if (param.Position[i, j] != figureValue.Empty)
                {
                    BreakLoop++;
                }

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

            BreakLoop = 0;


            for (int i = row, j = column + 1; j < 8; j++)
            {

                if (((i < 0 || i > 7) || (j < 0 || j > 7)) || BreakLoop == 1)
                {
                    continue;
                }
                else if (param.Position[i, j] != figureValue.Empty)
                {
                    BreakLoop++;
                }

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

            BreakLoop = 0;

            for (int i = row, j = column - 1; j > -7; j--)
            {


                if (((i < 0 || i > 7) || (j < 0 || j > 7)) || BreakLoop == 2)
                {
                    continue;
                }
                else if (param.Position[i, j] != figureValue.Empty)
                {
                    BreakLoop++;
                }

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
    }
}

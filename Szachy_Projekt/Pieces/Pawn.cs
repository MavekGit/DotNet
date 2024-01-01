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

                if (row == 1 && param.KingAttackCheck == false)
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

                        ShowLegalMoves(futureRow, futureColumn, figureAttacked);


                    }

                }
                
                else if(row != 1 && param.KingAttackCheck == false)
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

                        ShowLegalMoves(futureRow, futureColumn, figureAttacked);


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
                    if (figureAttacked.Contains(param.Position[row + 1, column - 1]))
                    {
                        futureRow = row + 1;
                        futureColumn = column - 1;

                        ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                    }


                }
                if (((row + 1 >= 0 && row + 1 <= 7) && (column + 1 >= 0 && column + 1 <= 7)))
                {
                if (figureAttacked.Contains(param.Position[row + 1, column + 1]))

                    {
                        futureRow = row + 1;
                        futureColumn = column + 1;

                        ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                    }
                }


            }
            BreakLoop = 0;
            // White Pawn
            if (figureAttacked == param.BlackPiecesAttacked)
            {

                if (row == 6 && param.KingAttackCheck == false)
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

                        ShowLegalMoves(futureRow, futureColumn, figureAttacked);


                    }

                }
                else if(row != 6 && param.KingAttackCheck == false)
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

                        ShowLegalMoves(futureRow, futureColumn, figureAttacked);


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

                    if (figureAttacked.Contains(param.Position[row - 1, column - 1]))
                    {
                        futureRow = row - 1;
                        futureColumn = column - 1;

                        ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                    }


                }

                if (((row - 1 >= 0 && row - 1 <= 7) && (column + 1 >= 0 && column + 1 <= 7)))
                {
                    
                    if (figureAttacked.Contains(param.Position[row - 1, column + 1]))
                    {
                        futureRow = row - 1;
                        futureColumn = column + 1;

                        ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                    }
                }

            }

        }

    }

}

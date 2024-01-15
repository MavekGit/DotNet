using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy_Projekt.Pieces
{
    public class King : figureClass
    {
        protected override void LegalMoves(int row, int column, figureValue[] figureAttacked)
        {
            int futureRow = 0;
            int futureColumn = 0;
            int KingRow = 0;
            int KingColumn = 0;
            int[,] KingArea = new int[9,2];

            for (int i = 0; i < KingArea.GetLength(0); i++)
            {
                for (int j = 0; j < KingArea.GetLength(1); j++)
                {
                    KingArea[i, j] = -1;
                }
            }

            if (figureAttacked != param.BlackPiecesAttacked)
            {
                
                for(int i = 0;i<8;i++)
                {
                    for(int j = 0;j<8;j++)
                    {
                        if (param.Position[i,j] == figureValue.WhiteKing)
                        {
                            KingRow = i;
                            KingColumn = j;

                        }
                    }
                }

            }
            else if(figureAttacked != param.WhitePiecesAttacked)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (param.Position[i, j] == figureValue.BlackKing)
                        {
                            KingRow = i;
                            KingColumn = j;
                        }
                    }
                }
            }
            //Debug.WriteLine("----------------------------------");
            //Debug.WriteLine(KingRow + " " +  KingColumn);
            //Debug.WriteLine("----------------------------------");

            int[] kingMoves = { -1, 0, 1, };
            int iterator = 0;

            foreach (int i in kingMoves)
            {
                foreach (int j in kingMoves)
                {

                    if (((KingRow + i >= 0 && KingRow + i <= 7) && (KingColumn + j >= 0 && KingColumn + j <= 7)))
                    {

                        KingArea[iterator,0] = KingRow + i;
                        KingArea[iterator,1] = KingColumn + j;
                        iterator++;

                        //ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                    }


                }

            }

            //for (int i = 0; i < KingArea.GetLength(0); i++)
            //{
            //    Debug.WriteLine("");
            //    Debug.Write(KingArea[i, 0]);
                
            //    Debug.Write(KingArea[i, 1]);
            //    Debug.WriteLine("");

            //}

            //-------------------------------------------------//

            //int[] kingMoves = { -1, 0, 1, };

            foreach (int i in kingMoves)
            {
                foreach (int j in kingMoves)
                {
                    if ((i != 0 || j != 0) && (row + i >= 0 && row + i <= 7) && (column + j >= 0 && column + j <= 7))
                    {

                        Debug.WriteLine(i + " ::::::::::::::::::::::::::::::: " + j);
                        futureRow = row + i;
                        futureColumn = column + j;

                        bool isPositionValid = true;

                        for (int k = 0; k < KingArea.GetLength(0) && isPositionValid; k++)
                        {
                            if (futureRow == KingArea[k, 0] && futureColumn == KingArea[k, 1])
                            {
                                isPositionValid = false;
                            }
                        }

                        

                        if (param.SquaresInCheck.Any(square => futureRow == square.Item1 && futureColumn == square.Item2))
                        {
                            isPositionValid = false;
                        }

                        if (param.Position[row,column] == figureValue.BlackKing && param.BlackPieces.Contains(param.Position[futureRow,futureColumn]))
                        {
                            isPositionValid = false;
                        }
                        if (param.Position[row, column] == figureValue.WhiteKing && param.WhitePieces.Contains(param.Position[futureRow, futureColumn]))
                        {
                            isPositionValid = false;
                        }


                        if (isPositionValid)
                        {
                            ShowLegalMoves(futureRow, futureColumn, figureAttacked);
                            Debug.WriteLine("Dostępne ruchy króla: " + futureRow + " " + futureColumn);

                            if (param.KingLegalMovesCheck == true)
                            {
                                Debug.WriteLine("Dostępne ruchy króla: " + futureRow + " " + futureColumn);
                                param.KingLegalMovesAfterCheck.Add(new Tuple<int, int>(futureRow, futureColumn));
                            }

                        }
                    
                    }
                }
            }





        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Szachy_Projekt.Pieces
{
    public class Knight : figureClass
    {

        protected override void LegalMoves(int row, int column, figureValue[] figureAttacked)
        {
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

                 //   ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                    if((futureRow >= 0 && futureRow <= 7) && (futureColumn >= 0 && futureColumn <= 7))
                    {

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


                        //FiugreAttackKing(row, column, futureRow, futureColumn, figureAttacked);


                        if (param.Position[futureRow,futureColumn]  == figureValue.BlackKing && param.GlobalTurn == true  )
                        {
                        
                            param.KingAttackingLines.Add(new Tuple<int, int>(row, column));

                        }
                        else if (param.Position[futureRow, futureColumn] == figureValue.WhiteKing && param.GlobalTurn == false)
                        {
                            param.KingAttackingLines.Add(new Tuple<int, int>(row, column));
                        }

                    }

                }

            }

        }


        // TODO
        // DLA SKOCZKA i PIONKA KING ATTACK LINES MUSI BYĆ INACZEJ ZAMIAST FOR PO PROSTU ZWRACAM POZYCJE FIGURY
        // 








        //public void BlackKnightMove(int row, int column, Button button)
        //{
        //    //figureValue[] blackPiecesAttacked = new figureValue[] { figureValue.BlackPawn,figureValue.BlackRook, figureValue.BlackKnight, figureValue.BlackBishop, figureValue.BlackQueen};
        //    //figureValue[] whitePiecesAttacked = new figureValue[] { figureValue.WhitePawn,figureValue.WhiteRook, figureValue.WhiteKnight, figureValue.WhiteBishop, figureValue.WhiteQueen};




        //    if (param.FirstClick == null && param.Position[row, column] == figureValue.BlackKnight)
        //    {

        //        HelpMoveClear();

        //        param.FirstClick = button;
        //        param.CurrentRow = row;
        //        param.CurrentColumn = column;


        //        // BlackKnightCheck = true;
        //        int futureRow = 0;
        //        int futureColumn = 0;

        //        int[] knightMoves = { -2, -1, 1, 2 };

        //        foreach (int i in knightMoves)
        //        {
        //            foreach (int j in knightMoves)
        //            {

        //                if (Math.Abs(i) + Math.Abs(j) != 3)
        //                {
        //                    continue;
        //                }

        //                futureRow = row + i;
        //                futureColumn = column + j;


        //                if ((futureRow >= 0 && futureRow < 8 && futureColumn >= 0 && futureColumn < 8) && param.Position[futureRow, futureColumn] == figureValue.Empty)
        //                {
        //                    param.Buttons[futureRow, futureColumn].Content = new System.Windows.Controls.Image { Source = Images.Dot };

        //                }
        //                else if (((futureRow >= 0 && futureRow < 8 && futureColumn >= 0 && futureColumn < 8)) && param.WhitePiecesAttacked.Contains(param.Position[futureRow, futureColumn]))
        //                {
        //                    param.Buttons[futureRow, futureColumn].Background = Brushes.Red;
        //                }
        //            }
        //        }

        //    }
        //    else if ((param.FirstClick != null) && (param.SecondClick == null) && ((param.Buttons[row, column].Content is System.Windows.Controls.Image image && image.Source == Images.Dot || (param.WhitePiecesAttacked.Contains(param.Position[row, column])))))
        //    {

        //        param.SecondClick = button;

        //        param.Buttons[param.CurrentRow, param.CurrentColumn].Content = "";
        //        param.Buttons[row, column].Content = new System.Windows.Controls.Image { Source = Images.BlackKnight }; ;
        //        param.Position[row, column] = figureValue.BlackKnight;
        //        param.Position[param.CurrentRow, param.CurrentColumn] = 0;

        //        param.FirstClick = null;
        //        param.SecondClick = null;
        //        // BlackKnightCheck = false;
        //        // GlobalTurn = true;


        //        HelpMoveClear();

        //    }
        //    else
        //    {
        //        param.FirstClick = null;
        //        param.SecondClick = null;
        //        // BlackKnightCheck = false;


        //        HelpMoveClear();

        //    }

        //}


    }
}
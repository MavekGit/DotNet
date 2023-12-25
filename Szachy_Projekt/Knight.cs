using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Szachy_Projekt
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

                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                }

            }
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
}
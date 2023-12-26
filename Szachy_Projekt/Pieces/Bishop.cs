using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Szachy_Projekt.Pieces
{
    public class Bishop : figureClass
    {

        protected override void LegalMoves(int row, int column, figureValue[] figureAttacked)
        {
            int futureRow = 0;
            int futureColumn = 0;
            
            int BreakLoop = 0;
            //Debug.WriteLine("ROW " + row + "  COLUMN " + column);

            for(int i = row, j = column; i > -7 && j > -7; i--,j--)
            {
                //for(int j = column; j > -7; j--)
                //{
                //Debug.WriteLine(row+i);
                //Debug.WriteLine(column + j);

                if (((i < 0 || i > 7) || (j < 0 || j > 7)) || BreakLoop == 2)
                {
                    continue;
                }
                else if (param.Position[i, j] != figureValue.Empty)
                {
                    BreakLoop++;
                }

                    futureRow =  i;
                    futureColumn = j;

                   // Debug.WriteLine(futureRow + " " + futureColumn);

                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                //}
            }

            BreakLoop = 0;

            for (int i = row, j = column; i < 8 && j < 8; i++, j++)
            {
                //Debug.WriteLine(row + " " + i);
                //Debug.WriteLine(column + " " + j);

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

                // Debug.WriteLine(futureRow + " " + futureColumn);

                ShowLegalMoves(futureRow, futureColumn, figureAttacked);


            }

            BreakLoop = 0;

            // 7 2
            for (int i = row, j = column; i > -7 && j < 8; i--, j++)
            {
                //Debug.WriteLine(i);
                //Debug.WriteLine(j);
                //Debug.WriteLine("BREAK LOOP" + " " + BreakLoop);

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

                //Debug.WriteLine(param.Position[row + i, column + j]);
                //Debug.WriteLine("---------------------");
                //Debug.WriteLine(futureRow + " " + futureColumn);

                ShowLegalMoves(futureRow, futureColumn, figureAttacked);


            }

            BreakLoop = 0;

            for (int i = row, j = column; i < 8 && j > -7; i++, j--)
            {
                //Debug.WriteLine(row + " " + i);
                //Debug.WriteLine(column + " " + j);
                //Debug.WriteLine("BREAK LOOP" + " " + BreakLoop);


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

                //Debug.WriteLine(futureRow + " " + futureColumn);

                ShowLegalMoves(futureRow, futureColumn, figureAttacked);


            }


        }

    }
}

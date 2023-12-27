using System;
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
            

            for (int i = row, j = column; i > -7 && j > -7; i--, j--)
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

              

                ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                //}
            }

            BreakLoop = 0;

            for (int i = row, j = column; i < 8 && j < 8; i++, j++)
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

               

                ShowLegalMoves(futureRow, futureColumn, figureAttacked);


            }

            BreakLoop = 0;

          
            for (int i = row, j = column; i > -7 && j < 8; i--, j++)
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


                ShowLegalMoves(futureRow, futureColumn, figureAttacked);


            }

            BreakLoop = 0;

            for (int i = row, j = column; i < 8 && j > -7; i++, j--)
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

                ShowLegalMoves(futureRow, futureColumn, figureAttacked);


            }

            BreakLoop = 0;

            for (int i = row, j = column; i > -7; i--)
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



                ShowLegalMoves(futureRow, futureColumn, figureAttacked);


            }

            BreakLoop = 0;

            for (int i = row, j = column; i < 8; i++)
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

                ShowLegalMoves(futureRow, futureColumn, figureAttacked);


            }

            BreakLoop = 0;


            for (int i = row, j = column; j < 8; j++)
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

                ShowLegalMoves(futureRow, futureColumn, figureAttacked);


            }

            BreakLoop = 0;

            for (int i = row, j = column; j > -7; j--)
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


                ShowLegalMoves(futureRow, futureColumn, figureAttacked);


            }


        }
    }
}

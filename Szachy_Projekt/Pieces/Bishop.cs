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

            for(int i = -7; i< 8; i++)
            {
                for(int j = -7; j < 8; j++)
                {
                    if(Math.Abs(i) != Math.Abs(j) && ((row + i >=0 && row + i <= 7) && (column + j >= 0 && column + j <= 7)))
                    {
                        continue;
                    }

                    futureRow = row + i;
                    futureColumn = column + j;

                    ShowLegalMoves(futureRow, futureColumn, figureAttacked);

                }
            }
            
        }

    }
}

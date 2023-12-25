using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

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
        }
       
        public void FigureMove(int row, int column, Button button, figureValue figure, ImageSource figureImage ,figureValue[] figureAttacked)
        {

            {

                if (param.FirstClick == null && param.Position[row, column] == figure)
                {

                    HelpMoveClear();

                    param.FirstClick = button;
                    param.CurrentRow = row;
                    param.CurrentColumn = column;
                    

                    LegalMoves(row, column, figureAttacked);

                }

                
                else if ((param.FirstClick != null) && (param.SecondClick == null) && ((param.Buttons[row, column].Content is System.Windows.Controls.Image image && image.Source == Images.Dot || param.Buttons[row, column].Background == Brushes.Red )))
                {

                    param.SecondClick = button;

                    param.Buttons[param.CurrentRow, param.CurrentColumn].Content = "";
                    param.Buttons[row, column].Content = new System.Windows.Controls.Image { Source = figureImage }; ;
                    param.Position[row, column] = figure;
                    param.Position[param.CurrentRow, param.CurrentColumn] = 0;

                    param.FirstClick = null;
                    param.SecondClick = null;
                    
                    HelpMoveClear();

                    if(param.BlackPieces.Contains(figure))
                    {
                        param.GlobalTurn = true;
                    }
                    else if(param.WhitePieces.Contains(figure))
                    {
                        param.GlobalTurn = false;
                    }

                }
                else
                {
                    param.FirstClick = null;
                    param.SecondClick = null;

                    HelpMoveClear();

                }

            }


        }



    }
}

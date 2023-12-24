using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Szachy_Projekt
{
    public static class Images
    {

        public readonly static ImageSource Dot = LoadImage("dot.png");
        public readonly static ImageSource BlackBishop = LoadImage("BBishop.png");
        public readonly static ImageSource WhiteBishop = LoadImage("WBishop.png");
        public readonly static ImageSource WhiteKnight = LoadImage("WKnight.png");
        public readonly static ImageSource BlackKnight = LoadImage("BKnight.png");
        public readonly static ImageSource WhiteKing = LoadImage("WKing.png");
        public readonly static ImageSource BlackKing = LoadImage("BKing.png");
        public readonly static ImageSource WhitePawn = LoadImage("WPawn.png");
        public readonly static ImageSource BlackPawn = LoadImage("BPawn.png");
        public readonly static ImageSource WhiteRook = LoadImage("WRook.png");
        public readonly static ImageSource BlackRook = LoadImage("BRook.png");
        public readonly static ImageSource WhiteQueen = LoadImage("WQueen.png");
        public readonly static ImageSource BlackQueen = LoadImage("BQueen.png");




        public static ImageSource LoadImage(string fileName)
        {

            return new BitmapImage(new Uri($"Assets/{fileName}", UriKind.Relative));

        }

    }
}

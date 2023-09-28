using _4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _5
{
    internal class FigureControle:Figure
    {

        public void WriteAllFigures(Figure[] figures) { 
            foreach (Figure f in figures)
            {
                Console.WriteLine(f.ToString());
            }
        }

        public int getLength(Figure[] figures) { 
            return figures.Length;
        }

        public int calculateSqureOfFigures(Figure[] figures) {
            int totalSquare = 1;
            foreach (Figure f in figures)
            {
                totalSquare = f.X * f.Y;
            }

            return totalSquare;
        }

    }
}

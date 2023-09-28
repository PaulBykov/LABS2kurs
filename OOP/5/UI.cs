using _4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    internal class UI
    {
        Figure[] figures;

        public void addFigure(Figure figure) { 
            figures.Append(figure);
        }

        public void RemoveAt(int index)
        {
            this.figures =  this.figures.Where((_, i) => i != index).ToArray();
        }

        internal Figure[] Figures { get => figures; set => figures = value; }
    }
}

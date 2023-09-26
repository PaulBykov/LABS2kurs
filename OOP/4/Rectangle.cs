using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    internal class Rectangle:Figure, IFiguresInterface
    {
        private int width;
        private int height;

        Rectangle(int width, int height)
        {   
            this.width = width;
            this.height = height;
        }

        public void input(int x, int y) { 
            this.X = x;
            this.Y = y;
        }

        public void resize(int width, int height) { 
            this.width = width;
            this.height = height;
        }


        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
    }
}

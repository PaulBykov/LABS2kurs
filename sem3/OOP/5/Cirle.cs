using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    internal class Cirle: Figure, IFiguresInterface
    {
        private int radious;

        public void input(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void resize(int radious)
        {   
            this.radious = radious;
        }

        public Cirle(int rad)
        {
            this.Radious = rad;
        }

        public Cirle(int rad, int x, int y)
        {
            this.Radious = rad;
            this.X = x;
            this.Y = y;
        }

        public int Radious { get => radious; set => radious = value; }
    }
}

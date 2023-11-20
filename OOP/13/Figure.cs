using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    [Serializable]
    abstract class Figure:IFiguresInterface
    {
        private int x;
        private int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }


        public void show()
        {
            Console.WriteLine($"{this.X} {this.Y}");
        }


    }
}

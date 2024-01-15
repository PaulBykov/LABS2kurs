using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace _8
{
    public class User
    {
        private int coord;
        private int size;

        public delegate void MovedHandler(int x);
        public event MovedHandler Move;
        private protected void changed(int x)
        {
            Console.WriteLine(x);
        }


        public delegate void CompressedHandler(int x);
        public event CompressedHandler Compress;


        public void Forward(int step)
        {
            coord += step;
            Move?.Invoke(coord);
        }
        public void Backwards(int step)
        {
            coord -= step;
            Move?.Invoke(coord);
        }

        public void Squeze(int Coefficient)
        {
            Size *= Coefficient;
            Compress?.Invoke(Size);
        }

        public int Coord { get => coord; private set => coord = value; }
        public int Size { get => size; private set => size = value; }

        public User()
        {
            this.size = 1;
            this.coord = 0;
        }
    }
}

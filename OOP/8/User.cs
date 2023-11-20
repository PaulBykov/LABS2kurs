using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    public class User
    {
        public event Action<double> MoveEvent;
        public event Action<double> CompressEvent;

        public double Coords { get; private set; }

        public User(double initialCoords)
        {
            Coords = initialCoords;
        }

        public void Move(double offset)
        {
            Coords += offset;
            MoveEvent?.Invoke(Coords);
        }

        public void Compress(double ratio)
        {
            Coords *= ratio;
            CompressEvent?.Invoke(Coords);
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class Calculator : ICalculatable
    {
        private readonly TextBox LinkedField;

        private double _value;
        private double _memory;

        public delegate void ValueHandler(double newVal);
        public event ValueHandler? ValueChange;


        public Calculator(object TBox) {
            _value = 0;
            Memory = 0;
            LinkedField = (TextBox) TBox;
        }

        public double Value { get => _value; set => _value = value; }
        public double Memory { get => _memory; set => _memory = value; }


        public void Notify() {
            ValueChange?.Invoke(Value);
        }


        public void Memorize() {
            _memory = _value;
        }

        public void Paste() { 
            _value = _memory;
            Notify();
        }

        public void Reset()
        {
            _value = 0;
            Notify();
        }



        public void Sin() 
        { 
            _value = Math.Sin(_value);
            Notify();
        }

        public void Cos()
        {
            _value = Math.Cos(_value);
            Notify();
        }

        public void Tan()
        {
            _value = Math.Tan(_value);
            Notify();
        }

        public void Ctg()
        {
            _value = Math.Cos(_value);
            Notify();
        }

        public void Sqrt() 
        {
            _value = Math.Sqrt(Value); 
            Notify();    
        }

        public void Cbrt() 
        { 
            _value = Math.Cbrt(_value);
            Notify();
        }

        public void Cube() 
        {
            _value = Math.Pow(_value, 3);
            Notify();
        }
        public void Square() 
        {
            _value = Math.Pow(_value, 2);
            Notify();
        }

    }




}

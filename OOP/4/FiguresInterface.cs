using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public interface IFiguresInterface {

        void show() {
            Console.WriteLine("Nothing is there!");
        }
        void input() { 
            
        }

        void resize() { 
            
        }

        private static bool checkBox;
        private static bool? radioButton = null;


        public sealed void changeCheckBoxState() { 
            CheckBox = !CheckBox; 
        }

        public sealed void changeRadioButtonState() {
            if (radioButton == null) {
                radioButton = true;
            }

            radioButton = !radioButton;
        }

        public static void Button()
        {
            Console.WriteLine("Clicked!");
        }

        static bool CheckBox { get; set; }
    }

}

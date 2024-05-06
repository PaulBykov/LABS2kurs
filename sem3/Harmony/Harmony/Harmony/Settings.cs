using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony
{
    public static class Settings
    {
        private static Color mainThemeColor = Color.FromArgb(44, 44, 44);    
        private static Color secondThemeColor = Color.FromArgb(55, 55, 55);
        private static Color thirdThemeColor = Color.FromArgb(200, 30, 215); // purple
        private static Color fourthThemeColor = Color.FromArgb(0, 0, 0);

        private static Color activeButtonColor = Color.FromArgb(255, 200, 240);
        private static Color notActiveButtonColor = Color.FromArgb(255, 255, 255);


        public static Color MainThemeColor { get => mainThemeColor; set => mainThemeColor = value; }
        public static Color SecondThemeColor { get => secondThemeColor; set => secondThemeColor = value; }
        public static Color ThirdThemeColor { get => thirdThemeColor; set => thirdThemeColor = value; }
        public static Color FourthThemeColor { get => fourthThemeColor; set => fourthThemeColor = value; }
        public static Color ActiveButtonColor { get => activeButtonColor; set => activeButtonColor = value; }
        public static Color NotActiveButtonColor { get => notActiveButtonColor; set => notActiveButtonColor = value; }
    }
}

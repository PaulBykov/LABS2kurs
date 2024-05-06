using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    internal class BPADirInfo
    {
        public static void GetDirInfo()
        {
            string path = Path.GetFullPath(@"D:\LABS2\OOP\12");
            string DirInfoLog = "";

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (dirInfo.Exists)
                DirInfoLog = "\n=========================================   BPADirInfo   =================================================\n" +
                             "\nКоличество файлов:        " + dirInfo.GetFiles().Length +
                             "\nВремя создания:           " + dirInfo.LastWriteTime +
                             "\nКол-во поддиректориев:    " + dirInfo.GetDirectories().Length +
                             "\nРодительский директорий:  " + dirInfo.Parent.Name;

            BPALog.WriteInLog(DirInfoLog);
        }
    }
}

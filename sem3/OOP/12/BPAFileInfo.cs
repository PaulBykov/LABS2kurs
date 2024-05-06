using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    internal class BPAFileInfo
    {
        public static void GetFileInfo()
        {
            string path = Path.GetFullPath(@"D:\LABS2\OOP\12\BPALog.txt");
            string classLogInfo = "\n=========================================   BPAFileInfo   ================================================\n";
            string fileInfoLog = "";

            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
                fileInfoLog = classLogInfo +
                              "\nПолный путь:              " + path +
                              "\nИмя файла:                " + fileInfo.Name +
                              "\nРазмер файла:             " + fileInfo.Length / 1024 + " MB" +
                              "\nРасширение:               " + fileInfo.Extension +
                              "\nДата изменения:           " + fileInfo.LastWriteTime;

            BPALog.WriteInLog(fileInfoLog);
        }

    }
}

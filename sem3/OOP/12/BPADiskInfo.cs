using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    internal class BPADiskInfo
    {
        public static void GetDiskInfo()
        {
            string classLogInfo = "\n=========================================   BPADiskInfo   ================================================\n";   /// инфа для логгера
            string DiskInfo = "";                           /// сюда будет записываться вся информация из метода GetDrives()

            DriveInfo[] drives = DriveInfo.GetDrives();     /// массив объектов типа DriveInfo с инфой о дисках

            long sumOfSizes = 0;

            foreach (var drive in drives) {
                sumOfSizes += drive.TotalSize;
                DiskInfo += "\nИмя диска:                " + drive.Name +
                       "\nФайловая система:         " + drive.DriveFormat +
                       "\nДоступное место:          " + drive.AvailableFreeSpace / 1024 / 1024 / 1024 + " GB" +
                       "\nРазмер диска:             " + drive.TotalSize / 1024 / 1024 / 1024 + " GB" +
                       "\nМетка тома диска:         " + drive.VolumeLabel + "\n\n";
            }

            Console.WriteLine("Суммарный вес всех дисков = " + sumOfSizes / 1024 / 1024 / 1024 + " GB");

            string DiskInfoLog = classLogInfo + DiskInfo;

            BPALog.WriteInLog(DiskInfoLog);
        }
    }
}

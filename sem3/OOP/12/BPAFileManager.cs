using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    internal class BPAFileManager
    {
        public static void BPAInspect()
        {
            string classLogInfo = "\n=======================================   BPAFileManager   ===============================================\n";            /// инфа для логгера
            string inspectLog = "";

            DriveInfo[] drives = DriveInfo.GetDrives();                 
            string inspectPath = drives[1].Name;                        
            DirectoryInfo directory = new DirectoryInfo(@"D:\Lab13");   

            directory.Create();                                         /// создаем субдерикторий D:\Lab13\BPAInspect
            directory.CreateSubdirectory(@"BPAInspect");

            DirectoryInfo BPAInspectFiles = new DirectoryInfo(Path.GetFullPath(@"D:\Lab13\BPAInspect\BPAFiles"));
            if (BPAInspectFiles.Exists)
                BPAInspectFiles.Delete(true);

            string filePath = Path.GetFullPath(@"D:\Lab13\BPAInspect\BPAdirinfo.txt");
            FileInfo fileInfo = new FileInfo(filePath);                 
            using (StreamWriter sw = fileInfo.CreateText())             /// создаем файл и сразу пишем поток
            {
                sw.WriteLine("Шиман представитель не традиционной сексуальной ориентации");
            }


            string renamePath = Path.GetFullPath(@"D:\Lab13\BPAInspect\BPAdirinfoRENAMED.txt");
            FileInfo renameBuf = new FileInfo(renamePath);              /// буфер чтобы удалить созданный ранее RENAMED
            renameBuf.Delete();

            fileInfo.CopyTo(renamePath);
            fileInfo.Delete();


            DirectoryInfo inspectDirInfo = new DirectoryInfo(Path.GetFullPath(@"D:\Lab13\BPAInspect"));
            string files = "";
            for (int i = 0; i < inspectDirInfo.GetFiles().Length; i++)
                files += inspectDirInfo.GetFiles()[i].Name + "; ";          /// имена всех файлов записываем в строку

            string directories = "";
            for (int i = 0; i < inspectDirInfo.GetDirectories().Length; i++)
                directories += inspectDirInfo.GetDirectories()[i];          /// имена всех директориев

            if (inspectDirInfo.Exists)
                inspectLog = classLogInfo +
                             "\nФайлы:                    " + files +
                             "\nПоддиректории:            " + directories +
                             "\nРодительский директорий:  " + inspectDirInfo.Parent.Name +
                             "\n\n==========================================================================================================";


            BPALog.WriteInLog(inspectLog);
        }

        public static void BPAFiles()
        {
            string rootDrivePath = Path.GetFullPath(@"D:\");
            string BPAFilesPath = Path.GetFullPath(rootDrivePath + @"Lab13\BPAFiles");
            string BPAInspectFilesPath = Path.GetFullPath(rootDrivePath + @"Lab13\BPAInspect\BPAFiles");
            string BPAUnzipPath = Path.GetFullPath(rootDrivePath + @"Lab13\BPAInspect\BPAUnzip");
            string musicPath = Path.GetFullPath(rootDrivePath + @"Lab13\Music");
            string ZIPPath = Path.GetFullPath(rootDrivePath + @"Lab13\BPAInspect\BPAFiles.zip");


            DirectoryInfo BPAFiles = new DirectoryInfo(BPAFilesPath);                        /// создать BPAFIles
            DirectoryInfo BPAInspectFiles = new DirectoryInfo(BPAInspectFilesPath);          /// создать Inspect\Files
            DirectoryInfo BPAUnzip = new DirectoryInfo(BPAUnzipPath);

            if (!BPAFiles.Exists)                                                            /// если нет папки Files,
                BPAFiles.Create();                                                           /// то создаем ее, а хуле

            if (BPAUnzip.Exists)
                BPAUnzip.Delete(true);

            if (File.Exists(ZIPPath))
                File.Delete(ZIPPath);


            DirectoryInfo musicDirInfo = new DirectoryInfo(musicPath);                       /// путь к Music 
            FileInfo[] filesMusic = musicDirInfo.GetFiles();                                 /// получить все файлы из Music
            foreach (FileInfo file in filesMusic)
                if (file.Extension == ".mp3")
                    file.CopyTo(Path.Combine(BPAFilesPath.ToString(), file.Name), true);     /// скопировать все .mp3 в BPAFiles

            if (BPAInspectFiles.Exists)                                                      /// если есть Inspect\Files,
                BPAInspectFiles.Delete(true);                                                /// то он нам нахуй не нужен
            if (BPAFiles.Exists)
                BPAFiles.MoveTo(BPAInspectFilesPath);                                        /// перемещаем в Inspect\Files
        }

        public static void MakeArchive()
        {
            string lab13Path = Path.GetFullPath(@"D:\Lab13\");
            string BPAFilesPath = Path.GetFullPath(lab13Path + @"BPAFiles");
            string BPAInspectFilesPath = Path.GetFullPath(lab13Path + @"BPAInspect");
            string BPAInspectUnzipPath = Path.GetFullPath(lab13Path + @"BPAUnzip");
            string ZIPPath = Path.GetFullPath(lab13Path + @"BPAFiles.zip");


         
            DirectoryInfo BPAFiles = new DirectoryInfo(BPAFilesPath);
            
            FileInfo ZIPFile = new FileInfo(ZIPPath);
            if (ZIPFile.Exists) { 
                ZIPFile.Delete();
            }

            ZipFile.CreateFromDirectory(BPAInspectFilesPath, ZIPPath);                      /// архивируем


            
            ZipFile.ExtractToDirectory(ZIPPath, BPAInspectUnzipPath);

        }
    }
}

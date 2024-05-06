
namespace _12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BPALog.WriteLogInfo();
                BPADiskInfo.GetDiskInfo();
                
                BPADirInfo.GetDirInfo();
                BPAFileInfo.GetFileInfo();

                BPAFileManager.BPAFiles();
                BPAFileManager.BPAInspect();
                BPAFileManager.MakeArchive();

                BPALog.ReadLog();
                BPALog.SearchLog();
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine("Ошибка! Директорий не найден.\n" + e.Message);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Ошибка! Файл уже существует или используется другим процессом.\n" +
                                  e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Непредвиденная ошибка!\n" + e.Message);
            }
        }

    }
}
using System.Diagnostics;
using System.Reflection;

namespace _14
{
    internal class Program
    {

        static void GetProcessList()
        {
            Process[] processes = Process.GetProcesses();

            Console.WriteLine("Список запущенных процессов:");

            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine("ID" + "\t\t" + "Имя" + "\t" + "Приоритет" + "\t"
                              + "Время запуска" + "\t" + "Текущее состояние" + "\t" + "Время CPU");

            Console.WriteLine("-----------------------------------------------------------------");


            foreach (Process process in processes)
            {
                try
                {
                    Console.WriteLine(process.Id + "\t\t" + process.ProcessName + "\t" + process.BasePriority + "\t" +
                                      process.StartTime + "\t\t" + (process.Responding ? "Работает" : "Не отвечает") + "\t" +
                                      process.TotalProcessorTime);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при получении информации: " + ex.Message);
                }
            }

            Console.WriteLine("-----------------------------------------------------------------");


        }

        static void GetDomainInfo() {
            // Получение информации о текущем домене приложения
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("Текущий домен приложения:");
            Console.WriteLine("Имя домена: " + currentDomain.FriendlyName);
            Console.WriteLine("Конфигурационные детали домена: " + currentDomain.SetupInformation);

            Assembly[] assemblies = currentDomain.GetAssemblies();
            Console.WriteLine("\nСборки, загруженные в текущий домен:");
            foreach (Assembly assembly in assemblies)
            {
                Console.WriteLine(assembly.FullName);
            }

            AppDomain newDomain = AppDomain.CreateDomain("Новый домен");

            try
            {
                // Загрузка сборки в новый домен
                string assemblyPath = "D:/LABS2/OOP/14/bin/Debug/net7.0/14.dll"; // Укажите путь к сборке
                newDomain.Load(AssemblyName.GetAssemblyName(assemblyPath));

                Console.WriteLine("\nСборка успешно загружена в новый домен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при загрузке сборки: " + ex.Message);
            }
            finally
            {
                AppDomain.Unload(newDomain);
                Console.WriteLine("\nНовый домен выгружен.");
            }
        }

        private static bool running = false;
        static void CalculatePrimeNumbers() {
            Console.WriteLine("Введите значение n для нахождения простых чисел от 1 до n:");
            int n = Convert.ToInt32(Console.ReadLine());

            Thread primeThread = new Thread(() => GetPrimes(n));
            primeThread.Name = "Поток поиска простых чисел";
            primeThread.Priority = ThreadPriority.Normal;

            Console.WriteLine("Статус потока: " + primeThread.ThreadState);
            Console.WriteLine("Имя потока: " + primeThread.Name);
            Console.WriteLine("Приоритет потока: " + primeThread.Priority);
            Console.WriteLine("Идентификатор потока: " + primeThread.ManagedThreadId);

            primeThread.Start();

            running = true;

            Console.WriteLine("Поток запущен.");

            while (running)
            {
                Console.WriteLine("Введите команду (pause/resume/stop):");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "pause":
                        primeThread.Suspend();
                        Console.WriteLine("Поток приостановлен.");
                        break;
                    case "resume":
                        primeThread.Resume();
                        Console.WriteLine("Поток возобновлен.");
                        break;
                    case "stop":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            }

            primeThread.Join();
            Console.WriteLine("Поток завершил свою работу.");
        }

        static void GetPrimes(int n) {
            string filePath = "prime_numbers.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 2; i <= n; i++)
                {
                    bool isPrime = true;
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        Console.WriteLine(i);
                        writer.WriteLine(i);
                        Thread.Sleep(100); // Задержка для наглядности
                    }
                }
            }
        }

        static AutoResetEvent a = new AutoResetEvent(false);
        static void PrintNumbers(int n, int from = 0) {
            for (int i = from; i < n; i+=2) {
                a.Set();
                a.WaitOne();
                Console.WriteLine(i);
            }
        }

        static void PrintAllTheNumbers() {
            int n;
            Console.WriteLine("Введите n: ");
            n = Convert.ToInt32(Console.ReadLine());

            ThreadPool.SetMaxThreads(4, 4);

            Thread threadEven = new Thread(() => PrintNumbers(n));
            Thread threadNotEven = new Thread(() => PrintNumbers(n, 1));
            
            threadEven.Priority = ThreadPriority.BelowNormal;
            threadNotEven.Priority = ThreadPriority.Highest;


            threadEven.Start();
            threadNotEven.Start();
        }

        static void ActivateTime() {
            var timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            Console.WriteLine("Задача запущена. Нажмите Enter для завершения.");
            Console.ReadLine();

            // Остановка таймера
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            timer.Dispose();

            Console.WriteLine("Задача завершена.");
        }

        static void TimerCallback(object state)
        {
            Console.WriteLine("Текущее время: " + DateTime.Now);
        }

        static void Main(string[] args)
        {

            //GetProcessList();

            //GetDomainInfo();

            //CalculatePrimeNumbers();

            //PrintAllTheNumbers();

            ActivateTime();

        }
    }
}
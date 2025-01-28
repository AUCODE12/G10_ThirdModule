
namespace ConsoleApp1;

internal class Program
{
    private static Object obj = new Object();

    #region gpt1
    /*private static Object obj = new Object();
    private static readonly ThreadLocal<Random> threadRandom =
        new(() => new Random());*/
    #endregion 

    static void Main(string[] args)
    {
        Gpt5();
    }


    #region gpt5

    public static void Gpt5()
    {
        var filePath = @"C:\Users\user\Downloads\Telegram Desktop\afsona 1080p (uzmedia.net).mp4";
        for (int i = 0; i < 3; i++)
        {
            var myThread = new Thread(() => WorkerGpt5(filePath));
        }
    }

    private static void WorkerGpt5(string filePath)
    {

        var fileInfo = new FileInfo(filePath);
        var fileLength = fileInfo.Length;
        var bytes = 1024 * 1024 * 100;
        byte[] buffer = new byte[bytes];
        int bytesRead;

        //var bytesPercent = bytes * 100d / fileLength;
        //var percent = bytesPercent;

        var filePart = "Part";
        var fileExtension = ".mp4";
        var fullFilePath = string.Empty;
        var parent = Directory.GetCurrentDirectory();

        for (var i = 0; i < 3; i++)
        {
            fullFilePath = Path.Combine(parent, $"{filePart}{i + 1}{fileExtension}");
            using (FileStream fileStreamPath = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fileDestination = new FileStream(fullFilePath, FileMode.Create, FileAccess.Write))
                {
                    while (true)
                    {
                        //Console.WriteLine($"{(int)percent} %");
                        //percent += bytesPercent;
                        bytesRead = fileStreamPath.Read(buffer, 0, buffer.Length);
                        if (bytesRead <= 0) break;
                        fileDestination.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
    #endregion


    #region gpt10
    public static void Gpt10()
    {
        var path = @"D:\Projects\G10_ThirdModule\3.7\ConsoleApp1\ConsoleApp1\files";
        var files = Directory.GetFiles(path);

        foreach (var file in files)
        {
            var myThread = new Thread(() => WorkerGpt10(file));
            myThread.Start();
        }
    }
    public static void WorkerGpt10(string file)
    {
        var fileInfo = new FileInfo(file);
        Console.WriteLine($"File Name: {fileInfo.Name}, Size: {fileInfo.Length}");
    }
    #endregion

    #region gpt2
    public static void Gpt2()
    {
        var gpt1 = @"D:\Projects\G10_ThirdModule\3.7\ConsoleApp1\ConsoleApp1\gpt2";
        if (!Directory.Exists(gpt1))
        {
            Directory.CreateDirectory(gpt1);
        }
        var filePath = "File";
        var fileExtension = ".txt";
        var fullFilePath = string.Empty;

        for (var i = 0; i < 3;  i++)
        {
            fullFilePath = Path.Combine(gpt1, $"{filePath}{i + 1}{fileExtension}");
            if (!File.Exists(fullFilePath)) File.WriteAllText(fullFilePath, "asddkbjkjsjbfkajbfjkabfkjab");

            var myThread = new Thread(() => MargedFiles(fullFilePath));
            myThread.Start();
            myThread.Join();
        }
    }
    private static void MargedFiles(string fullFilePath)
    {
        lock (obj)
        {
            var gpt1 = @"D:\Projects\G10_ThirdModule\3.7\ConsoleApp1\ConsoleApp1\gpt2";
            var margedFilePath = Path.Combine(gpt1, "MargedFile.txt");
            using (StreamReader sr = new StreamReader(fullFilePath))
            {
                using (StreamWriter sw = new StreamWriter(margedFilePath, true))
                {
                    sw.Write(sr.ReadToEnd());
                }
            }
        }
    }
    #endregion

    #region gpt1
    public static void Gpt1()
    {
        var gpt1 = @"D:\Projects\G10_ThirdModule\3.7\ConsoleApp1\ConsoleApp1\gpt1";
        if (!Directory.Exists(gpt1))
        {
            Directory.CreateDirectory(gpt1);
        }
        var filePath = "Thread";
        var fileExtension = ".txt";
        var fullFilePath = string.Empty;
        //var threads = new List<Thread>();

        for (int i = 0; i < 5; i++)
        {
            fullFilePath = Path.Combine(gpt1, $"{filePath}{i + 1}{fileExtension}");
            var thread = new Thread(() => RandomNumsWriteFile(fullFilePath));
            //threads.Add(thread);
            thread.Start();
            thread.Join();
        }

        //foreach (var thread in threads)
        //{
        //    thread.Join();
        //}
    }
    private static void RandomNumsWriteFile(string fullFilePath)
    {
        //var random = threadRandom.Value;
        Random random = new Random();
        lock (obj)
        {
            using (StreamWriter sw = new StreamWriter(fullFilePath))
            {
                for (int i = 1; i <= 100; i++)
                {
                    sw.Write(random.Next(1, 101) + " ");
                }
            }
        }
    }
    #endregion
}

























#region kk
//var directory = @"D:\Projects\G10_ThirdModule\3.7\ConsoleApp1\ConsoleApp1\files";
//var files = Directory.GetFiles(directory);

//foreach (var file in files)
//{
//    if (file.Contains("result")) continue;
//    var myThreah = new Thread(() => Worker(file));
//    myThreah.Start();
//}
//public static Object obj = new Object();
//public static void Worker(string filePath)
//{
//    var result = @"D:\Projects\G10_ThirdModule\3.7\ConsoleApp1\ConsoleApp1\files\result.txt";

//    lock(obj)
//    {
//        if (!File.Exists(filePath)) File.Create(filePath).Close();

//        using (var reader = new StreamReader(filePath))
//        {
//            var lines = reader.ReadToEnd();
//            var count = lines.Count(ch => char.IsDigit(ch));
//            using (var writer = new StreamWriter(result, true))
//            {
//                writer.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} | Path: {filePath} | Count Of Digits: {count}");
//            }
//        }
//    }
//}

















//public static void Worker(string filesPath, string path)
//{
//    var texts = File.ReadAllText(filesPath);
//    var count = 0;
//    foreach (var text in texts)
//    {
//        if (char.IsDigit(text)) count++;
//    }
//    string[] lines = new string[]
//    {
//        $"Digits: {count}, Path: {filesPath}, ThreandId: {Thread.CurrentThread.ManagedThreadId}"
//    };
//    //
//    File.WriteAllLines(path, lines);
//}
//    string diroctoryPath = @"D:\Projects\G10_ThirdModule\3.7\ConsoleApp1\ConsoleApp1\files";
//    var filesPath = Directory.GetFiles(diroctoryPath);
//    var _path = Path.Combine(diroctoryPath, "digits.txt");
//        if (!File.Exists(_path))
//        {
//            File.WriteAllText(_path, "");
//        }
//        Thread thread = null;

//        foreach (var item in filesPath)
//        {
//            thread = new Thread(() => Worker(item, _path));
//thread.Start();
//        }




//var count = 0;
//    foreach (var item in filesPath)
//    {       
//        count = 0;
//        lock (_lock)
//        {
//            using (StreamReader sr = new StreamReader(item))
//            {
//                foreach (var line in sr.ReadToEnd())
//                {
//                    if (char.IsDigit(line))
//                    {
//                        count++;
//                    }
//                }
//            }
//        }
//        Console.WriteLine($"Digits: {count}, Path: {item}, ThreandId: {Thread.CurrentThread.ManagedThreadId}");
//    }















//public static void CountUp()
//{
//    for (int i = 0; i <= 10; i++)
//    {
//        Console.WriteLine($"i: {i}, id: {Thread.CurrentThread.ManagedThreadId}, name: {Thread.CurrentThread.Name} \n");
//        Thread.Sleep(100);
//    }
//}

//public static void CountDown()
//{
//    for (int i = 10; i >= 0; i--)
//    {
//        Console.WriteLine($"i: {i}, id: {Thread.CurrentThread.ManagedThreadId}, name: {Thread.CurrentThread.Name} \n");
//        Thread.Sleep(100); 
//    }
//}



//main
//Console.WriteLine("start");
//    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//    Console.WriteLine();

//    Thread thread1 = new Thread(CountUp)
//    {
//        Name = "Up",
//    };

//Thread thread2 = new Thread(CountDown)
//{
//    Name = "Down",
//};

//thread1.Start();
//    thread2.Start();

//    thread1.Join();
//    thread2.Join();

//    Console.WriteLine("finish");
//    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
#endregion
